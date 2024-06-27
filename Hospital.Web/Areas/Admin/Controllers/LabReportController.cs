using Hospital.Models;
using Hospital.Services.Interface;
using Hospital.Services.Service;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LabReportController : Controller
    {
        ILabReportService _labReportService;

        public LabReportController(ILabReportService labReportService)
        {
            _labReportService = labReportService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LabReportList(int pageNumber = 1, int pageSize = 10)
        {
            return View(_labReportService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult AddLabReport()
        {
            return View();
        }



        public IActionResult AddLabReport(LabReportViewModel vm)
        {
            _labReportService.InsertLabReportInfo(vm);
            return RedirectToAction("LabReportList");
        }

        [HttpGet]
        public IActionResult EditLabReport(int id)
        {
            var viewModel = _labReportService.GetLabReportById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditLabReport(LabReportViewModel vm)
        {
            _labReportService.UpdateLabReportInfo(vm);
            return RedirectToAction("LabReportList");
        }

        public IActionResult DeleteLabReport(int id)
        {
            _labReportService.DeleteLabReportInfo(id);
            return RedirectToAction("LabReportList");
        }


    }
}
