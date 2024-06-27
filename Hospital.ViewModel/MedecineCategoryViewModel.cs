using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class MedecineCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MedecineCategoryViewModel()
        {
            
        }
        public MedecineCategoryViewModel(MedecineCategory model)
        {
            Id = model.Id;
            Name = model.Name;


        }
        public MedecineCategory ConvertViewModel(MedecineCategoryViewModel model)
        {
            return new MedecineCategory
            {
                Id = model.Id,
                Name = model.Name,

            };
        }

    }
}
