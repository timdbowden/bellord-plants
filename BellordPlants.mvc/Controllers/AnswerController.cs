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
    public class AnswerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Answer/
        public async Task<ActionResult> Index()
        {
            return View(await db.Answers.ToListAsync());
        }

        // GET: /Answer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = await db.Answers.FindAsync(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: /Answer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Answer/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answers.Add(answer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(answer);
        }

        // GET: /Answer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = await db.Answers.FindAsync(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: /Answer/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(answer);
        }

        // GET: /Answer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = await db.Answers.FindAsync(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: /Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Answer answer = await db.Answers.FindAsync(id);
            db.Answers.Remove(answer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public PartialViewResult _QuestionAnswers(int questionID)
        {
            ViewBag.QuestionId = questionID;

            List<Answer> answers = (from a in db.Answers where a.QuestionId == questionID select a).ToList();

            return PartialView("_QuestionAnswers", answers);

        }

        [ChildActionOnly()]
        public PartialViewResult _AnswerForm(int questionID)
        {
            Answer answer = new Answer() { QuestionId = questionID };
            return PartialView("_AnswerForm", answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Submit(Answer answer)
        {
            db.Answers.Add(answer);
            db.SaveChanges();

            //List<Answer> answers = db.Answers.Where(a => a.QuestionId == answer.QuestionId).ToList();

            return _QuestionAnswers(answer.QuestionId);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
