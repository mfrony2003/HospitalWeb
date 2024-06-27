using Hospital.Models;
using Hospital.Utility;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interface
{
    public interface IMedecineCategoryService
    {
        PageResult<MedecineCategoryViewModel> GetAll(int pageNumber, int pageSize);
        MedecineCategoryViewModel GetMedecineCategoryById(int rmedecineCategoryId);
        void UpdateMedecineCategory(MedecineCategoryViewModel medecineCategory);

        void InsertMedecineCategory(MedecineCategoryViewModel medecineCategory);
        void DeleteMedecineCategory(int rmedecineCategoryId);
    }
}
