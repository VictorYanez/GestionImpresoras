using GestionImpresoras.Data;
using GestionImpresoras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionImpresoras.Controllers
{
    public class ColoresController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public ColoresController(ApplicationDBContext contexto)
        {
            this._contexto = contexto;
        } 
            
        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.Colores.ToListAsync();
            return View(listado);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Color color)
        {
            if (ModelState.IsValid)
            {
                _contexto.Colores.Add(color);
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
                var colorDisplay = _contexto.Colores.Find(id);
                if (colorDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(colorDisplay);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Color color)
        {
            if (ModelState.IsValid)
            {
                _contexto.Colores.Update(color);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));    //  RedirectToAction("Index")
            }
            return View();
        }
        //Endpoints para el Borrar registros
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            else
            {
                var colorDisplay = _contexto.Colores.Find(id);
                if (colorDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(colorDisplay);
            }
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarColor(int? id)
        {
            var colorDisplay = await _contexto.Colores.FindAsync(id);
            if (colorDisplay == null)
            {
                return View();
            }
            else _contexto.Colores.Remove(colorDisplay);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));    //  RedirectToAction("Index")
        }
        //Endpoint para el desplegar (Details) de registros
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            else
            {
                var colorDisplay = _contexto.Colores.Find(id);
                if (colorDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(colorDisplay);
            }
        }
    }
}
