using Parking.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DLL.Ports
{
     public interface IUserService
    {
        void SaveUser(UserEntity user);
        void Delete(UserEntity user);
        
    }
}
