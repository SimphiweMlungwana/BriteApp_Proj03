using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassDemon.App_Start;
using ClassDemon.Controllers;
using ClassDemon.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using PagedList;

namespace ClassDemon.Controllers
{
    public class OrdersController : Controller
    {
        private MongoDBContext dbContents;
        private IMongoCollection<OrderModel> ordersCollection;

        public OrdersController()
        {
            dbContents = new MongoDBContext();
            ordersCollection = dbContents.database.GetCollection<OrderModel>("superOrders");
        }
        // GET: Orders
        public ActionResult Index(int? pageNumber)
        {
            var orders = ordersCollection.AsQueryable<OrderModel>().ToList();


            return View(orders.ToPagedList(pageNumber ?? 1, 20));
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            var ordersId = new ObjectId(id);
            var orders = ordersCollection.AsQueryable<OrderModel>().SingleOrDefault(x => x.Id == ordersId);
            return View(orders);
        }

        //Return Visuals
        public ActionResult DataVisuals()
        {
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(OrderModel orders)
        {
            try
            {
                ordersCollection.InsertOne(orders);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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
