using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Entities
{
    public class NewsArticle
    {
        public int ID { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int NewsStatus { get; set; } // 0 = Inactive, 1 = Active

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public int CreatedByID { get; set; }
        public SystemAccount CreatedBy { get; set; }

        public int? UpdatedByID { get; set; }
        public SystemAccount UpdatedBy { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<NewsTaq> NewsTaqs { get; set; }
    }
}
