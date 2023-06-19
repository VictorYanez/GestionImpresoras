using GestionImpresoras.Data;
using GestionImpresoras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionImpresoras.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly ApplicationDBContext _contexto;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SolicitudesController(ApplicationDBContext contexto, IWebHostEnvironment webHostEnvironment)
        {
            this._contexto = contexto;
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _contexto.Solicitudes
                .Include(x => x.Impresora)
                .Include(x => x.Color)
                .Include(x => x.EstadoSolicitud).ToListAsync();
            return View(lista);
        }
        // GET: Impresoras/Crear
        public async Task<IActionResult> Crear()
        {
            if (!await _contexto.Impresoras.AnyAsync())
            {
                ModelState.AddModelError(string.Empty, "La tabla de marcas está vacía");
                return View();
            }
            if (!await _contexto.Colores.AnyAsync())
            {
                ModelState.AddModelError(string.Empty, "La tabla de modelos está vacía");
                return View();
            }
            if (!await _contexto.Medios.AnyAsync())
            {
                ModelState.AddModelError(string.Empty, "La tabla de áreas está vacía");
                return View();
            }
            if (!await _contexto.EstadoSolicitudes.AnyAsync())
            {
                ModelState.AddModelError(string.Empty, "La tabla de áreas está vacía");
                return View();
            }

            ///<!----------------------  Segundo Grupo de SelectListItems --------------------------->
            ViewBag.ImpresoraId = await _contexto.Impresoras.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CodigoActivoFijo }).ToListAsync();
            ViewBag.EstadoSolicitudId = await _contexto.EstadoSolicitudes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToListAsync();
            ViewBag.ColorId = await _contexto.Colores.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();
            ViewBag.MedioId = await _contexto.Medios.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                string rootPath = _webHostEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                //  Acciones para almacenar las imagenes 
                string fileName = Guid.NewGuid().ToString();
                var pathImageSolicitudes = Path.Combine(rootPath, @"imagenes\solicitudes");

                if (!Directory.Exists(pathImageSolicitudes))
                {
                    var extension = Path.GetExtension(archivos[0].FileName);
                    using (var fileStreams = new FileStream(Path.Combine(pathImageSolicitudes, fileName + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }
                    _contexto.Update(solicitud);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // Devolver listados de Modelos correpondientes a dicha marca
        public JsonResult GetModelos(int marcaId)
        {
            var modelos = _contexto.Modelos.Where(m => m.MarcaId == marcaId).Select(m => new { id = m.Id, nombre = m.Nombre }).ToList();
            return Json(modelos);
        }

        // Devolver listados de unidades correpondientes a dicha área
        public JsonResult GetUnidades(int areaId)
        {
            var unidades = _contexto.Unidades.Where(a => a.AreaId == areaId).Select(a => new { id = a.Id, nombre = a.Nombre }).ToList();
            return Json(unidades);
        }

        // Codigo Video Codigo Oldest & FG
        [HttpGet("{marcaId}/modelo")]
        // Codigo FG  para listado de Modelos en vistas Blazor
        public async Task<List<Modelo>> WhenMarcaChanged2(int marcaId)
        {
            List<SelectListItem> listaMarcas = new List<SelectListItem>();

            {
                return await _contexto.Modelos.Where(m => m.MarcaId == marcaId).OrderBy(m => m.Nombre).ToListAsync();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Impresora impresora)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(impresora);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  //  return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar2(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            var existe = _contexto.Impresoras.Any(e => e.Id == id);
            if (!existe)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            var impresoraEdit = await _contexto.Impresoras.FindAsync(id);
            ViewBag.MarcaId = new SelectList(_contexto.Marcas, "Id", "Nombre", impresoraEdit.MarcaId);
            ViewBag.ModeloId = new SelectList(_contexto.Modelos.Where(m => m.MarcaId == impresoraEdit.MarcaId), "Id", "Nombre", impresoraEdit.ModeloId);
            ViewBag.EstadoId = new SelectList(_contexto.Estados, "Id", "Nombre", impresoraEdit.EstadoId);

            ViewBag.AreaId = new SelectList(_contexto.Areas, "Id", "Nombre", impresoraEdit.AreaId);
            ViewBag.UnidadId = new SelectList(_contexto.Unidades.Where(a => a.AreaId == impresoraEdit.AreaId), "Id", "Nombre", impresoraEdit.UnidadId);
            ViewBag.InstitucionId = new SelectList(_contexto.Instituciones, "Id", "Nombre", impresoraEdit.InstitucionId);
            return View(impresoraEdit);
        }

        // Acción para mostrar el formulario de creación codigo Copiloto 
        // Acción para mostrar el formulario de edición
        public IActionResult EditCop(int id)
        {
            var impresora = _contexto.Impresoras.Find(id);
            if (impresora == null)
            {
                return NotFound();
            }

            ViewBag.MarcaId = _contexto.Marcas.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToList();
            ViewBag.ModeloId = _contexto.Modelos.Where(m => m.MarcaId == 0).Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToList();
            ///<!----------------------  Segundo Grupo de SelectListItems --------------------------->

            ViewBag.AreaId = _contexto.Areas.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList();
            ViewBag.UnidadId = _contexto.Unidades.Where(a => a.AreaId == 0).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToList();
            ///<!----------------------  Segundo Grupo de SelectListItems --------------------------->
            ViewBag.EstadoId = _contexto.Estados.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nombre }).ToList();
            ViewBag.InstitucionId = _contexto.Instituciones.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nombre }).ToList();

            ViewBag.Marcas = new SelectList(_contexto.Marcas, "Id", "Nombre", impresora.MarcaId);
            ViewBag.Modelos = new SelectList(_contexto.Modelos.Where(m => m.MarcaId == impresora.MarcaId), "Id", "Nombre", impresora.ModeloId);
            ViewBag.Estados = new SelectList(_contexto.Estados, "Id", "Nombre", impresora.EstadoId);

            return View(impresora);
        }

        //Endpoints para el borrado (Delete) de registros
        [HttpGet]
        public async Task<IActionResult> Borrar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            var impresoraDisplay = await _contexto.Impresoras
                .Include(ma => ma.Marca)
                .Include(mo => mo.Modelo)
                .Include(a => a.Area)
                .Include(u => u.Unidad)
                .Include(e => e.Estado)
                .Include(i => i.Institucion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impresoraDisplay == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            return View(impresoraDisplay);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]  //Para validar ataques 
        public async Task<IActionResult> BorrarImpresora(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }

            var impresora = await _contexto.Impresoras.FindAsync(id);
            if (impresora == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            // Borrado de registro
            _contexto.Impresoras.Remove(impresora);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Endpoint para el desplegar (Details) de registros
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            var impresoraDisplay = await _contexto.Impresoras
                .Include(ma => ma.Marca)
                .Include(mo => mo.Modelo)
                .Include(a => a.Area)
                .Include(u => u.Unidad)
                .Include(e => e.Estado)
                .Include(i => i.Institucion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impresoraDisplay == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            return View(impresoraDisplay);
        }

        // Falla, podría ser el codigo JavaScript 
        [HttpGet]
        public JsonResult GetModelosByMarcaId(int marcaId)
        {
            var modelos = _contexto.Modelos.Where(m => m.MarcaId == marcaId).Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToList();
            return Json(modelos);
        }

    }
}
