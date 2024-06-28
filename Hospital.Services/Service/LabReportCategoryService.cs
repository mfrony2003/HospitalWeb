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
    public class LabReportCategoryService : ILabReportCategoryService
    {

        private IUnitOfWork _unitOfWork;
        public LabReportCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteLabReportCategory(int id)
        {
            var model = _unitOfWork.GenericRepository<LabReportCategory>().GetById(id);
            _unitOfWork.GenericRepository<LabReportCategory>().Delete(model);
            _unitOfWork.Save();
        }

        public PageResult<LabReportCategoryViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new LabReportCategoryViewModel();
            int totalCount;
            List<LabReportCategoryViewModel> vmList = new List<LabReportCategoryViewModel>();
            try
            {
                int ExcludeRecords = pageSize * pageNumber - pageSize;
                var modelList = _unitOfWork.GenericRepository<LabReportCategory>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<LabReportCategory>().GetAll().ToList().Count;

                vmList = ConvertModelToVieModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<LabReportCategoryViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        public IEnumerable<LabReportCategory> GetAll()
        {
            IEnumerable<LabReportCategory> modelList;

            try
            {

                modelList = _unitOfWork.GenericRepository<LabReportCategory>().GetAll();

            }
            catch (Exception)
            {
                throw;
            }
            return modelList;
        }
        public LabReportCategory GetLabReportCategoryModelById(int Id)
        {
            LabReportCategory model;

            try
            {

                model = _unitOfWork.GenericRepository<LabReportCategory>().GetById(Id);

            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        private List<LabReportCategoryViewModel> ConvertModelToVieModelList(List<LabReportCategory> modelList)
        {
            return modelList.Select(x => new LabReportCategoryViewModel(x)).ToList();

        }
        public LabReportCategoryViewModel GetLabReportCategoryById(int labReportCategoryId)
        {
            var model = _unitOfWork.GenericRepository<LabReportCategory>().GetById(labReportCategoryId);
            var vm = new LabReportCategoryViewModel(model);
            return vm;
        }

        public void InsertLabReportCategory(LabReportCategoryViewModel labreportCategory)
        {
            var model = new LabReportCategoryViewModel().ConvertViewModel(labreportCategory);
            _unitOfWork.GenericRepository<LabReportCategory>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateLabReportCategory(LabReportCategoryViewModel labreportCategory)
        {
            var model = new LabReportCategoryViewModel().ConvertViewModel(labreportCategory);
            var modelById = _unitOfWork.GenericRepository<LabReportCategory>().GetById(model.Id);
            modelById.Name = labreportCategory.Name;            
            _unitOfWork.GenericRepository<LabReportCategory>().Update(modelById);
            _unitOfWork.Save();
        }
    }
}
