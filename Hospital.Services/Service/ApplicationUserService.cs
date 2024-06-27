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
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

            public PageResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize)
            {
                var vm = new ApplicationUserViewModel();
                int totalCount;
                List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
                try
                {
                    int ExcludeRecords = pageSize * pageNumber - pageSize;
                    var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll()
                        .Skip(ExcludeRecords).Take(pageSize).ToList();
                    totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;

                    vmList = ConvertModelToVieModelList(modelList);
                }
                catch (Exception)
                {
                    throw;
                }
                var result = new PageResult<ApplicationUserViewModel>
                {
                    Data = vmList,
                    TotalItems = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;

            }
            public IEnumerable<ApplicationUser> GetAllDoctor()
            {
                  IEnumerable<ApplicationUser> modelList;
            
                try            {

                     modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true);                                  

         
                }
                catch (Exception)
                {
                    throw;
                }
            
                return modelList;
            }

            public IEnumerable<ApplicationUser> GetAllPatient()
            {
                IEnumerable<ApplicationUser> modelList;

                try
                {

                    modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsPatient == true);


                }
                catch (Exception)
                {
                    throw;
                }

                return modelList;
            }


            public PageResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize)
            {
                var vm = new ApplicationUserViewModel();
                int totalCount;
                List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
                try
                {
                    int ExcludeRecords = pageSize * pageNumber - pageSize;
                    var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x=>x.IsDoctor==true)
                        .Skip(ExcludeRecords).Take(pageSize).ToList();
                    totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true).ToList().Count;

                    vmList = ConvertModelToVieModelList(modelList);
                }
                catch (Exception)
                {
                    throw;
                }
                var result = new PageResult<ApplicationUserViewModel>
                {
                    Data = vmList,
                    TotalItems = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;
            }

            public PageResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize)
            {
                var vm = new ApplicationUserViewModel();
                int totalCount;
                List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
                try
                {
                    int ExcludeRecords = pageSize * pageNumber - pageSize;
                    var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsPatient == true)
                        .Skip(ExcludeRecords).Take(pageSize).ToList();
                    totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsPatient == true).ToList().Count;

                    vmList = ConvertModelToVieModelList(modelList);
                }
                catch (Exception)
                {
                    throw;
                }
                var result = new PageResult<ApplicationUserViewModel>
                {
                    Data = vmList,
                    TotalItems = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;
            }

            public PageResult<ApplicationUserViewModel> SearchDoctor(int pagenupageNumber, int pageSize, string specility = null)
            {
                throw new NotImplementedException();

            }

            private List<ApplicationUserViewModel> ConvertModelToVieModelList(List<ApplicationUser> modelList)
            {
                return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
            }

            public ApplicationUser GetDoctorById(Guid doctorId)
            {
                ApplicationUser doctor;
                try
                {

    #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    doctor = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.Id == doctorId.ToString()).FirstOrDefault();
                    #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.


                }
                catch (Exception)
                {
                    throw;
                }

                return doctor;
            }

            public ApplicationUser GetPatientById(Guid patientId)
            {
                ApplicationUser patient;
                try
                {

                    #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    patient = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.Id == patientId.ToString()).FirstOrDefault();
                    #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.


                }
                catch (Exception)
                {
                    throw;
                }

                return patient;
            }
    }
}
