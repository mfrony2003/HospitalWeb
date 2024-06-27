using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hospital.ViewModel
{
    public class RoomViewModel
    {

        public int Id { get; set; }
        public string RoomNumber { get; set; }

        public RoomViewModel()
        {
            
        }

        public RoomViewModel(Room model)
        {
            this.Id = model.Id;
            RoomNumber=model.RoomNumber;
        }

        public Room ConvertViewModel(RoomViewModel model)
        {
            return new Room
            {
                Id= model.Id,
               RoomNumber=model.RoomNumber,

            };
        }
    }
}
