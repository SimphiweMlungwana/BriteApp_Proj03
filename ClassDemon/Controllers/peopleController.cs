using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using ClassDemon.Models;
using ClassDemon.App_Start;
using ClassDemon.ViewModels;

namespace ClassDemon.Controllers
{
    public class peopleController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<people> peopleCollection;
        peopleViewModel viewppl = new peopleViewModel();


        // GET: people
        public peopleController()
        {
            dBContext = new MongoDBContext();
            peopleCollection = dBContext.database.GetCollection<people>("peoplereview");
        }

        public ActionResult Index()
        {
            List<people> mypeople = peopleCollection.AsQueryable<people>().ToList();


            int totalAfrica = (from x in mypeople.Where(x => x.Region.Contains("Africa")) select x.Person).Count();

            viewppl.Africa_count = totalAfrica;

            return View(viewppl);
        }
    }
}