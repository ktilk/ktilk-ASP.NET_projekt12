using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace Web.Controllers
{
    public class WorkoutsController : Controller
    {
        private readonly IUOW _uow;

        public WorkoutsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Workouts
        public ActionResult Index()
        {
            var vm = _uow.Workouts.All;
            //var workouts = db.Workouts.Include(w => w.Plan);
            return View(vm);
        }

        // GET: Workouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = _uow.Workouts.GetById(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // GET: Workouts/Create
        public ActionResult Create()
        {
            ViewBag.PlanID = new SelectList(_uow.Plans.All, "PlanID", "PlanName");
            return View();
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkoutID,Date,Duration,PlanID")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                _uow.Workouts.Add(workout);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.PlanID = new SelectList(_uow.Plans.All, "PlanID", "PlanName", workout.PlanID);
            return View(workout);
        }

        // GET: Workouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = _uow.Workouts.GetById(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlanID = new SelectList(_uow.Plans.All, "PlanID", "PlanName", workout.PlanID);
            return View(workout);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkoutID,Date,Duration,PlanID")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                _uow.Workouts.Update(workout);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.PlanID = new SelectList(_uow.Plans.All, "PlanID", "PlanName", workout.PlanID);
            return View(workout);
        }

        // GET: Workouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = _uow.Workouts.GetById(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Workouts.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Workouts.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
