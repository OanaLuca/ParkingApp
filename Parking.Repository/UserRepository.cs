using Parking.Repository.Entity;
using Parking.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository
{
    public class UserRepository : Repository<UserEntity>
    {
        public UserEntity GetUserById(int id)
        {
           return GetById(id);
        }

        public List<UserEntity> GetAllUsers()
        {
            return GetAll();
        }

        public int InsertEntity (UserEntity userEntity)
        {
            return Insert(userEntity);
        }

        public void UpdateEntity(UserEntity userEntity)
        {
            Update(userEntity);
        }

        public bool DeleteEntity(int id)
        {
            return Detele(id);
        }
    }

}
