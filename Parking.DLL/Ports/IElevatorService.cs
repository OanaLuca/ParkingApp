using Parking.Core.Models;
using Parking.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DLL.Ports
{
    public interface IElevatorService
    {
        void Save(ElevatorEntity elevator);
        void Delete(ElevatorEntity elevator);
        object GetElevatorById(int id);
       List<Elevator> GetListOFAllElevator();
    }
}
