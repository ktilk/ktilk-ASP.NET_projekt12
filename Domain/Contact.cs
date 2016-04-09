using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "ContactValueLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "ContactValueLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public string Value { get; set; }

        public int ContactTypeID { get; set; }
        public virtual ContactType ContactType { get; set; }

        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
