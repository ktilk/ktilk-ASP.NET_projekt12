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
    public class PlanTypesController : Controller
    {
        private readonly IUOW _uow;

        public PlanTypesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: PlanTypes
        public ActionResult Index()
        {
            var vm = _uow.PlanTypes.All;
            return View(vm);
        }

        // GET: PlanTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanType planType = _uow.PlanTypes.GetById(id);
            if (planType == null)
            {
                return HttpNotFound();
            }
            return View(planType);
        }

        // GET: PlanTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanTypeID,PlanTypeName,Description")] PlanType planType)
        {
            if (ModelState.IsValid)
            {
                _uow.PlanTypes.Add(planType);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(planType);
        }

        // GET: PlanTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanType planType = _uow.PlanTypes.GetById(id);
            if (planType == null)
            {
                return HttpNotFound();
            }
            return View(planType);
        }

        // POST: PlanTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanTypeID,PlanTypeName,Description")] PlanType planType)
        {
            if (ModelState.IsValid)
            {
                _uow.PlanTypes.Update(planType);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(planType);
        }

        // GET: PlanTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanType planType = _uow.PlanTypes.GetById(id);
            if (planType == null)
            {
                return HttpNotFound();
            }
            return View(planType);
        }

        // POST: PlanTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.PlanTypes.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.PlanTypes.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
