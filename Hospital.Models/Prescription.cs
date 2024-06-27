using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }

        public List<MedecineInfo> MedecineNames { get; set; }

        public List<LabReport> LabReports { get; set; }

    }

    
}
