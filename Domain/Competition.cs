using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Competition
    {
        public int CompetitionID { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "CompetitionNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "CompetitionNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public string CompetitionName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateEnd { get; set; }

        public virtual List<Participation> Participations { get; set; }
    }
}
