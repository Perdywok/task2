using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using task2.Models;

namespace task2.Controllers
{
    public class BrochuresController : Controller
    {
        private Library db = new Library();

        // GET: Brochures
        public async Task<ActionResult> Index()
        {
            return View(await db.Brochures.ToListAsync());
        }

        // GET: Brochures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brochure brochure = await db.Brochures.FindAsync(id);
            if (brochure == null)
            {
                return HttpNotFound();
            }
            return View(brochure);
        }

        // GET: Brochures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brochures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BrochureId,BookName,Pages,Content,Genre,Authors")] Brochure brochure)
        {
            if (ModelState.IsValid)
            {
                db.Brochures.Add(brochure);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(brochure);
        }

        // GET: Brochures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brochure brochure = await db.Brochures.FindAsync(id);
            if (brochure == null)
            {
                return HttpNotFound();
            }
            return View(brochure);
        }

        // POST: Brochures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BrochureId,BookName,Pages,Content,Genre,Authors")] Brochure brochure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brochure).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(brochure);
        }

        // GET: Brochures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brochure brochure = await db.Brochures.FindAsync(id);
            if (brochure == null)
            {
                return HttpNotFound();
            }
            return View(brochure);
        }

        // POST: Brochures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Brochure brochure = await db.Brochures.FindAsync(id);
            db.Brochures.Remove(brochure);
            await db.SaveChangesAsync();
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
