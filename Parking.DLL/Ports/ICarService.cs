using Parking.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DLL.Ports
{
    public interface ICarService
    {
        int SaveParkingSpot(CarEntity carEntity);
        string SaveCarAndGenerateCarKeyIfNull(CarEntity carEntity);
        void Delete(CarEntity car);
    }
}
