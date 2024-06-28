using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class PrescribeLabReportViewModel
    {
        public int Id { get; set; }
        public Prescription Prescription { get; set; }
        public LabReport LabReport { get; set; }

        public PrescribeLabReportViewModel() { }

        public PrescribeLabReportViewModel(PrescribeLabReport model)
        {
            Id = model.Id;
            Prescription = model.Prescription;
            LabReport = model.LabReport;


        }

        public PrescribeLabReport ConvertViewModel(PrescribeLabReportViewModel model)
        {
            return new PrescribeLabReport
            {
                Id = model.Id,
                Prescription = model.Prescription,
                LabReport=model.LabReport



        };
        }
    }
}
