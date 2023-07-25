using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; 
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class returncarController : Controller
    {
        supercarEntities db = new supercarEntities();

        // GET: returncar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(returncar recar)
        {

            if (ModelState.IsValid)
            {
                db.returncars.Add(recar);
                var car= db.carregs.SingleOrDefault(e => e.carno == recar.carno);
                if (car==null)
                {
                    return HttpNotFound("CarNo not found");
                    car.available = "yes";
                    db.Entry(car).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }





            return View();
        }









        [HttpPost] 
        public ActionResult Getid(string carno)
        {
            var carn = (from s in db.rentails
                        where s.carid == carno
                        select new
                        {
                            StartDate = s.sdate,
                            EndDate = s.edate,
                            CustId = s.custid,
                            Fee = s.fee,
                            ElapsedDays = DbFunctions.DiffDays(s.sdate, s.edate) 
                        }).ToArray();

            return Json(carn, JsonRequestBehavior.AllowGet);
        }
    }
}
