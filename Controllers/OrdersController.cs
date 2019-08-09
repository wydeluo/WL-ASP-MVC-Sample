using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WlBhcApp.Models;
using PagedList;

namespace WlBhcApp.Controllers
{
    public class OrdersController : Controller
    {
        private WlBhcDB db = new WlBhcDB();

        // GET: Orders
        [Authorize]
        public ActionResult Index(int? pageNo = null)
        {
            pageNo = pageNo ?? 1;
            pageNo = pageNo.Value < 1 ? 1 : pageNo.Value;
          
            var orders = db.Order.Include(o => o.customer).Include(p=>p.product).OrderBy(t=>t.ID);
            return View(orders.ToPagedList(pageNo.Value, 5));
        }

        [HttpGet]
        public ActionResult GetProduct(int ProdID)
        {
            var prod = db.Products.FirstOrDefault(p => p.ID == ProdID);
            if (prod != null)
            {
                ViewData["ProdPrice"] = prod.Price;
            }
            return PartialView("_product",prod);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Include(o => o.customer).Include(p => p.product).FirstOrDefault(t => t.ID == id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
           ViewData["PRODS"]= db.Products.OrderBy(p=>p.ID).ToList();
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Firstname");
          
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Quantity,OrderPrice")] Order order, [Bind(Include = "Firstname,MiddleName,Lastname,EmailAddress,Phone,Address1,Address2,City,State,ZipCode")] Customer customer, int ProductID, double OrderPrice)
        {
            if (TryValidateModel(customer)&& TryValidateModel(order))
            {
                order.ProductID = ProductID;
                var pd = db.Products.Where(p => p.ID == ProductID).FirstOrDefault();
                db.Customers.Add(customer);
                db.SaveChanges();
                order.CustomerID = customer.ID;
                order.OrderedDate = DateTime.Now;
                //if (pd != null)
                    order.OrderPrice = OrderPrice;
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction($"Details/{order.ID}");
            }

            return RedirectToAction("Create");
        }

        // GET: Orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Order.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Firstname", order.CustomerID);
        //    return View(order);
        //}

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,CustomerID,ProdID,Quantity,OrderPrice,OrderedDate")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Firstname", order.CustomerID);
        //    return View(order);
        //}

        // GET: Orders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Order.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        // POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = db.Order.Find(id);
        //    db.Order.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
