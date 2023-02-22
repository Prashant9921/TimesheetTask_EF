using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimesheetTaskAdd.Models;

namespace TimesheetTaskAdd.Controllers
{
    public class AddTaskController : Controller
    {
        
        neilsofttsEntities db = new neilsofttsEntities();
        // GET: AddTask
        public ActionResult Index()
        {
            var data = db.WarJobs.ToList(); 
            return View(data);
        }
        public ActionResult Create()

        {
            ViewBag.warjobslist = db.WarJobs.ToList();
            //return View(db.WarJobs.Where(X => X.Job_Archive.Equals(Status) ).ToList());
            
            return View();  

        }


        public ActionResult Edit(int Id)
        {
            var row = db.WarJobs.Where(model=>model.Job_Id==Id).FirstOrDefault();

            return View(row);
        }
        [HttpPost]
        public ActionResult Create (WarJob warjob)
        {
            List<WarJob> warjobs = db.WarJobs.ToList();

            if (ModelState.IsValid == true)
                {
                
                db.WarJobs.Add(warjob);
                  int a = db.SaveChanges();
                 ViewBag.warjobslist = db.WarJobs.ToList();


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
        public ActionResult Status() 
        {
            ViewBag.warjobslist = db.WarJobs.ToList();
           

            return View(); 
        }
        [HttpPost]
        public ActionResult Status(string Answer)
        {
            
            if (Answer== "Open")
            {
                ViewBag.warjobslist = db.WarJobs.Where(model => model.Job_Archive == true).ToList();
            }
            else if (Answer == "Close")
            {
                ViewBag.warjobslist = db.WarJobs.Where(model => model.Job_Archive== false).ToList();
                //var warjobslist = db.WarJobs.Where(model => model.Job_Archive == true).ToList();
                //warjobslist = db.WarJobs.Where(model => model.Job_Archive == false).ToList();
            }
            else
            {
                ViewBag.warjobslist = db.WarJobs.ToList();
                //var warjobslist = db.WarJobs.ToList();
            }
            return View();
        }

       
    }
}