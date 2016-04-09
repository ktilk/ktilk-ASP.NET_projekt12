using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ContactType
    {
        public int ContactTypeID { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "ContactTypeNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "ContactTypeNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public string ContactTypeName { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
