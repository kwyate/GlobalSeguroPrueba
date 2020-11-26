using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlobalSegurosPrueba.Models;

namespace GlobalSegurosPrueba.Controllers
{
    public class EmpleadoTiendaController : Controller
    {
        private pruebaGloblaSegurosEntities db = new pruebaGloblaSegurosEntities();

        // GET: EmpleadoTienda
        public async Task<ActionResult> Index()
        {
            var empleado_Tienda = db.Empleado_Tienda.Include(e => e.Empleado1).Include(e => e.Tienda1);
            return View(await empleado_Tienda.ToListAsync());
        }

        // GET: EmpleadoTienda/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado_Tienda empleado_Tienda = await db.Empleado_Tienda.FindAsync(id);
            if (empleado_Tienda == null)
            {
                return HttpNotFound();
            }
            return View(empleado_Tienda);
        }

        // GET: EmpleadoTienda/Create
        public ActionResult Create()
        {
            ViewBag.empleado = new SelectList(db.Empleados, "Id", "nombre");
            ViewBag.tienda = new SelectList(db.Tiendas, "Id", "nombreTienda");
            
            return View();
        }

        // POST: EmpleadoTienda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,tienda,empleado,fecha")] Empleado_Tienda empleado_Tienda)
        {
            if (ModelState.IsValid)
            {
                if(empleado_Tienda.fecha >= DateTime.Today)
                {
                    if(!db.Empleado_Tienda.Where(x=> x.empleado == empleado_Tienda.empleado && x.fecha == empleado_Tienda.fecha).Any())
                    {
                        db.Empleado_Tienda.Add(empleado_Tienda);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("empleado", "El empleado ya esta asignado para esta fecha");
                    }
                }
                else
                {
                    ModelState.AddModelError("fecha", "La fecha debe ser mayor a la actual");
                }
            }

            ViewBag.empleado = new SelectList(db.Empleados, "Id", "nombre", empleado_Tienda.empleado);
            ViewBag.tienda = new SelectList(db.Tiendas, "Id", "nombreTienda", empleado_Tienda.tienda);
            return View(empleado_Tienda);
        }

        // GET: EmpleadoTienda/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado_Tienda empleado_Tienda = await db.Empleado_Tienda.FindAsync(id);
            if (empleado_Tienda == null)
            {
                return HttpNotFound();
            }
            ViewBag.empleado = new SelectList(db.Empleados, "Id", "nombre", empleado_Tienda.empleado);
            ViewBag.tienda = new SelectList(db.Tiendas, "Id", "nombreTienda", empleado_Tienda.tienda);
            return View(empleado_Tienda);
        }

        // POST: EmpleadoTienda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,tienda,empleado,fecha")] Empleado_Tienda empleado_Tienda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado_Tienda).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.empleado = new SelectList(db.Empleados, "Id", "nombre", empleado_Tienda.empleado);
            ViewBag.tienda = new SelectList(db.Tiendas, "Id", "nombreTienda", empleado_Tienda.tienda);
            return View(empleado_Tienda);
        }

        // GET: EmpleadoTienda/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado_Tienda empleado_Tienda = await db.Empleado_Tienda.FindAsync(id);
            if (empleado_Tienda == null)
            {
                return HttpNotFound();
            }
            return View(empleado_Tienda);
        }

        // POST: EmpleadoTienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Empleado_Tienda empleado_Tienda = await db.Empleado_Tienda.FindAsync(id);
            db.Empleado_Tienda.Remove(empleado_Tienda);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
