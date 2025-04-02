using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            var pacientes = _context.Pacientes.Include(p => p.TratamientosAdicionales).ToList();
            return View(pacientes);
        }

        public IActionResult Create()
        {
            return View(new Paciente
            {
                TipoTratamiento = "",
                TratamientosAdicionales = new List<TratamientoAdicional>()
            });
        }

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

        public IActionResult Edit(int id)
        {
            var paciente = _context.Pacientes
                .Include(p => p.TratamientosAdicionales)
                .FirstOrDefault(p => p.Id == id);

            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

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
                try
                {
                    var pacienteExistente = _context.Pacientes
                        .Include(p => p.TratamientosAdicionales)
                        .FirstOrDefault(p => p.Id == id);

                    if (pacienteExistente == null)
                    {
                        return NotFound();
                    }

                    pacienteExistente.Nombre = paciente.Nombre;
                    pacienteExistente.Direccion = paciente.Direccion;
                    pacienteExistente.Telefono = paciente.Telefono;
                    pacienteExistente.TipoTratamiento = paciente.TipoTratamiento;
                    pacienteExistente.FechaInicioTratamiento = paciente.FechaInicioTratamiento;
                    pacienteExistente.PagoInicial = paciente.PagoInicial;
                    pacienteExistente.Mensualidad = paciente.Mensualidad;

                    pacienteExistente.TratamientosAdicionales.Clear();
                    foreach (var tratamiento in paciente.TratamientosAdicionales)
                    {
                        pacienteExistente.TratamientosAdicionales.Add(new TratamientoAdicional
                        {
                            Nombre = tratamiento.Nombre,
                            Costo = tratamiento.Costo
                        });
                    }

                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Pacientes.Any(e => e.Id == paciente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(paciente);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.TratamientosAdicionales)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public IActionResult Delete(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

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


