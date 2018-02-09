﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using task2.Models;

namespace task2.Controllers
{
    public class GridController : Controller
    {
        private Library db = new Library();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Books_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Book> books = db.Books;
            DataSourceResult result = books.ToDataSourceResult(request, book => new {
                BookId = book.BookId,
                BookName = book.BookName,
                Pages = book.Pages,
                Content = book.Content,
                Genre = book.Genre,
                Authors = book.Authors
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Create([DataSourceRequest]DataSourceRequest request, Book book)
        {
            if (ModelState.IsValid)
            {
                var entity = new Book
                {
                    BookName = book.BookName,
                    Pages = book.Pages,
                    Content = book.Content,
                    Genre = book.Genre,
                    Authors = book.Authors
                };

                db.Books.Add(entity);
                db.SaveChanges();
                book.BookId = entity.BookId;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Update([DataSourceRequest]DataSourceRequest request, Book book)
        {
            if (ModelState.IsValid)
            {
                var entity = new Book
                {
                    BookId = book.BookId,
                    BookName = book.BookName,
                    Pages = book.Pages,
                    Content = book.Content,
                    Genre = book.Genre,
                    Authors = book.Authors
                };

                db.Books.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Destroy([DataSourceRequest]DataSourceRequest request, Book book)
        {
            if (ModelState.IsValid)
            {
                var entity = new Book
                {
                    BookId = book.BookId,
                    BookName = book.BookName,
                    Pages = book.Pages,
                    Content = book.Content,
                    Genre = book.Genre,
                    Authors = book.Authors
                };

                db.Books.Attach(entity);
                db.Books.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
