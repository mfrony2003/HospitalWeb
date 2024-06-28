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
    public class LabReportService : ILabReportService
    {
        private IUnitOfWork _unitOfWork;
        public LabReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteLabReportInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<LabReport>().GetById(id);
            _unitOfWork.GenericRepository<LabReport>().Delete(model);
            _unitOfWork.Save();
        }

        public PageResult<LabReportViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new LabReportViewModel();
            int totalCount;
            List<LabReportViewModel> vmList = new List<LabReportViewModel>();
            try
            {
                int ExcludeRecords = pageSize * pageNumber - pageSize;
                var modelList = _unitOfWork.GenericRepository<LabReport>().GetAll(includeProperties: "LabReportCategory")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<LabReport>().GetAll().ToList().Count;

                vmList = ConvertModelToVieModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<LabReportViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private List<LabReportViewModel> ConvertModelToVieModelList(List<LabReport> modelList)
        {
            return modelList.Select(x => new LabReportViewModel(x)).ToList();

        }
        public LabReportViewModel GetLabReportById(int reportId)
        {
            var model = _unitOfWork.GenericRepository<LabReport>().GetById(reportId);
            var vm = new LabReportViewModel(model);
            return vm;
        }

        public void InsertLabReportInfo(LabReportViewModel labReport)
        {
            var model = new LabReportViewModel().ConvertViewModel(labReport);
            _unitOfWork.GenericRepository<LabReport>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateLabReportInfo(LabReportViewModel labReport)
        {
            var model = new LabReportViewModel().ConvertViewModel(labReport);
            var modelById = _unitOfWork.GenericRepository<LabReport>().GetById(model.Id);
            modelById.Name = labReport.Name;
            modelById.Price = labReport.Price;            
            _unitOfWork.GenericRepository<LabReport>().Update(modelById);
            _unitOfWork.Save();

        }
    }
}
