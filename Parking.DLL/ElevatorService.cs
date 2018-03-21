using Parking.DLL.Ports;
using Parking.Repository.Entity;
using System;
using Parking.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Core.Models;
using AutoMapper;

namespace Parking.DLL
{
    public class ElevatorService : IElevatorService
    {
        private int totalNumberOfCars =  12;
        private readonly ElevatorRepository _elevatorRepository;

        public ElevatorService(ElevatorRepository elevatorRepository)
        {
            _elevatorRepository = elevatorRepository;
        }

        
        public void Delete(ElevatorEntity elevator)
        {
            if (elevator.ID != 0 && elevator.CarKey==null)
            {
                _elevatorRepository.Detele(elevator.ID);
            }
            else
            {
                throw new Exception("Nothing to delete!");
            }

        }
        public object GetElevatorById(int id)
        {
            return _elevatorRepository.GetElevatorById(id);
        }

        public List<Elevator> GetListOFAllElevator()
        {
            var elevatorList = new List<Elevator>();
            var elevatorEntityList = _elevatorRepository.GetAllElevators();
            elevatorList = Mapper.Map<List<Elevator>>(elevatorEntityList);

            
            return elevatorList;
        }

        public int GetNumberOfCarsOnElevator()
        {
            var listofElevator = GetListOFAllElevator();
            int numberOfCarsOnElevator = listofElevator.Count;
            return numberOfCarsOnElevator;
        }

        public void Save(ElevatorEntity elevator)
        {
            if(elevator.PaymentVerification == true && GetNumberOfCarsOnElevator()<totalNumberOfCars &&elevator.Availabe== true)
            {
                if (elevator.ID == 0)
                {
                    _elevatorRepository.InsertElevatorEntity(elevator);
                }
                else
                    _elevatorRepository.UpdateElevatorEntity(elevator);
            }
        }


        public Elevator ConvertToElevator(ElevatorEntity elevatorEntity)
        {
            var elevator = new Elevator();

            elevator.BroughtHere = elevatorEntity.BroughtHere;
            elevator.CarKey = elevatorEntity.CarKey;
            elevator.CountCars = elevatorEntity.CountCars;
            elevator.ElevatorNumber = elevatorEntity.ElevatorNumber;
            elevator.ID = elevatorEntity.ID;
            elevator.PaymentVerification = elevatorEntity.PaymentVerification;
            elevator.Available = elevatorEntity.Availabe;
            elevator.TimeSpent = elevatorEntity.TimeSpent;
            return elevator;
        }

    }
}
