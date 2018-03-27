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
        
   

        public ActionResult PopulateData()
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings["ParkingData1"].ConnectionString;
            con.ConnectionString = path;

            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select FloorNumber, CountCarsParked,CountEmptyPlaces,CountReservedPlaces,NextEmplyPlace,BookedPlace from Floor",con);
                adapter.Fill(dt);
            }

            catch(Exception)
            {
                throw;

            }

            return View(dt);
        }


    }
}