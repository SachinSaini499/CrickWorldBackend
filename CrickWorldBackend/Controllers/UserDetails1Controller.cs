﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrickWorldBackend.Models;

namespace CrickWorldBackend.Controllers
{
    public class UserDetails1Controller : Controller
    {
        private CrickWorldUserContext db = new CrickWorldUserContext();

        // GET: UserDetails1
        public ActionResult Index()
        {
            return View(db.UserDetails.ToList());
        }

        // GET: UserDetails1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // GET: UserDetails1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetails1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,PhoneNumber")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDetails);
        }

        // GET: UserDetails1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,PhoneNumber")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetails);
        }

        // GET: UserDetails1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetails userDetails = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
