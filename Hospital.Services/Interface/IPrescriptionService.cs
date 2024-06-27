using Hospital.Utility;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interface
{
    public interface IPrescriptionService
    {
        PageResult<PrescriptionViewModel> GetAll(int pageNumber, int pageSize);
        PrescriptionViewModel GetPrescriptionById(int prescriptionId);
        void UpdatePrescriptionInfo(PrescriptionViewModel prescriptionViewModel);
        void InsertPrescriptionInfo(PrescriptionViewModel prescriptionViewModel);
        void DeletePrescriptionInfo(int id);
    }
}
