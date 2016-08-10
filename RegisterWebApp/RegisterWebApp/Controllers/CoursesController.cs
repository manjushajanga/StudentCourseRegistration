using RegisterWebApp;
using RegisterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterWebApp.Controllers
{
    public class CoursesController : Controller
    {

        public ActionResult RegisteredCourses()
        {
            StudentEntities4 dc = new StudentEntities4();
            return View(dc.Courses.ToList());
        }
        // GET: Courses
        public ActionResult CoursesView()
        {
            StudentEntities4 dc = new StudentEntities4();
            return View(dc.Courses.ToList());

        }

        public ActionResult Create()
        {
            return View();
        }


        
        public ActionResult AddCourse(int id)
        {
            if (id != 0)
            {
                if (ModelState.IsValid)
                {
                    using (StudentEntities4 dc = new StudentEntities4())
                    {
                        Enroll e = new Enroll();
                        e.CourseCourseId = id;
                        e.Grade = "0";
                        e.UserUserId = Session["LogedUserID"].ToString();
                        dc.Enrolls.Add(e);
                        var courseToUpdate = dc.Courses.Find(id);
                        courseToUpdate.SeatsTaken++;
                        //dc.Courses.
                        dc.SaveChanges();
                        //dc.Courses.u
                        TempData["CMessage"] = "Registered successfully";
                        return RedirectToAction("CoursesView", "Courses");
                    }
                }
            }
            return RedirectToAction("CoursesView","Courses");//Delete that stuff!
        }

    
        public ActionResult DropCourse(int id)
        {
            if (id != 0)
            {
                if (ModelState.IsValid)
                {
                    using (StudentEntities4 dc = new StudentEntities4())
                    {
                        var x = Session["LogedUserID"].ToString();
                        var v = dc.Enrolls.Where(a => a.UserUserId.Equals(x) && a.CourseCourseId.Equals(id)).FirstOrDefault();
                        if (v != null)
                        {
                            dc.Enrolls.Remove(v);
                            dc.SaveChanges();   
                            var courseToUpdate = dc.Courses.Find(id);
                            courseToUpdate.SeatsTaken--;
                            //dc.Courses.
                            dc.SaveChanges();
                            //dc.Courses.u
                            TempData["DMessage"] = "Dropped successfully";
                            return RedirectToAction("RegisteredCourses", "Courses");
                        }
                    }
                }
            }
            return RedirectToAction("RegisteredCourses", "Courses");//Delete that stuff!
        }
        //  [HttpPost]
        // [ValidateAntiForgeryToken]
        /*   public ActionResult Create(AddCourses sd)
           {
               if (ModelState.IsValid)
               {
                   StudentEntities1 dc = new StudentEntities1();
                   dc.Courses.Add(sd);
                   dc.SaveChanges();
                   return RedirectToAction("Index");
               }

            //   return View(AddCourses);
           }*/
    }
}