﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TTIPApplication.Models;

namespace TTIPApplication.Controllers
{
    public class ReviewController : Controller
    {
        private TTIP_DBEntities db = new TTIP_DBEntities();

        // GET: Review
        public ActionResult Index()
        {
            var pid = Convert.ToInt32(Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.LastIndexOf("/") + 1));
            ViewBag.placeInfo = db.PLACE.Find(pid);

            var review = db.REVIEW.Include(r => r.PLACE);
            return View(review.ToList());
        }

        // GET: Review/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW rEVIEW = db.REVIEW.Find(id);
            if (rEVIEW == null)
            {
                return HttpNotFound();
            }
            return View(rEVIEW);
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            var pid = Convert.ToInt32(Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.LastIndexOf("/") + 1));
            ViewBag.placeInfo = db.PLACE.Find(pid);

            ViewBag.PID = new SelectList(db.PLACE, "ID", "STORE_NAME");
            return View();
        }

        // POST: Review/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REVIEW_ID,PID,WRITER,SCORE,UPDATE_DATE,REVIEW_COMMENT")] REVIEW review)
        {
            if (ModelState.IsValid)
            {
                db.REVIEW.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index/" + review.PID);
            }

            return View(review);
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW review = db.REVIEW.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }

            ViewBag.placeInfo = db.PLACE.Find(review.PID);
            return View(review);
        }

        // POST: Review/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REVIEW_ID,PID,WRITER,SCORE,UPDATE_DATE,REVIEW_COMMENT")] REVIEW review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index/" + review.PID);
            }
            ViewBag.PID = new SelectList(db.PLACE, "ID", "STORE_NAME", review.PID);
            return View(review);
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REVIEW review = db.REVIEW.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }

            ViewBag.placeInfo = db.PLACE.Find(review.PID);
            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REVIEW review = db.REVIEW.Find(id);
            db.REVIEW.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index/" + review.PID);
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