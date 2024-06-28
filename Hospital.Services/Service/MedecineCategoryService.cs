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
    public class MedecineCategoryService : IMedecineCategoryService
    {
        private IUnitOfWork _unitOfWork;
        public MedecineCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void DeleteMedecineCategory(int rmedecineCategoryId)
        {
            var model = _unitOfWork.GenericRepository<MedecineCategory>().GetById(rmedecineCategoryId);
            _unitOfWork.GenericRepository<MedecineCategory>().Delete(model);
            _unitOfWork.Save();
        }

        public PageResult<MedecineCategoryViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new MedecineCategoryViewModel();
            int totalCount;
            List<MedecineCategoryViewModel> vmList = new List<MedecineCategoryViewModel>();
            try
            {
                int ExcludeRecords = pageSize * pageNumber - pageSize;
                var modelList = _unitOfWork.GenericRepository<MedecineCategory>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<MedecineCategory>().GetAll().ToList().Count;

                vmList = ConvertModelToVieModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<MedecineCategoryViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        public IEnumerable<MedecineCategory> GetAll()
        {
            IEnumerable<MedecineCategory> modelList;

            try
            {

                modelList = _unitOfWork.GenericRepository<MedecineCategory>().GetAll();

            }
            catch (Exception)
            {
                throw;
            }
            return modelList;
        }
        public MedecineCategory GetMedecineCategoryModelById(int Id)
        {
            MedecineCategory model;

            try
            {

                model = _unitOfWork.GenericRepository<MedecineCategory>().GetById(Id);

            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
        private List<MedecineCategoryViewModel> ConvertModelToVieModelList(List<MedecineCategory> modelList)
        {
            return modelList.Select(x => new MedecineCategoryViewModel(x)).ToList();

        }

        public MedecineCategoryViewModel GetMedecineCategoryById(int rmedecineCategoryId)
        {
            var model = _unitOfWork.GenericRepository<MedecineCategory>().GetById(rmedecineCategoryId);
            var vm = new MedecineCategoryViewModel(model);
            return vm;
        }

        public void InsertMedecineCategory(MedecineCategoryViewModel medecineCategory)
        {
            var model = new MedecineCategoryViewModel().ConvertViewModel(medecineCategory);
            _unitOfWork.GenericRepository<MedecineCategory>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateMedecineCategory(MedecineCategoryViewModel medecineCategory)
        {
            var model = new MedecineCategoryViewModel().ConvertViewModel(medecineCategory);
            var modelById = _unitOfWork.GenericRepository<MedecineCategory>().GetById(model.Id);
            modelById.Name = medecineCategory.Name;
            _unitOfWork.GenericRepository<MedecineCategory>().Update(modelById);
            _unitOfWork.Save();

        }
    }
}
