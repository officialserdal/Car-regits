using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;
using System.Data.Entity;


namespace WebApplication7.Controllers
{
    public class RentController : Controller
    {
        supercarEntities db = new supercarEntities();
         
        // GET: Rent
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Getcar()
        {
            var car = db.carregs.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getid(int id)
        {
            var customer=(from s in db.customers where s.id==id select s.custname).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getavil(string carno)
        {
            var caravil = (from s in db.carregs where s.carno ==s.carno select s.available).FirstOrDefault();
            return Json(caravil, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(rentail rent)
        {
            if (ModelState.IsValid)
            {
                var car = db.carregs.SingleOrDefault(e => e.carno == rent.carid);
                if (car == null)
                {
                    // Eğer carid carregs tablosunda bulunmuyorsa
                    // Kullanıcıya bilgi verebilecek veya yönlendirebilecek bir view döndürebilirsiniz.
                    return HttpNotFound("CarNo is not valid");
                }

                db.rentails.Add(rent);

                // car.available değeri "no" olarak güncelleniyor.
                car.available = "no";
                db.Entry(car).State = EntityState.Modified;
               

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rent);
        }














    }
}