using Hospital.Models;
using Hospital.Repositories.Iterface;
using Hospital.Services.Interface;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Service
{
    public class PrescribeMedecineService : IPrescribeMedecine
    {
        private IUnitOfWork _unitOfWork;
        public PrescribeMedecineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public void DeletePrescribeMedecine(int id)
        {
            var model = _unitOfWork.GenericRepository<PrescribeMedecine>().GetById(id);
            _unitOfWork.GenericRepository<PrescribeMedecine>().Delete(model);
            _unitOfWork.Save();
        }

        public IEnumerable<PrescribeMedecine> GetPrescribeMedecineByPrescriptionId(int prescriptionId)
        {
            IEnumerable<PrescribeMedecine> modelList;

            try
            {

                modelList = _unitOfWork.GenericRepository<PrescribeMedecine>().GetAll();

            }
            catch (Exception)
            {
                throw;
            }
            return modelList;
        }

        public void InsertPrescribeMedecine(PrescribeMedecineViewModel prescribeMedecine)
        {
            var model = new PrescribeMedecineViewModel().ConvertViewModel(prescribeMedecine);
            _unitOfWork.GenericRepository<PrescribeMedecine>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdatePrescribeMedecine(PrescribeMedecineViewModel prescribeMedecine)
        {
            var model = new PrescribeMedecineViewModel().ConvertViewModel(prescribeMedecine);
            var modelById = _unitOfWork.GenericRepository<PrescribeMedecine>().GetById(model.Id);
            modelById.Medecine = prescribeMedecine.Medecine;
            modelById.Prescription = prescribeMedecine.Prescription;

            _unitOfWork.GenericRepository<PrescribeMedecine>().Update(modelById);
            _unitOfWork.Save();
        }
    }
}
