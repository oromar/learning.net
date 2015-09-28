using RazorMVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorMVCExample.Controllers
{
    public class HomeController : Controller
    {
        private static Users _users = new Users();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(_users._userList);
        }

        public ActionResult Create()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public ActionResult Create(UserModel userModel)
        {
            
            if (ModelState.IsValid)
            {
                _users.Create(userModel);
                return RedirectToAction("Index");
            }
            return View(userModel);
        }

        public ActionResult Edit(string id)
        {
            return View(_users.GetUser(id)); 
        }

        [HttpPost]
        public ActionResult Edit(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _users.Update(userModel);
                return RedirectToAction("Index");
            }
            return View(userModel);
        }


        public ActionResult Details(string id)         
        {
            return View(_users.GetUser(id));
        }

        public ActionResult Delete(string id)
        {
            return View(_users.GetUser(id));
        }

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            _users.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
