using Hospital.Utility;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interface
{
    public interface IMedecineService
    {
        PageResult<MedecineViewModel> GetAll(int pageNumber, int pageSize);
        MedecineViewModel GetMedecineById(int Id);
        void UpdateMedecine(MedecineViewModel medecine);
        void InsertMedecine(MedecineViewModel medecine);
        void DeleteMedecine(int id);
    }
}
