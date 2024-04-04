using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachSan.Factory.AbstractFactor
{
    public interface IRoomFactory
    {
        IRoomTypeServiesPrice RoomTypeServiesPrice();
        IRoomTypeServies RoomTypeServies();
        IRoomType RoomType();

    }
}
