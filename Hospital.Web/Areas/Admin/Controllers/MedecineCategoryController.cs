using Hospital.Services.Interface;
using Hospital.Services.Service;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    public class MedecineCategoryController : Controller
    {
        public IMedecineCategoryService _IMedecineCategoryService;
        

        public MedecineCategoryController(IMedecineCategoryService ImedecineCategoryService)
        {
            _IMedecineCategoryService = ImedecineCategoryService;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_IMedecineCategoryService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _IMedecineCategoryService.GetMedecineCategoryById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(MedecineCategoryViewModel vm)
        {
            _IMedecineCategoryService.UpdateMedecineCategory(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MedecineCategoryViewModel vm)
        {
            _IMedecineCategoryService.InsertMedecineCategory(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _IMedecineCategoryService.DeleteMedecineCategory(id);
            return RedirectToAction("Index");
        }
    }
}
