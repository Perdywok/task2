using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using task2.Models;
using System.ComponentModel.DataAnnotations;
namespace task2.Controllers
{
    [Authorize(Roles ="admin")]
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
           // if (Request.IsAjaxRequest())
                return Json(result, JsonRequestBehavior.AllowGet);
            //else            
             //   return View("Index", books);
            
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
            if (Request.IsAjaxRequest())
                return Json(new[] { book }.ToDataSourceResult(request, ModelState),JsonRequestBehavior.AllowGet);
            else
                return View("Index");
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
            if (Request.IsAjaxRequest())
                return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            else
                return View("Index");
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
            if (Request.IsAjaxRequest())
                return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            else
                return View("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
