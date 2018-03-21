using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Core.Models;
using Parking.Repository.Entity;
using Parking.Repository;
using AutoMapper;

namespace Parking.DLL.Ports
{
    public class ConveyorMovementService : IConveyorMovementService
    {

        private readonly ConveyorArmsRepository _conveyorArmsRepository;

        public ConveyorMovementService(ConveyorArmsRepository conveyorArmsRepository)
        {
            _conveyorArmsRepository = conveyorArmsRepository;
        }

        public object GetConveyorArmsById(int id)
        {
            return _conveyorArmsRepository.GetConveyorArmsById(id);
        }

        public List<ConveyorArms> GetListOFAllConveyorArms()
        {
            var conveyorArmsList = new List<ConveyorArms>();
            var conveyorArmsEntityList = _conveyorArmsRepository.GetAllConveyorArms();
            conveyorArmsList = Mapper.Map<List<ConveyorArms>>(conveyorArmsEntityList);


            return conveyorArmsList;
        }


        public void Delete(ConveyorArmsEntity conveyorArmsEntity)
        {
            if(conveyorArmsEntity.ID !=0)
            {
                _conveyorArmsRepository.DeleteConveyorArmsEntity(conveyorArmsEntity.ID);

            }

            else
            {
                throw new Exception("Nothing to delete!");
            }
        }



        public void Save(ConveyorArmsEntity conveyorArmsEntity)
        {
            if (conveyorArmsEntity.Busy == false && conveyorArmsEntity.ID == 0)
            {
                _conveyorArmsRepository.InsertConveyorArmsEntity(conveyorArmsEntity);
            }
            else
            {
                _conveyorArmsRepository.UpdateConveyorArmsEntity(conveyorArmsEntity);

            }
        }

        public ConveyorArms ConvertToConveyorArms (ConveyorArmsEntity conveyorArmsEntity)
        {
            var conveyorArms = new ConveyorArms();

            conveyorArms.Busy = conveyorArmsEntity.Busy;
            conveyorArms.CarKeyTransported = conveyorArmsEntity.CarKeyTransported;
            conveyorArms.ID = conveyorArmsEntity.ID;
            conveyorArms.Position = conveyorArmsEntity.Position;
            conveyorArms.WhichOne = conveyorArmsEntity.WhichOne;
            

            return conveyorArms;
        }

    }
}
