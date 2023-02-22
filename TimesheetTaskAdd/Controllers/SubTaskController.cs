using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimesheetTaskAdd.Models;

namespace TimesheetTaskAdd.Controllers
{
    public class SubTaskController : Controller
    {
        neilsofttsEntities db = new neilsofttsEntities();
        // GET: SubTask
        public ActionResult Index()
        {
            var data = db.WarDrawings.ToList();
            return View(data);
        }
        public ActionResult Create()

        {
            ViewBag.warjobslist = db.WarDrawings.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(WarDrawing subtask)
        {
            List<WarDrawing> warDrawings = db.WarDrawings.ToList();

            if (ModelState.IsValid == true)
            {

                db.WarDrawings.Add(subtask);
                int a = db.SaveChanges();
                ViewBag.subtasklist = db.WarDrawings.ToList();


                ModelState.Clear();
                if (a > 0)
                {
                    TempData["InsertMasage"] = "<script>alert('Inserted Successfully')</script>";
                    //return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMasage"] = "<script>alert('Inserted Not Successfully')</script>";

                }
                return View();
            }


            return View();
        }
    }
}