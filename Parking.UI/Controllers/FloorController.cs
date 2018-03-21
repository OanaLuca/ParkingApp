using Parking.Core.Models;
using Parking.DLL;
using Parking.Repository.Entity;
using Parking.UI.Models.Floor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parking.Repository;

namespace Parking.UI.Controllers
{
    public class FloorController : Controller
    {
        
        //private readonly FloorService floorService;

        //public FloorController (FloorService service)
        //{
        //    floorService = service;
        //}


       private readonly FloorRepository floorEntity;

        //private readonly FloorService floorService;

        public FloorController(FloorRepository entity)
        {
            floorEntity = entity;
        }

        [HttpGet]
        public ActionResult FloorInfo(List<FloorModel> floorModelList)
        {
            FloorModel floorModel = new FloorModel();
            var bllFloorModel = ConvertToBLL(floorModel);
            var entityFloorModel = ConvertFromBLLToRepo(bllFloorModel);



            List<FloorModel> floorUIList = new List<FloorModel>();
            List<Floor> bllFloorList = floorUIList.ConvertAll(x => bllFloorModel);
            List<FloorEntity> repoFloorList = bllFloorList.ConvertAll(x => entityFloorModel);

         
            
                floorEntity.GetAllFloors();
            

            return View("FloorInfo",floorModelList);
        }




        #region Comments

        //private readonly string connectionString;

        //public FloorController() => connectionString = ConfigurationManager.ConnectionStrings["ParkingData1"].ConnectionString;

        // GET: Floor

        //private readonly string connectionString;

        //public FloorController() => connectionString = ConfigurationManager.ConnectionStrings["ParkingData1"].ConnectionString;


        //public ActionResult FloorInfo(FloorModel model)
        //{
        //    SqlConnection sqlConnection = new SqlConnection();
        //    string path = ConfigurationManager.ConnectionStrings["ParkingData1"].ConnectionString;
        //    sqlConnection.ConnectionString = path;

        //    String sql = "SELECT * FROM Floor";
        //    SqlCommand cmd = new SqlCommand(sql, (sqlConnection));



        //    using (var connection = new SqlConnection(path))
        //    {
        //        connection.Open();
        //        SqlDataReader sqlDataReader = cmd.ExecuteReader();



        //    }

        //    return View(model);


        //public ActionResult Students()
        //{
        //    String connectionString = "<THE CONNECTION STRING HERE>";
        //    String sql = "SELECT * FROM students";
        //    SqlCommand cmd = new SqlCommand(sql, conn);

        //    var model = new List<Student>();
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            var student = new Student();
        //            student.FirstName = rdr["FirstName"];
        //            student.LastName = rdr["LastName"];
        //            student.Class = rdr["Class"];
        //    ....

        //    model.Add(student);
        //        }

        //    }

        //    return View(model);


        //FloorModel floorModel = new FloorModel();
        //public ActionResult FloorInfo(int id=0)
        //{

        //    SqlConnection sqlConnection = new SqlConnection();
        //    string path = ConfigurationManager.ConnectionStrings["ParkingData1"].ConnectionString;
        //    sqlConnection.ConnectionString = path;

        //    DataTable dataTable = new DataTable();


        //    try
        //    {
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Floor", sqlConnection);
        //        sqlDataAdapter.Fill(dataTable);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Connection to SQL failed");
        //    }
        //    return View(dataTable);
        //}


        #endregion

        #region Private Methods
        private FloorEntity ConvertFromBLLToRepo(Floor floor)
        {
            var floorEntity = new FloorEntity();

            {
                floorEntity.BookedPlace = floor.BookedPlace;
                floorEntity.CountCarsParked = floor.CountCarsParked;
                floorEntity.CountEmptyPlaces = floor.CountEmptyPlaces;
                floorEntity.CountReservedPlaces = floor.CountReservedPlaces;
                floorEntity.FloorNumber = floor.FloorNumber;
                floorEntity.ID = floor.ID;
                floorEntity.NextEmptyPlace = floor.NextEmptyPlace;
            }


            return floorEntity;
        }


        private Floor ConvertToBLL(FloorModel floorModel)
        {
            var bllModel = new Floor();

            {
                bllModel.BookedPlace = floorModel.BookedPlace;
                bllModel.CountCarsParked = floorModel.CountCarsParked;
                bllModel.CountEmptyPlaces = floorModel.CountEmptyPlaces;
                bllModel.CountReservedPlaces = floorModel.CountReservedPlaces;
                bllModel.FloorNumber = floorModel.FloorNumber;
                bllModel.ID = floorModel.ID;
                bllModel.NextEmptyPlace = floorModel.NextEmptyPlace;
            }

            return bllModel;

        }

#endregion
    }
}