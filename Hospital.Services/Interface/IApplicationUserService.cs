using Hospital.Models;
using Hospital.Utility;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interface
{
    public interface IApplicationUserService
    {
        PageResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);
        PageResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize);
        
        IEnumerable<ApplicationUser> GetAllDoctor();
        IEnumerable<ApplicationUser> GetAllPatient();

        ApplicationUser GetDoctorById(Guid doctorId);
        ApplicationUser GetPatientById(Guid patientId);
        PageResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize);
        PageResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize,string specility=null);
        


    }
}
