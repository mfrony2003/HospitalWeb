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
    public interface ILabReportCategoryService
    {
        PageResult<LabReportCategoryViewModel> GetAll(int pageNumber, int pageSize);
        LabReportCategoryViewModel GetLabReportCategoryById(int hospitalId);

        IEnumerable<LabReportCategory> GetAll();
        LabReportCategory GetLabReportCategoryModelById(int Id);
        void UpdateLabReportCategory(LabReportCategoryViewModel labreportCategory);
        void InsertLabReportCategory(LabReportCategoryViewModel labreportCategory);
        void DeleteLabReportCategory(int id);
    }
}
