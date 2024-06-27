using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class ApplicationUserViewModel
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DOb { get; set; }

        public Speciality Speciality { get; set; }
        public bool IsDoctor { get; set; }
        public bool IsPatient { get; set; }
        public bool IsStaff { get; set; }

        public ApplicationUserViewModel()
        {

        }
        public ApplicationUserViewModel(ApplicationUser model)
        {
             Name = model.Name;Gender = model.Gender;
            Nationality = model.Nationality; Address = model.Address;
            DOb = model.DOb; Speciality = model.Speciality;
            IsDoctor = model.IsDoctor;IsPatient = model.IsPatient;
            IsStaff = model.IsStaff;UserName = model.UserName;
            Email = model.Email;
        }

        public ApplicationUser ConvertViewModel(ApplicationUserViewModel model)
        {
            return new ApplicationUser
            {
                
                Name = model.Name,
                Gender=model.Gender,
                Nationality=model.Nationality,
                Address=model.Address,
                DOb=model.DOb,
                UserName=model.UserName,
                Email=model.Email,
                Speciality=model.Speciality,
                IsDoctor=model.IsDoctor,
                IsPatient=model.IsPatient,
                IsStaff=model.IsStaff,

            };
        }
    }
}
