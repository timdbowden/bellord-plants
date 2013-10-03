using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BellordPlants.mvc.Models;

namespace BellordPlants.mvc.Controllers
{
    public class TaskListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TaskList/
        public async Task<ActionResult> Index()
        {
            return View(await db.TaskLists.ToListAsync());
        }

        // GET: /TaskList/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList tasklist = await db.TaskLists.FindAsync(id);
            if (tasklist == null)
            {
                return HttpNotFound();
            }
            return View(tasklist);
        }

        // GET: /TaskList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TaskList/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TaskList tasklist)
        {
            if (ModelState.IsValid)
            {
                db.TaskLists.Add(tasklist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tasklist);
        }

        // GET: /TaskList/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList tasklist = await db.TaskLists.FindAsync(id);
            if (tasklist == null)
            {
                return HttpNotFound();
            }
            return View(tasklist);
        }

        // POST: /TaskList/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TaskList tasklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasklist).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tasklist);
        }

        // GET: /TaskList/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList tasklist = await db.TaskLists.FindAsync(id);
            if (tasklist == null)
            {
                return HttpNotFound();
            }
            return View(tasklist);
        }

        // POST: /TaskList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaskList tasklist = await db.TaskLists.FindAsync(id);
            db.TaskLists.Remove(tasklist);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
