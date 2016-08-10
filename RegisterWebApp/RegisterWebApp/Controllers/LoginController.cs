using RegisterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RegisterWebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            Session["LogedUserID"] = null;
            Session["LogedUserFullname"] = null;
            Session["User"] = null;
            return View();
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["LogedUserID"] = null;
            Session["LogedUserFullname"] = null;
            Session["User"] = null;
            return RedirectToAction("SignUp", "UserRegister");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login U)
        {

     
            if (ModelState.IsValid)
            {
                using (StudentEntities4 dc = new StudentEntities4())
                {
                    var v = dc.Users.Where(a => a.EmailID.Equals(U.Email) && a.Password.Equals(U.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.EmailID.ToString();
                        Session["LogedUserFullname"] = v.FirstName.ToString()+" "+v.LastName.ToString();
                        if (v.FirstName.ToString() == "Admin")
                            Session["User"] = "Admin";
                        else
                            Session["User"] = "Student";
                        TempData["successmesg"] = "Logged in successfully";
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(U);
        }
        public ActionResult AfterLogin()
        {
           List< RegisterWebApp.User> U;
            if (Session["LogedUserID"] != null)
            {
                using (StudentEntities4 dc = new StudentEntities4())
                {
                    var vi = Session["LogedUserID"].ToString();
                    var v = dc.Users.Where(a => a.EmailID==vi);
                    if (v != null)
                    {
                        U = v.ToList();
                        return View(U);
                    }
                    else
                        return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}