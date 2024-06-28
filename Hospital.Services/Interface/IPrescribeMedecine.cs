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
    public interface IPrescribeMedecine
    {

        IEnumerable<PrescribeMedecine> GetPrescribeMedecineByPrescriptionId(int prescriptionId);
        void UpdatePrescribeMedecine(PrescribeMedecineViewModel prescribeMedecine);
        void InsertPrescribeMedecine(PrescribeMedecineViewModel prescribeMedecine);
        void DeletePrescribeMedecine(int id);
    }
}
