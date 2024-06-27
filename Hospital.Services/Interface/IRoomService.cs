using Hospital.Models;
using Hospital.Utility;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interface
{
    public interface IRoomService
    {
        PageResult<RoomViewModel> GetAll(int pageNumber, int pageSize);
        void InsertRoom(RoomViewModel roomViewModel);
        

    }
}
