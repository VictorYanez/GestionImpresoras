using GestionImpresoras.Models;
using Microsoft.AspNetCore.Mvc;
using GestionImpresoras.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using GestionImpresoras.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionImpresoras.Controllers
{
    public class MantenimientosController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public MantenimientosController(ApplicationDBContext contexto)
        {
            this._contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.Mantenimientos.ToListAsync();
            return View(listado);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            if (!await _contexto.Impresoras.AnyAsync())
            {
                ModelState.AddModelError(string.Empty, "La tabla de impresoras está vacía");
                return View();
            }
            if (!await _contexto.EstadoMttos.AnyAsync())
            {
                ModelState.AddModelError(string.Empty, "La tabla de estados está vacía");
                return View();
            }

            ViewBag.ImpresoraId = await _contexto.Impresoras.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.CodigoActivoFijo }).ToListAsync();
            ViewBag.EstadoMttoId = await _contexto.EstadoMttos.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nombre }).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                _contexto.Mantenimientos.Add(mantenimiento);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");    // RedirectToAction(nameof(Index))
            }
            return View();
        }

        //Endpoints para el Borrar registros
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            else
            {
                var itemDisplay = _contexto.Mantenimientos.Find(id);
                if (itemDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(itemDisplay);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                _contexto.Mantenimientos.Update(mantenimiento);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));    //  RedirectToAction("Index")
            }
            return View();
        }
    }
}
