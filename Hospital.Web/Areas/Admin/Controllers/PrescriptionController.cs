using Hospital.Services.Interface;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PrescriptionController : Controller
    {
        IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }
        public IActionResult PrescriptionList(int pageNumber = 1, int pageSize = 10)
        {
            return View(_prescriptionService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult AddPrescription()
        {
            return View();
        }



        public IActionResult AddPrescription(PrescriptionViewModel vm)
        {
            _prescriptionService.InsertPrescriptionInfo(vm);
            return RedirectToAction("PrescriptionList");
        }

        [HttpGet]
        public IActionResult EditPrescription(int id)
        {
            var viewModel = _prescriptionService.GetPrescriptionById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditPrescription(PrescriptionViewModel vm)
        {
            _prescriptionService.UpdatePrescriptionInfo(vm);
            return RedirectToAction("PrescriptionList");
        }

        public IActionResult DeletePrescription(int id)
        {
            _prescriptionService.DeletePrescriptionInfo(id);
            return RedirectToAction("PrescriptionList");
        }

    }
}
