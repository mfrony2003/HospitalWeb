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
    public interface IAppoinmentService
    {
        PageResult<AppointmentViewModel> GetAll(int pageNumber, int pageSize);
        PageResult<AppointmentViewModel> GetAppointmentBylDoctor(int pageNumber, int pageSize,ApplicationUser doctor);
        PageResult<AppointmentViewModel> GetAppointmentBylPatient(int pageNumber, int pageSize, ApplicationUser patient);
        PageResult<AppointmentViewModel> SearchAppointmentr(int pageNumber, int pageSize, string specility = null);
        void InsertAppointment(AppointmentViewModel appointment);
        void UpdateHospitalInfo(AppointmentViewModel appointment);


    }
}
