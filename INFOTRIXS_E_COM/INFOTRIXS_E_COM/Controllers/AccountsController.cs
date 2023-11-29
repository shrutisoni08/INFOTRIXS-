using INFOTRIXS_E_COM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;

namespace INFOTRIXS_E_COM.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if(ModelState.IsValid)
            {
                using (INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
                {
                    bool isValidUser = db.Users.Any(el => el.Email == model.Email && el.UserPassword == model.Password);
                    if (isValidUser)
                    {
                        string userName = db.Users.FirstOrDefault(el => el.Email == model.Email).UserName;
                        FormsAuthentication.SetAuthCookie(userName, false);
                        
                        return RedirectToAction("Index", "HomeShop");
                    }
                    else
                    {
                        TempData["Error"] = "Invalid User!";
                    }
                }
            }
            
            return View();
        }
        //public ActionResult SignUp()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                using(INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
                {
                    bool isExist = db.Users.Any(el => el.MobileNumber == model.MobileNumber || el.Email == model.Email);
                    if (!isExist)
                    {
                        model.UserRolesMappings.Add(new UserRolesMapping() { RoleID = 1 });                        
                        db.Users.Add(model);                        
                        db.SaveChanges();
                        
                        TempData["Success"] = "Sign-Up Successfull!";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        TempData["Error"] = "user is Allready !";
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}