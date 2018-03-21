using Parking.DLL.Ports;
using Parking.Repository;
using System;
using Parking.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Repository.Entity;

namespace Parking.DLL
{
    public class CarService : ICarService
    {

        private readonly CarRepository _carRepository;

        public CarService(CarRepository carRepository)
        {
            _carRepository = carRepository;

        }

        public Car GetCarEntityById(int id)
        {
            var carEntity = _carRepository.GetCarById(id);
            return ConvertToCar(carEntity);

        }


        public Car ConvertToCar(CarEntity carEntity)
        {
            var car = new Car();
            car.ID = carEntity.ID;
            car.CarKey = carEntity.CarKey;
            car.FloorParked = carEntity.FloorParked;
            car.UserId = carEntity.UserId;
            car.ParkingTime = carEntity.ParkingTime;
            return car;
        }

        public string SaveCarAndGenerateCarKeyIfNull(CarEntity carEntity)
        {
            if (carEntity.ID == 0)
            {
                _carRepository.Insert(carEntity);
            }
            return carEntity.CarKey;
        }


        public int SaveParkingSpot(CarEntity carEntity)
        {
            var carModel = ConvertToCar(carEntity);
            return carModel.FloorParked;
        }

        public void Delete(CarEntity car)
        {
            if (car.ID != 0)
            {
                _carRepository.Detele(car.ID);
            }
            else
            {
                throw new Exception("Nothing to delete!");
            }

        }
    }

}
