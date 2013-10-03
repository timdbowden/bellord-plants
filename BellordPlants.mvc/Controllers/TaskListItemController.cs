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
    public class TaskListItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TaskListItem/
        public async Task<ActionResult> Index()
        {
            return View(await db.TaskListItems.ToListAsync());
        }

        // GET: /TaskListItem/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskListItem tasklistitem = await db.TaskListItems.FindAsync(id);
            if (tasklistitem == null)
            {
                return HttpNotFound();
            }
            return View(tasklistitem);
        }

        // GET: /TaskListItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TaskListItem/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TaskListItem tasklistitem)
        {
            if (ModelState.IsValid)
            {
                db.TaskListItems.Add(tasklistitem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tasklistitem);
        }

        // GET: /TaskListItem/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskListItem tasklistitem = await db.TaskListItems.FindAsync(id);
            if (tasklistitem == null)
            {
                return HttpNotFound();
            }
            return View(tasklistitem);
        }

        // POST: /TaskListItem/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TaskListItem tasklistitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasklistitem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tasklistitem);
        }

        // GET: /TaskListItem/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskListItem tasklistitem = await db.TaskListItems.FindAsync(id);
            if (tasklistitem == null)
            {
                return HttpNotFound();
            }
            return View(tasklistitem);
        }

        // POST: /TaskListItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaskListItem tasklistitem = await db.TaskListItems.FindAsync(id);
            db.TaskListItems.Remove(tasklistitem);
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
