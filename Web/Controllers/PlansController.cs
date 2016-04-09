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
    public class PlansController : Controller
    {
        private readonly IUOW _uow;

        public PlansController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Plans
        public ActionResult Index()
        {
            var vm = _uow.Plans.All;
            //var plans = db.Plans.Include(p => p.PlanType);
            return View(vm);
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _uow.Plans.GetById(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            ViewBag.PlanTypeID = new SelectList(_uow.PlanTypes.All, "PlanTypeID", "PlanTypeName");
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanID,PlanName,Rating,Description,Instructions,PlanTypeID,DateCreated,DateClosed,Duration,PersonID")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                _uow.Plans.Add(plan);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.PlanTypeID = new SelectList(_uow.PlanTypes.All, "PlanTypeID", "PlanTypeName", plan.PlanTypeID);
            return View(plan);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _uow.Plans.GetById(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlanTypeID = new SelectList(_uow.PlanTypes.All, "PlanTypeID", "PlanTypeName", plan.PlanTypeID);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanID,PlanName,Rating,Description,Instructions,PlanTypeID,DateCreated,DateClosed,Duration,PersonID")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                _uow.Plans.Update(plan);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.PlanTypeID = new SelectList(_uow.PlanTypes.All, "PlanTypeID", "PlanTypeName", plan.PlanTypeID);
            return View(plan);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _uow.Plans.GetById(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Plans.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Plans.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
