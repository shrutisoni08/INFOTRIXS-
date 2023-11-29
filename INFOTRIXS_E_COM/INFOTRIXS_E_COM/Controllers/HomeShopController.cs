using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INFOTRIXS_E_COM.Controllers
{
    public class HomeShopController : Controller
    {
        // GET: HomeShop
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeShop/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: HomeShop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeShop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeShop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeShop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeShop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeShop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
