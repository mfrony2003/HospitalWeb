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
        public string Description { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }

        public List<MedecineInfo> MedecineNames { get; set; } = new List<MedecineInfo>();

        public List<LabReport> LabReports { get; set; } = new List<LabReport>();
        

        public PrescriptionViewModel() { }

        public PrescriptionViewModel(Prescription model)
        {
            Id = model.Id;
            Description = model.Description;
            Doctor = model.Doctor;
            Patient = model.Patient;
            MedecineNames = model.MedecineNames;
            LabReports = model.LabReports;


        }

        public Prescription ConvertViewModel(PrescriptionViewModel model)
        {
            return new Prescription
            {
                Id = model.Id,
                Description = model.Description,
                Doctor = model.Doctor,
                Patient = model.Patient,
                MedecineNames = model.MedecineNames,
                LabReports = model.LabReports



            };
        }

    }
}
