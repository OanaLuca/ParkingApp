using Parking.Repository.Entity;
using Parking.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository
{
   public class CarRepository :Repository <CarEntity>
    {
        public CarEntity GetCarById(int id)
        {
            return GetById(id);
        }

        public List<CarEntity> GetAllCars()
        {
            return GetAll();
        }

        public int InsertCarEntity(CarEntity carEntity)
        {
            return Insert(carEntity);
        }

        public void UpdateCarEntity(CarEntity carEntity)
        {
            Update(carEntity);
        }

        public bool DeleteCarEntity(int id)
        {
            return Detele(id);
        }
    }
}
