using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PlanType
    {
        public int PlanTypeID { get; set; }
        public string PlanTypeName { get; set; }
        public string Description { get; set; }
        public virtual List<Plan> Plans { get; set; }
    }
}
