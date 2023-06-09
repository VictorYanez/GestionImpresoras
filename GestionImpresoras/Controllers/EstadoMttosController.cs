﻿using GestionImpresoras.Data;
using GestionImpresoras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionImpresoras.Controllers
{
    public class EstadoMttosController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public EstadoMttosController(ApplicationDBContext contexto)
        {
            this._contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.EstadoMttos.ToListAsync();
            return View(listado);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(EstadoMtto estadoMtto)
        {
            if (ModelState.IsValid)
            {
                _contexto.EstadoMttos.Add(estadoMtto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");    // RedirectToAction(nameof(Index))
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            else
            {
                var contacto = _contexto.EstadoMttos.Find(id);
                if (contacto == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(contacto);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Estado estado)
        {
            if (ModelState.IsValid)
            {
                _contexto.Estados.Update(estado);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));    //  RedirectToAction("Index")
            }
            return View();
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            else
            {
                var contacto = _contexto.Estados.Find(id);
                if (contacto == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(contacto);
            }
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var estado = await _contexto.Estados.FindAsync(id);
            if (estado == null)
            {
                return View();
            }
            else _contexto.Estados.Remove(estado);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));    //  RedirectToAction("Index")
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            else
            {
                var contacto = _contexto.Estados.Find(id);
                if (contacto == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(contacto);
            }
        }
    }
}
