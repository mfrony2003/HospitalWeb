using Hospital.Models;
using Hospital.Services.Interface;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MedecineController : Controller
    {
        IMedecineService _medecineService;

        public MedecineController(IMedecineService medecineService)
        {
            _medecineService = medecineService;
        }
        public IActionResult MedecineList(int pageNumber = 1, int pageSize = 10)
        {
            return View(_medecineService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult AddMedecine()
        {
            return View();
        }
        
        

        public IActionResult AddMedecine(MedecineViewModel vm)
        {
            _medecineService.InsertMedecineInfo(vm);
            return RedirectToAction("MedecineList");
        }
        [HttpGet]
        public IActionResult EditMedecine(int id)
        {
            var viewModel = _medecineService.GetMedecineById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditMedecine(MedecineViewModel vm)
        {
            _medecineService.UpdateMedecineInfo(vm);
            return RedirectToAction("MedecineList");
        }

        public IActionResult DeleteMedecine(int id)
        {
            _medecineService.DeleteMedecineInfo(id);
            return RedirectToAction("MedecineList");
        }




    }
}
