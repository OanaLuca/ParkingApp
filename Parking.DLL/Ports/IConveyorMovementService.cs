using Parking.Core.Models;
using Parking.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DLL.Ports
{
    public interface IConveyorMovementService
    {
        void Save(ConveyorArmsEntity conveyorArmsEntity);
        void Delete(ConveyorArmsEntity conveyorArmsEntity);
        object GetConveyorArmsById(int id);
        List<ConveyorArms> GetListOFAllConveyorArms();
    }
}
