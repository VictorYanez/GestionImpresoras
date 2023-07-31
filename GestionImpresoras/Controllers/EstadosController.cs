using GestionImpresoras.Data;
using GestionImpresoras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionImpresoras.Controllers
{
    public class EstadosController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public EstadosController(ApplicationDBContext contexto)
        {
            this._contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.Estados.ToListAsync();
            return View(listado);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(Estado estado)
        {
            if (ModelState.IsValid) 
            { 
            _contexto.Estados.Add(estado);   
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");    // RedirectToAction(nameof(Index))
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Edit(Estado estado)
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
        public IActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEstados(int? id)
        {
            var estadoDisplay = await _contexto.Estados.FindAsync(id);
            if (estadoDisplay == null)
            {
                return View();
            }
            else
            {
                // Verificar si hay impresoras que están usando este estado
                var impresoras = _contexto.Impresoras.Where(i => i.EstadoId == id);
                if (impresoras.Any())
                {
                    // Mostrar un mensaje al usuario informándole que no se puede eliminar el estado
                    ModelState.AddModelError("", "No se puede eliminar este estado porque está siendo usado por una o más impresoras. Por favor reasigne las impresoras a otro estado antes de eliminarlo.");
                    return View(estadoDisplay);
                }
                else
                {
                    _contexto.Estados.Remove(estadoDisplay);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
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
