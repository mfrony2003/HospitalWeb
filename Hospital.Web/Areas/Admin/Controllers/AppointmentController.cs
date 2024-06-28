using Hospital.Models;
using Hospital.Services.Interface;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        IAppoinmentService _appointmentService;
        IApplicationUserService _applicationUsertService;
        private readonly UserManager<IdentityUser> _userManager;
        public AppointmentController(IAppoinmentService appointmentService, IApplicationUserService applicationUsertService, UserManager<IdentityUser> userManager)
        {
            _appointmentService = appointmentService;
            _applicationUsertService = applicationUsertService;
            _userManager = userManager;
        }
        public IActionResult List(int pageNumber = 1, int pageSize = 10)
        {
            var user = _userManager.GetUserId(HttpContext.User);
            if (user != null)
            {
                var loggedInUserId = new Guid((user));
                var logginDoctor = _applicationUsertService.GetDoctorById(loggedInUserId);

                return View(_appointmentService.GetAppointmentBylDoctor(pageNumber, pageSize, logginDoctor));
            }
            else
            {
                return View(_appointmentService.GetAll(pageNumber, pageSize));
            }
        }

        [HttpGet]
        public IActionResult AddAppointment()
        {
            AppointmentViewModel viewModel = new AppointmentViewModel
            {
                AllDoctor = _applicationUsertService.GetAllDoctor(),
                AllPatient = _applicationUsertService.GetAllPatient()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AppointmentViewModel vm)
        {
             ApplicationUser doctor= _applicationUsertService.GetDoctorById(vm.DoctorId);
            ApplicationUser patient = _applicationUsertService.GetPatientById(vm.PatientId);
            vm.Doctor = doctor;
            vm.Patient = patient;
            _appointmentService.InsertAppointment(vm);
            return RedirectToAction("List");
        }
    }
}
