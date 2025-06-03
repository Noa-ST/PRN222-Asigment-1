using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Entities
{
    public class Category
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public int? ParentCategoryID { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; }

        public ICollection<NewsArticle> NewsArticles { get; set; }
    }
}
