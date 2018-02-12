using System;
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
    public class JournalsController : Controller
    {
        private Library db = new Library();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Journals_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Journal> journals = db.Journals;
            DataSourceResult result = journals.ToDataSourceResult(request, journal => new
            {
                JournalId = journal.JournalId,
                BookName = journal.BookName,
                Pages = journal.Pages,
                Content = journal.Content,
                Genre = journal.Genre
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Journals_Create([DataSourceRequest]DataSourceRequest request, Journal journal)
        {
            if (ModelState.IsValid)
            {
                var entity = new Journal
                {
                    BookName = journal.BookName,
                    Pages = journal.Pages,
                    Content = journal.Content,
                    Genre = journal.Genre
                };

                db.Journals.Add(entity);
                db.SaveChanges();
                journal.JournalId = entity.JournalId;
            }

            return Json(new[] { journal }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Journals_Update([DataSourceRequest]DataSourceRequest request, Journal journal)
        {
            if (ModelState.IsValid)
            {
                var entity = new Journal
                {
                    JournalId = journal.JournalId,
                    BookName = journal.BookName,
                    Pages = journal.Pages,
                    Content = journal.Content,
                    Genre = journal.Genre
                };

                db.Journals.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { journal }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Journals_Destroy([DataSourceRequest]DataSourceRequest request, Journal journal)
        {
            if (ModelState.IsValid)
            {
                var entity = new Journal
                {
                    JournalId = journal.JournalId,
                    BookName = journal.BookName,
                    Pages = journal.Pages,
                    Content = journal.Content,
                    Genre = journal.Genre
                };

                db.Journals.Attach(entity);
                db.Journals.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { journal }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
