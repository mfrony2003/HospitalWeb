using Hospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public  class LabReportCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public LabReportCategoryViewModel(LabReportCategory model)
        {
            Id = model.Id;
            Name = model.Name;
            
            
        }
        public LabReportCategory ConvertViewModel(LabReportCategoryViewModel model)
        {
            return new LabReportCategory
            {
                Id = model.Id,
                Name = model.Name,
            
            };
        }


    }
}
