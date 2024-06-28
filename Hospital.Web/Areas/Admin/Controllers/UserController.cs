using Hospital.Models;
using Hospital.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IApplicationUserService _userService;

        public UserController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_userService.GetAll(pageNumber, pageSize));
        }

        public IActionResult AllDoctor(int pageNumber = 1, int pageSize = 10)
        {
            return View(_userService.GetAllDoctor(pageNumber, pageSize));
        }

        public IActionResult AllPatient(int pageNumber = 1, int pageSize = 10)
        {
            return View(_userService.GetAllPatient(pageNumber, pageSize));
        }
        public IActionResult Login()
        {
            return View("Identity/Account/Login");
        }
        
    }
}
