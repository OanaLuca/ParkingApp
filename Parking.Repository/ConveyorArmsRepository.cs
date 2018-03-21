using Parking.Repository.Entity;
using Parking.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository
{
    public class ConveyorArmsRepository : Repository<ConveyorArmsEntity>
    {
        public ConveyorArmsEntity GetConveyorArmsById(int id)
        {
            return GetById(id);
        }

        public List<ConveyorArmsEntity> GetAllConveyorArms()
        {
            return GetAll();
        }

        public int InsertConveyorArmsEntity(ConveyorArmsEntity conveyorArmsEntity)
        {
            return Insert(conveyorArmsEntity);
        }

        public void UpdateConveyorArmsEntity(ConveyorArmsEntity conveyorArmsEntity)
        {
            Update(conveyorArmsEntity);
        }

        public bool DeleteConveyorArmsEntity(int id)
        {
            return Detele(id);
        }
    }

}
