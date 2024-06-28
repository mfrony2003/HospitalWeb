using Hospital.Models;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interface
{
    public interface IPrescribeLabReport
    {
        IEnumerable<PrescribeLabReport> GetPrescribeLabReportByPrescriptionId(int prescriptionId);
        void UpdatePrescribeLabReport(PrescribeLabReportViewModel prescribeLabReport);
        void InsertPrescribeLabReport(PrescribeLabReportViewModel prescribeLabReport);
        void DeletePrescribeLabReport(int id);
    }
}
