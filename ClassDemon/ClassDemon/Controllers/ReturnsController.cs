using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Configuration;
using ClassDemon.App_Start;
using ClassDemon.Models;

namespace ClassDemon.Controllers
{
    public class ReturnsController : Controller
    {
        private MongoDBContext dbContents;
        private IMongoCollection<ReturnsModel> ReturnsCollection;
        public ReturnsController()
        {
            dbContents = new MongoDBContext();
            ReturnsCollection = dbContents.database.GetCollection<ReturnsModel>("superReturns");
        }
        // GET: Returns
        public ActionResult Index()
        {
            List<ReturnsModel> returns = ReturnsCollection.AsQueryable<ReturnsModel>().ToList();
            return View(returns);
        }

        // GET: Returns/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Returns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Returns/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Returns/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Returns/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Returns/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Returns/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
