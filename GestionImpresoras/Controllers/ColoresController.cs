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
                var areaDisplay = _contexto.Areas.Find(id);
                if (areaDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(areaDisplay);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Area area)
        {
            if (ModelState.IsValid)
            {
                _contexto.Areas.Update(area);
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
                var areaDisplay = _contexto.Areas.Find(id);
                if (areaDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(areaDisplay);
            }
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarArea(int? id)
        {
            var areaDisplay = await _contexto.Areas.FindAsync(id);
            if (areaDisplay == null)
            {
                return View();
            }
            else _contexto.Areas.Remove(areaDisplay);
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
                var areaDisplay = _contexto.Areas.Find(id);
                if (areaDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(areaDisplay);
            }
        }
    }
}
