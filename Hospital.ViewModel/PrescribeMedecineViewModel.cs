using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class PrescribeMedecineViewModel
    {
        public int Id { get; set; }
        public Prescription Prescription { get; set; }
        public Medecine Medecine { get; set; }

        public PrescribeMedecineViewModel() { }

        public PrescribeMedecineViewModel(PrescribeMedecine model)
        {
            Id = model.Id;
            Prescription = model.Prescription;
            Medecine = model.Medecine;


        }

        public PrescribeMedecine ConvertViewModel(PrescribeMedecineViewModel model)
        {
            return new PrescribeMedecine
            {
                Id = model.Id,
                Prescription = model.Prescription,
                Medecine = model.Medecine



            };
        }

    }
}
