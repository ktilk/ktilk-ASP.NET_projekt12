using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person
    {
        //TODO stringide pikkused piirata ja värki
        public int PersonID { get; set; }
        [Required]
        [MaxLength(128, ErrorMessageResourceName = "FirstNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "FirstNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(128, ErrorMessageResourceName = "LastNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "LastNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public string LastName { get; set; }
        [Range(0, 2048, ErrorMessageResourceName = "HeightOutOfBoundsError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public int? Height { get; set; }
        [Range(0, 2048, ErrorMessageResourceName = "WeightOutOfBoundsError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public int? Weight { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DateCreated { get; set; }

        public virtual List<Contact> Contacts { get; set; }
        public virtual List<Plan> Plans { get; set; }
        public virtual List<Participation> Participations { get; set; }
    }
}
