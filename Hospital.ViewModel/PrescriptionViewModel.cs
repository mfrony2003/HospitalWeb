using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hospital.ViewModel
{
    public class PrescriptionViewModel
    {
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


        public PrescriptionViewModel() { }

        public PrescriptionViewModel(Prescription model)
        {
            Id = model.Id;
            Description = model.Description;
            Doctor = model.Doctor;
            Patient = model.Patient;
            PrescribeMedecines = model.PrescribeMedecines;
            PrescribeLabReports = model.PrescribeLabReports;


        }

        public Prescription ConvertViewModel(PrescriptionViewModel model)
        {
            return new Prescription
            {
                Id = model.Id,
                Description = model.Description,
                Doctor = model.Doctor,
                Patient = model.Patient,
                PrescribeMedecines = model.PrescribeMedecines,
                PrescribeLabReports = model.PrescribeLabReports



            };
        }

    }
}
