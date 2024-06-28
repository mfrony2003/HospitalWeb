using Hospital.Models;
using Hospital.Services.Interface;
using Hospital.Services.Service;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LabReportController : Controller
    {
        ILabReportService _labReportService;
        ILabReportCategoryService _labReportCategoryService;

        public LabReportController(ILabReportService labReportService, ILabReportCategoryService labReportCategoryService)
        {
            _labReportService = labReportService;
            _labReportCategoryService = labReportCategoryService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_labReportService.GetAll(pageNumber, pageSize));
        }


        [HttpGet]
        public IActionResult Create()
        {
            LabReportViewModel viewModel = new LabReportViewModel
            {
                AllLabReportCategory = _labReportCategoryService.GetAll()
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Create(LabReportViewModel vm)
        {
            LabReportCategory labreporteCategory = _labReportCategoryService.GetLabReportCategoryModelById(vm.LabReportCategoryId);
            vm.LabReportCategory = labreporteCategory;

            _labReportService.InsertLabReportInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _labReportService.GetLabReportById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(LabReportViewModel vm)
        {
            _labReportService.UpdateLabReportInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _labReportService.DeleteLabReportInfo(id);
            return RedirectToAction("Index");
        }


    }
}
