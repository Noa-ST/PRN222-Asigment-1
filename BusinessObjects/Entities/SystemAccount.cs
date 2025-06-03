using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entities
{
    public class SystemAccount
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // Admin, Staff, Lecturer

        public ICollection<NewsArticle> CreatedNewsArticles { get; set; }
        public ICollection<NewsArticle> UpdatedNewsArticles { get; set; }
    }
}
