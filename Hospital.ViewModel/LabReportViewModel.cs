using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class LabReportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public LabReportCategory LabReportCategory { get; set; }
        public IEnumerable<LabReportCategory> AllLabReportCategory { get; set; }

        public LabReportViewModel() { }

        public LabReportViewModel(LabReport model)
        {
            Id = model.Id; 
            Name = model.Name;
            Price = model.Price; 
            LabReportCategory = model.LabReportCategory;
        }
        public LabReport ConvertViewModel(LabReportViewModel model)
        {
            return new LabReport
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                LabReportCategory = model.LabReportCategory,
            };
        }

    }
}
