using Parking.DLL.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Repository.Entity;
using Parking.Repository;
using Parking.Core.Models;

namespace Parking.DLL
{
    public class UserService: IUserService
    {
        private readonly UserRepository _userRepository;

       public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public object GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void SaveUser(UserEntity user)
        {
            if (CheckAgeConstraint(user) == true)
            {
                if (user.ID == 0)
                {
                    _userRepository.InsertEntity(user);
                }
                else
                {
                    _userRepository.UpdateEntity(user);
                }
            }

        }

        public bool CheckAgeConstraint(UserEntity user)
        {
            if (user.Age < 18)
            {
                Console.WriteLine("Age must be >=18 , your account will not be created");
              
                return false;
            }
            return true;
        }

       

        public User GetUserEntityById(int id)
        {
            var userEntity = _userRepository.GetUserById(id);
                return ConvertToUser(userEntity);

        }

        
       

        public User ConvertToUser(UserEntity userEntity)
        {
            var user = new User();

            user.ID = userEntity.ID;
            user.LastName = userEntity.LastName;
            user.FirstName = userEntity.FirstName;
            user.BookingOk = userEntity.BookingOk;
            user.CarKey = userEntity.CarKey;
            user.Loyalty = userEntity.Loyalty;
            user.Punctuality = userEntity.Punctuality;

            return user;

        }

        public void Delete(UserEntity user)
        {
            if (user.ID != 0)
            {
                _userRepository.Detele(user.ID);
            }
            else
            {
                throw new Exception("Nothing to delete!");
            }
        }
    }
}
