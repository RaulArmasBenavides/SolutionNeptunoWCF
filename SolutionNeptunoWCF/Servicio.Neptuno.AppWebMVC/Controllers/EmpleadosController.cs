using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicio.Neptuno.AppWebMVC.ProxyWCF;

namespace Servicio.Neptuno.AppWebMVC.Controllers
{
    public class EmpleadosController : Controller
    {
        EmpleadoServiceClient obj = new EmpleadoServiceClient();

        // GET: Empleados
        public ActionResult Index()
        {
            return View(obj.EmpleadoListar());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(Empleado emp)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    obj.EmpleadoAdicionar(emp);
                    RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empleados/Edit/5
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

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleados/Delete/5
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
