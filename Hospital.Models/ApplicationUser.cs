using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DOb { get; set; }

        

        
        public Speciality Speciality { get; set; }
        public bool IsDoctor { get; set; }
        public bool IsPatient { get; set; }
        public bool IsStaff { get; set; }
    }
}

namespace Hospital.Models
{
    public enum Gender
    {
        Male,Female,Other
    }
}

namespace Hospital.Models
{
    public enum Speciality
    {
        Hematologists, Gastroenterologists, General_Medicine, Cardiologists, Pediatricians
    }
}