using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class MedecineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public int MedecineCategoryId { get; set; }
        public MedecineCategory MedecineCategory { get; set; }
        public IEnumerable<MedecineCategory> AllMedecineCategory { get; set; }
        public MedecineViewModel() { }

        public MedecineViewModel(Medecine model)
        {
            Id = model.Id;
            Name = model.Name;
            Price = model.Price;
            MedecineCategory = model.MedecineCategory;

        }

        public Medecine ConvertViewModel(MedecineViewModel model)
        {
            return new Medecine
            {
                Id = model.Id,
                Name = model.Name,                
                Price = model.Price,
                MedecineCategory=model.MedecineCategory,
               
            };
        }
    }
}
