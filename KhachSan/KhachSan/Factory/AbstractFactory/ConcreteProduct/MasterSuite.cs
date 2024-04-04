using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static KhachSan.Factory.AbstractFactor.Enumeretions;

namespace KhachSan.Factory.AbstractFactor
{
    public class MasterSuite : IRoomTypeServies
    {
        public string GetRoomServies()
        {
            return RoomTypeServies.MasterSuite.ToString();
        }
    }
}