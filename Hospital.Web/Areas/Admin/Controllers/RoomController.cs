using Hospital.Models;
using Hospital.Services.Interface;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomController : Controller
    {
        IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService=roomService;
            
        }
        public IActionResult List(int pageNumber = 1, int pageSize = 10)
        {
            return View(_roomService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RoomViewModel vm)
        {

            _roomService.InsertRoom(vm);
            return RedirectToAction("List");
        }
    }
}
