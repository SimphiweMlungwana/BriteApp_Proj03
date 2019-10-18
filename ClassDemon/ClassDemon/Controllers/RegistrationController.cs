using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Auth;
using Google.Authenticator;
using ClassDemon.App_Start;
using ClassDemon.Models;
using MongoDB.Driver;

namespace ClassDemon.Controllers
{
    public class RegistrationController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<UserModel> userCollection;
        public List<UserModel> userList;
        public RegistrationController()
        {
            dBContext = new MongoDBContext();
            userCollection = dBContext.database.GetCollection<UserModel>("superUsers");
        }

        string key = "truebright@1";
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel users)
        {
            userList = userCollection.AsQueryable<UserModel>().ToList();
            var userdet = (from a in userList select a.email).ToList();
            string msg = "";
            try
            {
                if(users.password !=users.conPassword)
                {
                    msg = "Passowords do not match";
                    ViewBag.Message = msg;
                    return View();
                }
                else if(userdet.Contains(users.email))
                {
                    msg = "User Already exist";
                    return View();
                }
                else
                {
                    userCollection.InsertOne(users);
                    return RedirectToAction("Home", "../Home/Index");
                }
                return RedirectToAction("Login", "../Login/Login");
            }catch
            {
                return View();
            }
            return View();
        }
    }
}