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
    public class AnotherGridController : Controller
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

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
