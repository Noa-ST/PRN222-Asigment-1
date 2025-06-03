using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class NewsArticleBaseDto
    {
        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryID { get; set; }
        public int NewsStatus { get; set; } // 0 = Inactive, 1 = Active
    }

    public class CreateNewsArticleDto : NewsArticleBaseDto
    {
        [Required]
        public int CreatedByID { get; set; }
        public List<int> TaqIDs { get; set; }

    }

    public class UpdateNewsArticleDto : NewsArticleBaseDto
    {
        [Required]
        public int ID { get; set; }
        public int? UpdatedByID { get; set; }
        public List<int> TaqIDs { get; set; }
    }

    public class GetNewsArticleDto : NewsArticleBaseDto
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public string CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }
        public string CategoryName { get; set; }

        public List<GetTaqDto> Taqs { get; set; }
    }
}
