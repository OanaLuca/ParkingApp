using Parking.DLL.Ports;
using Parking.Repository;
using Parking.Repository.Entity;
using Parking.Core.Models;
using System;
using System.Collections.Generic;
using Parking.DLL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Parking.DLL
{
    public class FloorService : BookingAndFloor, IFloorService
    {

        private readonly FloorRepository _floorRepository;

        public FloorService(FloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

      


        public Floor ConvertToFloor(FloorEntity floorEntity)
        {
            
            var floor = new Floor();

            floor.ID = floorEntity.ID;
            floor.NextEmptyPlace = floorEntity.NextEmptyPlace;
            floor.BookedPlace = floorEntity.BookedPlace;
            floor.CountCarsParked = floorEntity.CountCarsParked;
            floor.CountEmptyPlaces = floorEntity.CountEmptyPlaces;
            floor.CountReservedPlaces = floorEntity.CountReservedPlaces;
            floor.FloorNumber = floorEntity.FloorNumber;


            return floor;

        }

        public object GetFloorById(int id)
        {
            return _floorRepository.GetFloorById(id);
        }

        public List<Floor> GetListOFAllFloors()
        {
            var floorList = new List<Floor>();
            var floorEntityList = _floorRepository.GetAllFloors();
            floorList = Mapper.Map<List<Floor>>(floorEntityList);




            return floorList;
        }


        public void SaveFloor(FloorEntity floorEntity)
        {
            BookingEntity booking = new BookingEntity();
            CarEntity car = new CarEntity();
            if ((ParkingPlaceAvailabe(floorEntity, booking) == true) && floorEntity.ID == 0 && floorEntity.BookedPlace == "empty")
            {

                _floorRepository.Insert(floorEntity);
            }
            else
            if (CheckBookingNo(booking, car) == true)
            {

                _floorRepository.Update(floorEntity);
            }
        }

 

        public void Delete(FloorEntity floor)
        {
            if (floor.ID != 0)
            {
                _floorRepository.Detele(floor.ID);
            }
            else
            {
                throw new Exception("Nothing to delete!");
            }

        }
    }
}
