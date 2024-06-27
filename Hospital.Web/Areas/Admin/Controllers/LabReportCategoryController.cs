using Hospital.Models;
using Hospital.Services.Interface;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    public class LabReportCategoryController : Controller
    {
        public ILabReportCategoryService _ILabReportCategoryService;
        public LabReportCategoryController(ILabReportCategoryService ILabReportCategoryService)
        {
            ILabReportCategoryService = _ILabReportCategoryService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_ILabReportCategoryService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _ILabReportCategoryService.GetLabReportCategoryById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(LabReportCategoryViewModel vm)
        {
            _ILabReportCategoryService.UpdateLabReportCategory(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LabReportCategoryViewModel vm)
        {
            _ILabReportCategoryService.InsertLabReportCategory(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _ILabReportCategoryService.DeleteLabReportCategory(id);
            return RedirectToAction("Index");
        }
    }
}

