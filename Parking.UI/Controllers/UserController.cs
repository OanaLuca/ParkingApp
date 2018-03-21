using Parking.Core.Models;
using Parking.DLL;
using Parking.Repository;
using Parking.Repository.Entity;
using Parking.UI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parking.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly UserService userServiceModel;


        public UserController(UserService userService)
        {
            userServiceModel = userService;
        }

       

        // GET: User
        [HttpGet]
        public ActionResult CreateAccount(int id =0)
        {
            UserModel userModel = new UserModel();
            return View(userModel);
        }

       [HttpPost]
       public ActionResult CreateAccount(UserModel userModel)
        {
            UserModel model = new UserModel();
            if (ModelState.IsValid)
            {
                var bllUser = ConvertToBLL(userModel);
                var entityUser = ConvertFromBLLToRepo(bllUser);


                 userServiceModel.SaveUser(entityUser);


                ViewBag.SuccessMessage = "Logged IN";
                return View("LogIn", new UserModel());
            }

            else
                ViewBag.ErrorMessage = "Failed";
            return View("LogIn", new UserModel());
        }


       

        public ActionResult UserInfo(UserModel model)
        {
            return View();
        }


        #region Private Methods


        private UserEntity ConvertFromBLLToRepo(User userBll)
        {
            var repoUser = new UserEntity();

            {
                repoUser.Age = userBll.Age;
                repoUser.BookingOk = userBll.BookingOk;
                repoUser.CarKey = userBll.CarKey;
                repoUser.FirstName = userBll.FirstName;
                repoUser.ID = userBll.ID;
                repoUser.LastName = userBll.LastName;
                repoUser.Loyalty = userBll.Loyalty;
                repoUser.Punctuality = userBll.Punctuality;
            
            }

            return repoUser;
        }



        private User ConvertToBLL(UserModel model)
        {
            var bllModel = new User();

            {
                bllModel.Punctuality = model.Punctuality;
                bllModel.Loyalty = model.Loyalty;
                bllModel.ID = model.ID;
                bllModel.FirstName = model.FirstName;
                bllModel.LastName = model.LastName;
                bllModel.Age = model.Age;
                bllModel.BookingOk = model.BookingOk;
                bllModel.CarKey = model.CarKey;


            }

            return bllModel;

        }
    }

    #endregion
}
