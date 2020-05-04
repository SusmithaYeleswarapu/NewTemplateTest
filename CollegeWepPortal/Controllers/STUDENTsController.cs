using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeWepPortal.Models;

namespace CollegeWepPortal.Controllers
{
    public class STUDENTsController : Controller
    {
        private Model1 db = new Model1();

        // GET: STUDENTs
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Authorize(CollegeWepPortal.Models.STUDENT datum, FormCollection fc)
        {
            var data = fc["Role"];
            using (Model1 db = new Model1())
            {

                var userdetails = db.STUDENTs.Where(x => x.StudentID == datum.StudentID && x.Password == datum.Password && x.Role == datum.Role).FirstOrDefault();
                if (userdetails == null && data == "User")
                {
                    ModelState.AddModelError(string.Empty, "Incorrect n User LoginDetails Details");
                    return View("Index", datum);
                }
                else if (userdetails == null && data == "Admin")
                {
                    ModelState.AddModelError(string.Empty, "Incorrect Admin LoginDetails Details");
                    return View("Index", datum);
                }
                else if (data == "User")
                {
                    return RedirectToAction("HomePageUser");

                }

                else
                {
                    return RedirectToAction("HomePageAdmin");
                }

            }

        }

        public ActionResult HomePageUser()
        {
            return View();
        }

        public ActionResult HomePageAdmin()
        {
            return View();
        }

        public ActionResult Search(string Searching)
        {
            int id;
            if (int.TryParse(Searching, out id))
            {

                return View(db.STUDENTs.Where(x => x.StudentID == id && x.deleted == 0 && x.Role == "User" || x.Age == id && x.deleted == 0 && x.Role == "User" || Searching == null).ToList());
            }

            else
            {
                return View(db.STUDENTs.Where(x => x.StudentName.StartsWith(Searching) && x.deleted == 0 && x.Role.StartsWith("User") || x.Department.StartsWith(Searching) && x.deleted == 0 && x.Role.Contains("User") || Searching == null).ToList());

            }
        }

        public ActionResult SearchAdmin(string Searching)
        {
            int id;
            if (int.TryParse(Searching, out id))
            {

                return View(db.STUDENTs.Where(x => x.StudentID == id && x.deleted == 0 && x.Role.StartsWith("User") || x.Age == id && x.deleted == 0 && x.Role.StartsWith("User") || Searching == null).ToList());
            }
            else
            {
                return View(db.STUDENTs.Where(x => x.StudentName.StartsWith(Searching) && x.deleted == 0 && x.Role.StartsWith("User") || x.Department.StartsWith(Searching) && x.deleted == 0 && x.Role.Contains("User") || Searching == null).ToList());

            }
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: STUDENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentName,Department,Age,deleted,Password,Role")] STUDENT sTUDENT)
        {
            if (ModelState.IsValid)
            {
                sTUDENT.deleted = 0;
                sTUDENT.Role = "User";
                db.STUDENTs.Add(sTUDENT);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(sTUDENT);
        }

        public ActionResult Edit([Bind(Include = "StudentName,Department,Age,deleted,Password,Role")] STUDENT sTUDENT,int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENTs = db.STUDENTs.Find(id);
            if (sTUDENTs == null)
            {
                return HttpNotFound();
            }



            return View();
        }

        //// POST: STUDENTs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentName,Department,Age,,deleted,Password,Role")] STUDENT sTUDENT)
        {
            if (ModelState.IsValid)
            {

                db.Entry(sTUDENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SearchAdmin");
            }
            return View(sTUDENT);
        }

        // GET: STUDENTs/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENTs.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }

            else
            {
                sTUDENT.deleted = 1;

                db.SaveChanges();
            }
            return RedirectToAction("SearchAdmin");
        }

        public ActionResult History()
        {
            return View(db.STUDENTs.ToList());
        }

        public ActionResult Restore(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENTs.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            else
            {
                sTUDENT.deleted = 0;

                db.SaveChanges();
            }
            return RedirectToAction("History");
        }

        public ActionResult LogOut()
        {

            Session.Abandon();
            return RedirectToAction("Index");
        }

        // GET: STUDENTs/Details/5
    }    
}
