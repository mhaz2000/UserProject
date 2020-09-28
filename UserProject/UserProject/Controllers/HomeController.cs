using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace UserProject.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository Repository;
        private string SearchValue="";
        public HomeController()
        {
            Repository = new UserRepository();
        }

        // GET: Home
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(SearchValue))
                return View(Repository.GetAllUsers());
            else
                return View(Repository.GetUsersByNameOrNatinaolCode(SearchValue));
        }

        // GET: Home/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = Repository.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,Family,Phone,NationalCode,ArrivalHour,ArrivalDate")] User user)
        {
            if (ModelState.IsValid)
            {
                user.ArrivalTime = TimeSetting.SetTime(user.ArrivalHour,user.ArrivalDate);
                user.ExitTime = null;
                user.UserID = Guid.NewGuid();
                Repository.AddUser(user);
                Repository.Save();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Exit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = Repository.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Exit([Bind(Include = "UserID,Name,Family,Phone,NationalCode,ArrivalTime,ExitHour,ExitDate")] User user)
        {
            if (ModelState.IsValid)
            {
                user.ExitTime = TimeSetting.SetTime(user.ExitHour, user.ExitDate);
                user.WorkingTime = TimeSetting.SetWorkingTime(user.ArrivalTime.Value, user.ExitTime.Value);
                Repository.UpdateUser(user);
                Repository.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        //Home/Edit
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = Repository.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,Family,Phone,NationalCode,ArrivalHour,ArrivalDate,ExitHour,ExitDate")] User user)
        {
            if (ModelState.IsValid)
            {
                user.ArrivalTime = TimeSetting.SetTime(user.ArrivalHour, user.ArrivalDate);
                user.ExitTime = TimeSetting.SetTime(user.ExitHour, user.ExitDate);
                user.WorkingTime = TimeSetting.SetWorkingTime(user.ArrivalTime.Value, user.ExitTime.Value);


                Repository.UpdateUser(user);
                Repository.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = Repository.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            User user = Repository.GetUserById(id);
            Repository.DeleteUser(user);
            Repository.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Search(string SearchStr)
        {
            SearchValue = SearchStr;
            return View(Repository.GetUsersByNameOrNatinaolCode(SearchValue));
        }

        //[HttpPost]
        //public ActionResult Search(string SearchStr)
        //{
        //    return RedirectToAction("Search");
        //}

        //Dispose Repository
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
