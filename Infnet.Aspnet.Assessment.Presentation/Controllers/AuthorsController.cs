﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infnet.Aspnet.Assessment.Entities;
using Infnet.Aspnet.Assessment.Presentation.Models;
using RestSharp;
using Infnet.Aspnet.Assessment.Presentation.Helper;

namespace Infnet.Aspnet.Assessment.Presentation.Controllers
{
    public class AuthorsController : Controller
    {
        private const string URI = "api/authors";

        // GET: Authors
        public ActionResult Index()
        {
            var authors = RequestHelper.MakeRequest<List<Author>>(URI, Method.GET);
            return View(authors);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = RequestHelper.MakeRequest<Author>($"{URI}/{id}", Method.GET);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,Email,Birthdate")] Author author)
        {
            if (ModelState.IsValid)
            {
                var newAuthor = RequestHelper.MakeRequest<Author>(URI, Method.POST, author);
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = RequestHelper.MakeRequest<Author>($"{URI}/{id}", Method.GET);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Email,Birthdate")] Author author)
        {
            if (ModelState.IsValid)
            {
                var newAuthor = RequestHelper.MakeRequest<Author>($"{URI}/{author.Id}", Method.PUT, author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = RequestHelper.MakeRequest<Author>($"{URI}/{id}", Method.GET);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var author = RequestHelper.MakeRequest<Author>($"{URI}/{id}", Method.DELETE);
            return RedirectToAction("Index");
        }
    }
}
