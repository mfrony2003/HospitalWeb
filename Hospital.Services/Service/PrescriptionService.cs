using Hospital.Models;
using Hospital.Repositories.Iterface;
using Hospital.Services.Interface;
using Hospital.Utility;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private IUnitOfWork _unitOfWork;
        public PrescriptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public void DeletePrescriptionInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<Prescription>().GetById(id);
            _unitOfWork.GenericRepository<Prescription>().Delete(model);
            _unitOfWork.Save();
        }

        public PageResult<PrescriptionViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new PrescriptionViewModel();
            int totalCount;
            List<PrescriptionViewModel> vmList = new List<PrescriptionViewModel>();
            try
            {
                int ExcludeRecords = pageSize * pageNumber - pageSize;
                var modelList = _unitOfWork.GenericRepository<Prescription>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Prescription>().GetAll().ToList().Count;

                vmList = ConvertModelToVieModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<PrescriptionViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private List<PrescriptionViewModel> ConvertModelToVieModelList(List<Prescription> modelList)
        {
            return modelList.Select(x => new PrescriptionViewModel(x)).ToList();

        }
        public PrescriptionViewModel GetPrescriptionById(int prescriptionId)
        {
            var model = _unitOfWork.GenericRepository<Prescription>().GetById(prescriptionId);
            var vm = new PrescriptionViewModel(model);
            return vm;
        }

        public void InsertPrescriptionInfo(PrescriptionViewModel prescriptionViewModel)
        {
            var model = new PrescriptionViewModel().ConvertViewModel(prescriptionViewModel);
            _unitOfWork.GenericRepository<Prescription>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdatePrescriptionInfo(PrescriptionViewModel prescriptionViewModel)
        {
            var model = new PrescriptionViewModel().ConvertViewModel(prescriptionViewModel);
            var modelById = _unitOfWork.GenericRepository<Prescription>().GetById(model.Id);
            modelById.Description  = model.Description;
            modelById.Doctor = model.Doctor;
            modelById.Patient = model.Patient;
            modelById.LabReports= model.LabReports;
            modelById.MedecineNames = model.MedecineNames;            

            _unitOfWork.GenericRepository<Prescription>().Update(modelById);
            _unitOfWork.Save();
        }
    }
}
