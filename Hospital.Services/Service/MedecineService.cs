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
    public class MedecineService : IMedecineService
    {
        private IUnitOfWork _unitOfWork;
        public MedecineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void DeleteMedecineInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<MedecineInfo>().GetById(id);
            _unitOfWork.GenericRepository<MedecineInfo>().Delete(model);
            _unitOfWork.Save();
        }

        public PageResult<MedecineViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new MedecineViewModel();
            int totalCount;
            List<MedecineViewModel> vmList = new List<MedecineViewModel>();
            try
            {
                int ExcludeRecords = pageSize * pageNumber - pageSize;
                var modelList = _unitOfWork.GenericRepository<MedecineInfo>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<MedecineInfo>().GetAll().ToList().Count;

                vmList = ConvertModelToVieModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<MedecineViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<MedecineViewModel> ConvertModelToVieModelList(List<MedecineInfo> modelList)
        {
            return modelList.Select(x => new MedecineViewModel(x)).ToList();
        }

        public MedecineViewModel GetMedecineById(int Id)
        {
            var model = _unitOfWork.GenericRepository<MedecineInfo>().GetById(Id);
            var vm = new MedecineViewModel(model);
            return vm;
        }

        public void InsertMedecineInfo(MedecineViewModel medecine)
        {
            var model = new MedecineViewModel().ConvertViewModel(medecine);
            _unitOfWork.GenericRepository<MedecineInfo>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateMedecineInfo(MedecineViewModel medecine)
        {
            var model = new MedecineViewModel().ConvertViewModel(medecine);
            var modelById = _unitOfWork.GenericRepository<MedecineInfo>().GetById(model.Id);
            modelById.Name = medecine.Name;
            modelById.Price = medecine.Price;
            
            _unitOfWork.GenericRepository<MedecineInfo>().Update(modelById);
            _unitOfWork.Save();

        }
    }
}
