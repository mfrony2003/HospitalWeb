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
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Temperature { get; set; }

        public string BP { get; set; }

        public string Pulse { get; set; }

        public string PresentingComplain { get; set; }

        public string Advices { get; set; }

        public string Description { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }

        public List<PrescribeMedecine> PrescribeMedecines { get; set; }

        public List<PrescribeLabReport> PrescribeLabReports { get; set; }

    }

    
}
