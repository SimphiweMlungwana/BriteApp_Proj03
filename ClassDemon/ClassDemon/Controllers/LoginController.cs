using Google.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ClassDemon.Models;
using ClassDemon.App_Start;
using MongoDB.Driver;

namespace ClassDemon.Controllers
{
    public class LoginController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<UserModel> userCollection;
        public List<UserModel> userList;
        public LoginController()
        {
            dBContext = new MongoDBContext();
            userCollection = dBContext.database.GetCollection<UserModel>("superUsers");
        }

        string key = "truebright@1";
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel users)
        {
            userList = userCollection.AsQueryable<UserModel>().ToList();
            var userdet = userList.Where(x => x.email == users.email && x.password == users.password).FirstOrDefault();
            bool status = false;
            string msg = "";

            if (userdet!=null)
            {
                status = true;
                msg = "MFA User Authentication";
                Session["Username"] = userdet.email;

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                string useruniqueKey = userdet.email + key;
                Session["UserUniquekey"] = useruniqueKey;

                var setupInfo = tfa.GenerateSetupCode("MFA Auth", userdet.email, useruniqueKey, 300, 300);
                ViewBag.BarcodeImageUrl = setupInfo.QrCodeSetupImageUrl;
                ViewBag.SetupCode = setupInfo.ManualEntryKey;
            }
            else
            {
                msg = "Invalid login Details!";
            }
            ViewBag.Message = msg;
            ViewBag.Status = status;

            return View();
        }
        
        public ActionResult VerifyAuth()
        {
            var token = Request["passcode"];
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            string UserUniqueKey = Session["UserUniqueKey"].ToString();
            bool isValid = tfa.ValidateTwoFactorPIN(UserUniqueKey, token);
            if(isValid)
            {
                Session["IsValid2FA"] = true;
                return RedirectToAction("Index", "../Home/Index");
            }
            return RedirectToAction("Login", "Login");
        }
        
        [HttpPost]
        public ActionResult VerifyAuth(UserModel users)
        {
            var token = Request["passcode"];
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            string UserUniqueKey = Session["UserUniqueKey"].ToString();
            bool isValid = tfa.ValidateTwoFactorPIN(UserUniqueKey, token);
            if (isValid)
            {
                Session["IsValid2FA"] = true;
                return RedirectToAction("Index", "../Home/Index");
            }
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Myprofile()
        {
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}