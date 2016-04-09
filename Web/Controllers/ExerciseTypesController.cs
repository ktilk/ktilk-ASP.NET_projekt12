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
    public class ExerciseTypesController : Controller
    {
        private readonly IUOW _uow;

        public ExerciseTypesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: ExerciseTypes
        public ActionResult Index()
        {
            return View(_uow.ExerciseTypes.All);
        }

        // GET: ExerciseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = _uow.ExerciseTypes.GetById(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // GET: ExerciseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExerciseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseTypeID,ExerciseTypeName,Description")] ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                _uow.ExerciseTypes.Add(exerciseType);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(exerciseType);
        }

        // GET: ExerciseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = _uow.ExerciseTypes.GetById(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // POST: ExerciseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseTypeID,ExerciseTypeName,Description")] ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                _uow.ExerciseTypes.Update(exerciseType);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(exerciseType);
        }

        // GET: ExerciseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = _uow.ExerciseTypes.GetById(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // POST: ExerciseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.ExerciseTypes.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.ExerciseTypes.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
