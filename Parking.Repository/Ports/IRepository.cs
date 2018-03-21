using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository.Ports
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        List<T> GetAll();

        int Insert(T entity);

        void Update(T entity);

        bool Detele(int id);

    }
}
