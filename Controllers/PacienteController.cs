using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SystemOdonto.Models;

namespace SystemOdonto.Controllers
{
    public class PacienteController : Controller
    {
        private readonly SystemOdontoDbContext _context;

        public PacienteController(SystemOdontoDbContext context)
        {
            _context = context;
        }

        // 1️⃣ LISTAR PACIENTES
        public IActionResult Index()
        {
            var pacientes = _context.Pacientes.ToList();
            return View(pacientes);
        }

        // 2️⃣ CREAR PACIENTE - FORMULARIO
        public IActionResult Create()
        {
            return View(new Paciente
            {
                TipoTratamiento = "",
                TratamientosAdicionales = new List<TratamientoAdicional>()
            });
        }

        // 3️⃣ CREAR PACIENTE - GUARDAR EN BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // 4️⃣ EDITAR PACIENTE - FORMULARIO
        public IActionResult Edit(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // 5️⃣ EDITAR PACIENTE - GUARDAR CAMBIOS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Pacientes.Update(paciente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // 6️⃣ DETALLES DE UN PACIENTE
        public IActionResult Details(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // 7️⃣ ELIMINAR PACIENTE - CONFIRMACIÓN
        public IActionResult Delete(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // 8️⃣ ELIMINAR PACIENTE - CONFIRMAR Y BORRAR
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
