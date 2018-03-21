using Parking.Core.Models;
using Parking.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DLL.Ports
{
    public interface IFloorService
    {
        void SaveFloor(FloorEntity floor);
        object GetFloorById(int id);
        List<Floor> GetListOFAllFloors();
        void Delete(FloorEntity floor);

    }
}
