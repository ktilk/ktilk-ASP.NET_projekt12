using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ExerciseType
    {
        public int ExerciseTypeID { get; set; }
        public string ExerciseTypeName { get; set; }
        public string Description { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
    }
}
