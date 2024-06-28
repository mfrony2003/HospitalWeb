using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class PrescribeLabReport
    {
        public int Id { get; set; }
        public Prescription Prescription { get; set; }
        public LabReport LabReport { get; set; }
    }
}
