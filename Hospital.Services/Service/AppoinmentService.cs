using Hospital.Models;
using Hospital.Repositories.Iterface;
using Hospital.Services.Interface;
using Hospital.Utility;
using Hospital.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Service
{
    public class AppoinmentService : IAppoinmentService
    {
        private IUnitOfWork _unitOfWork;

        public AppoinmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PageResult<AppointmentViewModel> GetAll(int pageNumber, int pageSize)        {

            

            var vm = new AppointmentViewModel();
            int totalCount;
            List<AppointmentViewModel> vmList = new List<AppointmentViewModel>();
            try
            {
                int ExcludeRecords = pageSize * pageNumber - pageSize;
                var modelList = _unitOfWork.GenericRepository<Appointment>().GetAll(includeProperties: "Doctor,Patient")

                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Appointment>().GetAll().ToList().Count;

                vmList = ConvertModelToVieModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<AppointmentViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public PageResult<AppointmentViewModel> GetAppointmentBylDoctor(int pageNumber, int pageSize, ApplicationUser doctor)
        {
            var vm = new AppointmentViewModel();
            int totalCount;
            List<AppointmentViewModel> vmList = new List<AppointmentViewModel>();
            try
            {
                int ExcludeRecords = pageSize * pageNumber - pageSize;
                var modelList = _unitOfWork.GenericRepository<Appointment>().GetAll(x=>x.Doctor==doctor, includeProperties: "Doctor,Patient")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Appointment>().GetAll(x => x.Doctor == doctor).ToList().Count;

                vmList = ConvertModelToVieModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<AppointmentViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public PageResult<AppointmentViewModel> GetAppointmentBylPatient(int pageNumber, int pageSize,ApplicationUser patient)
        {
            var vm = new AppointmentViewModel();
            int totalCount;
            List<AppointmentViewModel> vmList = new List<AppointmentViewModel>();
            try
            {
                int ExcludeRecords = pageSize * pageNumber - pageSize;
                var modelList = _unitOfWork.GenericRepository<Appointment>().GetAll(x => x.Patient == patient)
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Appointment>().GetAll(x => x.Patient == patient).ToList().Count;

                vmList = ConvertModelToVieModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<AppointmentViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public PageResult<AppointmentViewModel> SearchAppointmentr(int pageNumber, int pageSize, string specility = null)
        {
            throw new NotImplementedException();
        }

        private List<AppointmentViewModel> ConvertModelToVieModelList(List<Appointment> modelList)
        {
            return modelList.Select(x => new AppointmentViewModel(x)).ToList();
        }
        public void InsertAppointment(AppointmentViewModel appointment)
        {
            var model = new AppointmentViewModel().ConvertViewModel(appointment);
            _unitOfWork.GenericRepository<Appointment>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateHospitalInfo(AppointmentViewModel appointment)
        {
            var model = new AppointmentViewModel().ConvertViewModel(appointment);
            var modelById = _unitOfWork.GenericRepository<Appointment>().GetById(model.Id);
            
            modelById.CreatedDate = appointment.CreatedDate;            
            _unitOfWork.GenericRepository<Appointment>().Update(modelById);
            _unitOfWork.Save();


        }

    }
}
