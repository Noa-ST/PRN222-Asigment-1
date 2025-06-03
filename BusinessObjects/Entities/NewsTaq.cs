using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entities
{
    public class NewsTaq
    {
        public int NewsArticleID { get; set; }
        public NewsArticle NewsArticle { get; set; }
        public int TaqID { get; set; }
        public Taq Taq { get; set; }
    }
}
