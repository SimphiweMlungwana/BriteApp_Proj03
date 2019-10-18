using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using ClassDemon.Models;
using ClassDemon.App_Start;
using ClassDemon.ViewModels;
using MongoDB.Bson;

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
            peopleCollection = dBContext.database.GetCollection<people>("superPeople");
        }

        public ActionResult Index()
        {
            List<people> mypeople = peopleCollection.AsQueryable<people>().ToList();


            //int totalAfrica = (from x in mypeople.Where(x => x.Region.Contains("Africa")) select x.Region).Count();
            //int numEuro = (from x in mypeople.Where(x => x.Region.Contains("Europe")) select x.Region).Count();
            //int numAsia = (from w in mypeople.Where(y => y.Region.Contains("Asia")) select w.Region).Count();
            //int numOceania = (from x in mypeople.Where(x => x.Region.Contains("Oceania")) select x.Region).Count();
            //int numUS = (from w in mypeople.Where(y => y.Region.Contains("US")) select w.Region).Count();

            //viewppl.Africa_count = totalAfrica;
            //viewppl.Asia_count = numAsia;
            //viewppl.Europe_count = numEuro;
            //viewppl.Oceania_count = numOceania;
            //viewppl.USA_count = numUS;

            return View(mypeople);
        }
        public ActionResult Details(string Id)
        {
            var productId = new ObjectId(Id);
            var product = peopleCollection.AsQueryable<people>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(people ppl)
        {
            try
            {
                peopleCollection.InsertOne(ppl);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var productId = new ObjectId(id);
            var product = peopleCollection.AsQueryable<people>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }

        [HttpPost]
        //public ActionResult Edit(string id, people ppl)
        //{
        //    try
        //    {
        //        var filter = Builders<people>.Filter.Eq("_id", ObjectId.Parse(id));
        //        var update = Builders<people>.Update
        //            .Set("ProductName", ppl.ProductName)
        //            .Set("ProductDescription", ppl.ProductDescription)
        //            .Set("Quantity", product.Quantity);
        //        var result = productCollection.UpdateOne(filter, update);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Delete (string id)
        {
            var productId = new ObjectId(id);
            var product = peopleCollection.AsQueryable<people>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(string id, people ppl)
        {
            try
            {
                peopleCollection.DeleteOne(Builders<people>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
}