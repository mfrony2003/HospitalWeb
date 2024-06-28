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
    public class PrescribeLabReportService : IPrescribeLabReport
    {

        private IUnitOfWork _unitOfWork;
        public PrescribeLabReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public void DeletePrescribeLabReport(int id)
        {
            var model = _unitOfWork.GenericRepository<PrescribeLabReport>().GetById(id);
            _unitOfWork.GenericRepository<PrescribeLabReport>().Delete(model);
            _unitOfWork.Save();
        }

        public IEnumerable<PrescribeLabReport> GetPrescribeLabReportByPrescriptionId(int prescriptionId)
        {
            IEnumerable<PrescribeLabReport> modelList;

            try
            {

                modelList = _unitOfWork.GenericRepository<PrescribeLabReport>().GetAll();

            }
            catch (Exception)
            {
                throw;
            }
            return modelList;
        }

        public void InsertPrescribeLabReport(PrescribeLabReportViewModel prescribeLabReport)
        {
            var model = new PrescribeLabReportViewModel().ConvertViewModel(prescribeLabReport);
            _unitOfWork.GenericRepository<PrescribeLabReport>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdatePrescribeLabReport(PrescribeLabReportViewModel prescribeLabReport)
        {
            var model = new PrescribeLabReportViewModel().ConvertViewModel(prescribeLabReport);
            var modelById = _unitOfWork.GenericRepository<PrescribeLabReport>().GetById(model.Id);
            modelById.LabReport = prescribeLabReport.LabReport;
            modelById.Prescription = prescribeLabReport.Prescription;
            
            _unitOfWork.GenericRepository<PrescribeLabReport>().Update(modelById);
            _unitOfWork.Save();
        }
    }
}
