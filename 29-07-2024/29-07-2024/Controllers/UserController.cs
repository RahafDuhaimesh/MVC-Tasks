using _29_07_2024.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace _29_07_2024.Controllers
{
    public class UserController : Controller
    {
        private Task6Entities db = new Task6Entities();

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register( UserLOG data, string ConfirmPassword)
        {
            if (ModelState.IsValid && data.Password == ConfirmPassword)
            {
                db.UserLOGs.Add(data);
                db.SaveChanges();

                return RedirectToAction("Home");
            }

            return View(data);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLOG data)
        {
            var checkInputs = db.UserLOGs
                                    .Where(model => model.Email == data.Email && model.Password == data.Password)
                                    .FirstOrDefault();

            if (checkInputs != null)
            {
                // User is found, proceed with setting session
                Session["UserID"] = checkInputs.ID;
                return RedirectToAction("Home"); // Redirect to a valid action after login
            }
            else
            {
                // User is not found, return an error message
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View(); // Return to the login view
            }
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return RedirectToAction("Home");
        }


        public ActionResult Profile()
        {
            var userID = (int)Session["UserID"];
            var user = db.UserLOGs.Find(userID);
            return View(user);
        }

        [HttpPost]
        //public ActionResult Profile(UserLOG data, HttpPostedFileBase upload)
        //{


        //    if (upload != null && upload.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(upload.FileName);
        //        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

        //        if (!Directory.Exists(Server.MapPath("~/Images/")))
        //        {
        //            Directory.CreateDirectory(Server.MapPath("~/Images/"));
        //        }

        //        upload.SaveAs(path);
        //        data.img = fileName;
        //    }

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            db.Entry(data).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Home");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (ex) here
        //        ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
        //    }

        //    return RedirectToAction("Home");

        //}

        public ActionResult Profile(UserLOG data, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.UserLOGs.Find(data.ID);
                if (existingUser != null)
                {
                    existingUser.name = data.name;
                    existingUser.Email = data.Email;
                    existingUser.Password = data.Password;
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(upload.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        upload.SaveAs(path);
                        existingUser.img = fileName;
                    }
                    db.Entry(existingUser).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Profile");
            }
            return View(data);
        }

        public ActionResult ResetPassword()
        {
            var userID = (int)Session["UserID"]; // Get user ID from session
            var user = db.UserLOGs.Find(userID);

            var model = new UserLOG
            {
                ID = user.ID
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ResetPassword(string currentPassword, string newPassword, string confirmNewPassword)
        {
            var userID = (int)Session["UserID"];
            var user = db.UserLOGs.Find(userID);

            if (currentPassword == user.Password)
            {
                if (newPassword == confirmNewPassword)
                {
                    user.Password = newPassword;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Profile");
                }
                else
                {
                    ViewBag.Message = "New Password does not match Confirm Password!";
                    return View(user);
                }
            }
            else
            {
                ViewBag.Message = "Current Password is incorrect!";
                return View(user);
            }
        }
    }
}