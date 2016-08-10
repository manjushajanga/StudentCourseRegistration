using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterWebApp.Controllers
{
    public class UserRegisterController : Controller
    {
        // GET: UserRegister
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Information(User U)
        {
            if(ModelState.IsValid)
            {
                StudentEntities4 st = new StudentEntities4();
                var ct = st.Users.Find(U.EmailID);
                if (ct == null)
                {
                    st.Users.Add(U);
                    st.SaveChanges();
                    TempData["successmessage"] = "Registered successfully";
                    return RedirectToAction("Login", "Login");
                }
                else
                    TempData["successmessage"] = "The User is already Existed";//return null;
            }
            return View(U);
        }
    }
}