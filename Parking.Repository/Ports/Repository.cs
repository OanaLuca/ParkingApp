using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository.Ports
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly string connectionString;

        //public Repository() => connectionString = ConfigurationManager.ConnectionStrings["ParkingData1"].ConnectionString;
        public Repository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ParkingData1"].ConnectionString;
        }




        public bool Detele(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var entity = connection.Get<T>(id);

                connection.Delete<T>(entity);

                connection.Close();

                return true;

            }
        }

        public List<T> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var collection = connection.GetAll<T>();

                connection.Close();

                return collection.ToList();
                    
            }
        }

        public T GetById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var entityById = connection.Get<T>(id);

                connection.Close();

                return entityById;

            }
        }

        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
           
                var entityToInsertId = connection.Insert<T>(entity);

                connection.Close();
            
                return Convert.ToInt32(entityToInsertId);

            }
        }

        public void Update(T entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Update<T>(entity);

                connection.Close();

            }
        }
    }
}
