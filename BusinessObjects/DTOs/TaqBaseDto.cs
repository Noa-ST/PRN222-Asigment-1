using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class TaqBaseDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }

    public class CreateTaqDto : TaqBaseDto { }

    public class UpdateTaqDto : TaqBaseDto
    {
        [Required]
        public int ID { get; set; }
    }

    public class GetTaqDto : TaqBaseDto
    {
        public int ID { get; set; }
    }

}
