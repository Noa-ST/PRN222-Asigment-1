using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class CategoryBaseDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public int? ParentCategoryID { get; set; }
    }

    public class CreateCategoryDto : CategoryBaseDto { }

    public class UpdateCategoryDto : CategoryBaseDto
    {
        [Required]
        public int ID { get; set; }
    }

    public class GetCategoryDto : CategoryBaseDto
    {
        public int ID { get; set; }
        public ICollection<GetChildCategoryDto> ChildCategories { get; set; }
        public ICollection<GetNewsArticleDto> NewsArticles { get; set; }
    }

    public class GetChildCategoryDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
