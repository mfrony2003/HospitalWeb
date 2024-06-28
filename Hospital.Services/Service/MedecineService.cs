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
        public void DeleteMedecine(int id)
        {
            var model = _unitOfWork.GenericRepository<Medecine>().GetById(id);
            _unitOfWork.GenericRepository<Medecine>().Delete(model);
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
                var modelList = _unitOfWork.GenericRepository<Medecine>().GetAll(includeProperties: "MedecineCategory")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Medecine>().GetAll().ToList().Count;

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
        private List<MedecineViewModel> ConvertModelToVieModelList(List<Medecine> modelList)
        {
            return modelList.Select(x => new MedecineViewModel(x)).ToList();
        }

        public MedecineViewModel GetMedecineById(int Id)
        {
            var model = _unitOfWork.GenericRepository<Medecine>().GetById(Id);
            var vm = new MedecineViewModel(model);
            return vm;
        }

        public void InsertMedecine(MedecineViewModel medecine)
        {
            var model = new MedecineViewModel().ConvertViewModel(medecine);
            _unitOfWork.GenericRepository<Medecine>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateMedecine(MedecineViewModel medecine)
        {
            var model = new MedecineViewModel().ConvertViewModel(medecine);
            var modelById = _unitOfWork.GenericRepository<Medecine>().GetById(model.Id);
            modelById.Name = medecine.Name;
            modelById.Price = medecine.Price;
            
            _unitOfWork.GenericRepository<Medecine>().Update(modelById);
            _unitOfWork.Save();

        }
    }
}
