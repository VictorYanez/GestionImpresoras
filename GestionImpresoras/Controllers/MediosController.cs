using GestionImpresoras.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionImpresoras.Models;


namespace GestionImpresoras.Controllers
{
    public class MediosController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public MediosController(ApplicationDBContext contexto)
        {
            this._contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.Medios.ToListAsync();
            return View(listado);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Medio medio)
        {
            if (ModelState.IsValid)
            {
                _contexto.Medios.Add(medio);
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
                var medioDisplay = _contexto.Medios.Find(id);
                if (medioDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(medioDisplay);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Medio medio)
        {
            if (ModelState.IsValid)
            {
                _contexto.Medios.Update(medio);
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
                var medioDisplay = _contexto.Medios.Find(id);
                if (medioDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(medioDisplay);
            }
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarColor(int? id)
        {
            var medioDisplay = await _contexto.Medios.FindAsync(id);
            if (medioDisplay == null)
            {
                return View();
            }
            else _contexto.Medios.Remove(medioDisplay);
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
                var medioDisplay = _contexto.Medios.Find(id);
                if (medioDisplay == null)
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                return View(medioDisplay);
            }
        }
    }
}
