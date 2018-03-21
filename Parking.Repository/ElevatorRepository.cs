using Parking.Repository.Entity;
using Parking.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository
{
   public class ElevatorRepository : Repository <ElevatorEntity>
    {
        public ElevatorEntity GetElevatorById(int id)
        {
            return GetById(id);
        }

        public List<ElevatorEntity> GetAllElevators()
        {
            return GetAll();
        }

        public int InsertElevatorEntity(ElevatorEntity elevatorEntity)
        {
            return Insert(elevatorEntity);
        }

        public void UpdateElevatorEntity(ElevatorEntity elevatorEntity)
        {
            Update(elevatorEntity);
        }

        public bool DeleteElevatorEntity(int id)
        {
            return Detele(id);
        }
    }
}
