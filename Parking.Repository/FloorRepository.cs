using Parking.Repository.Entity;
using Parking.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository
{
   public class FloorRepository : Repository <FloorEntity>
    {
        public FloorEntity GetFloorById(int id)
        {
            return GetById(id);
        }

        public List<FloorEntity> GetAllFloors()
        {
            return GetAll();
        }

        public int InsertFloorEntity(FloorEntity floorEntity)
        {
            return Insert(floorEntity);
        }

        public void UpdateFloorEntity(FloorEntity floorEntity)
        {
            Update(floorEntity);
        }

        public bool DeleteFloorEntity(int id)
        {
            return Detele(id);
        }
    }
}

