using Hospital.Models;
using Hospital.Services.Interface;
using Hospital.Services.Service;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MedecineController : Controller
    {
        IMedecineService _medecineService;
        IMedecineCategoryService _medecineCategoryService;

        public MedecineController(IMedecineService medecineService, IMedecineCategoryService medecineCategoryService)
        {
            _medecineService = medecineService;
            _medecineCategoryService = medecineCategoryService;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_medecineService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            MedecineViewModel viewModel = new MedecineViewModel
            {
                AllMedecineCategory = _medecineCategoryService.GetAll()
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Create(MedecineViewModel vm)
        {
            MedecineCategory medecineCategory = _medecineCategoryService.GetMedecineCategoryModelById(vm.MedecineCategoryId);
            vm.MedecineCategory = medecineCategory;            

            _medecineService.InsertMedecine(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _medecineService.GetMedecineById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(MedecineViewModel vm)
        {
            _medecineService.UpdateMedecine(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _medecineService.DeleteMedecine(id);
            return RedirectToAction("Index");
        }




    }
}
