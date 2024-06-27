using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
    
namespace Hospital.ViewModel
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime Time { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }

        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }

        public IEnumerable<ApplicationUser> AllDoctor { get; set; }
        public IEnumerable<ApplicationUser> AllPatient { get; set; }
        


        public AppointmentViewModel()
        {

        }
        public AppointmentViewModel(Appointment model)
        {
            Id = model.Id;
            CreatedDate = model.CreatedDate;
            Time = model.Time;
            Doctor=model.Doctor;
            Patient=model.Patient;
            
            
        }
        public Appointment ConvertViewModel(AppointmentViewModel model)
        {
            return new Appointment
            {
                Id = model.Id,
                CreatedDate= model.CreatedDate,
                Time = model.Time,
                Doctor=model.Doctor,
                Patient=model.Patient
                
                
            };
        }
    }
}
