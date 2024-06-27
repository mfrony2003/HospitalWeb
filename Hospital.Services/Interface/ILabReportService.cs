using Hospital.Utility;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interface
{
    public interface ILabReportService
    {
        PageResult<LabReportViewModel> GetAll(int pageNumber, int pageSize);
        LabReportViewModel GetLabReportById(int reportId);
        void UpdateLabReportInfo(LabReportViewModel labReport);

        void InsertLabReportInfo(LabReportViewModel labReport);
        void DeleteLabReportInfo(int id);
    }
}
