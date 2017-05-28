﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopping.Models;

namespace shopping.Controllers
{
    public class AccountGroupsController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: AccountGroups
        public ActionResult Index()
        {
            var accountGroups = db.AccountGroups.Include(a => a.Account).Include(a => a.Group);
            return View(accountGroups.ToList());
        }

        // GET: AccountGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // GET: AccountGroups/Create
        public ActionResult Create()
        {
            ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName");
            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName");
            return View();
        }

        // POST: AccountGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,groupId,accountId,active")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.AccountGroups.Add(accountGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName", accountGroup.accountId);
            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", accountGroup.groupId);
            return View(accountGroup);
        }

        // GET: AccountGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName", accountGroup.accountId);
            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", accountGroup.groupId);
            return View(accountGroup);
        }

        // POST: AccountGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,groupId,accountId,active")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName", accountGroup.accountId);
            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", accountGroup.groupId);
            return View(accountGroup);
        }

        // GET: AccountGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // POST: AccountGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            db.AccountGroups.Remove(accountGroup);
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
