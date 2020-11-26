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
    public class EmpleadoController : Controller
    {
        private pruebaGloblaSegurosEntities db = new pruebaGloblaSegurosEntities();

        // GET: Empleado
        public async Task<ActionResult> Index()
        {
            ViewBag.cargo = new SelectList(db.Cargos, "Id", "descripcion");
            var empleados = db.Empleados.Include(e => e.Cargo1);
            return View(await empleados.ToListAsync());
        }
        public async Task<ActionResult> filtrarCargo(int cargo)
        {
            ViewBag.cargo = new SelectList(db.Cargos, "Id", "descripcion");
            var empleados = db.Empleados.Include(e => e.Cargo1).Where(x=> x.cargo == cargo);
            return View("Index", await empleados.ToListAsync());
        }

        // GET: Empleado/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empleado = db.Empleado_Tienda.Where(x => x.empleado == id).OrderByDescending(x=> x.fecha).ToList();
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.cargo = new SelectList(db.Cargos, "Id", "descripcion");
            ViewBag.genero = new SelectList(new List<SelectListItem> { 
                new SelectListItem {Value= "M", Text= "Masculino"},
                new SelectListItem {Value= "F", Text= "Femenino"}
            }, "Value", "Text");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,nombre,Documento,fechaNacimiento,genero,cargo")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.cargo = new SelectList(db.Cargos, "Id", "descripcion", empleado.cargo);
            ViewBag.genero = new SelectList(new List<SelectListItem> {
                new SelectListItem {Value= "M", Text= "Masculino"},
                new SelectListItem {Value= "F", Text= "Femenino"}
            }, empleado.genero);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = await db.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.cargo = new SelectList(db.Cargos, "Id", "descripcion", empleado.cargo);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,nombre,Documento,fechaNacimiento,genero,cargo")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.cargo = new SelectList(db.Cargos, "Id", "descripcion", empleado.cargo);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = await db.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Empleado empleado = await db.Empleados.FindAsync(id);
            db.Empleados.Remove(empleado);
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
