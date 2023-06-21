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
        // Metodos GET POST Solicitudes Crear
        [HttpGet]
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
            ///<!----------------------  Grupo de SelectListItems --------------------------->
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

                // Verifica si se está cargando un archivo
                if (archivos.Count > 0)
                {
                    //  Acciones para almacenar las imagenes 
                    var pathImagesSolicitudes = Path.Combine(rootPath, @"imagenes\solicitudes");

                    // Para verificar si el directorio existe 
                    if (!Directory.Exists(pathImagesSolicitudes))
                    {
                        // Crea el directorio si no existe
                        Directory.CreateDirectory(pathImagesSolicitudes);
                    }
                    // Almacena el archivo en el servidor
                    string fileName = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(pathImagesSolicitudes, fileName + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    solicitud.UrlImagen = Path.Combine(pathImagesSolicitudes, fileName + extension);
                }
                    _contexto.Solicitudes.Add(solicitud);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ///<!----------------------  Grupo de SelectListItems --------------------------->
                ViewBag.ImpresoraId = await _contexto.Impresoras.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CodigoActivoFijo }).ToListAsync();
                ViewBag.EstadoSolicitudId = await _contexto.EstadoSolicitudes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToListAsync();
                ViewBag.ColorId = await _contexto.Colores.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();
                ViewBag.MedioId = await _contexto.Medios.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();
                return View();
            }
            // Metodos GET POST Solicitudes Editar
            [HttpGet]
            public async Task<IActionResult> Editar(int? id)
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
                    else
                    {
                        var impresoraEdit = await _contexto.Impresoras.FindAsync(id);
                        ///<!----------------------   Grupo de SelectListItems --------------------------->
                        ViewBag.ImpresoraId = await _contexto.Impresoras.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CodigoActivoFijo }).ToListAsync();
                        ViewBag.EstadoSolicitudId = await _contexto.EstadoSolicitudes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToListAsync();
                        ViewBag.ColorId = await _contexto.Colores.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();
                        ViewBag.MedioId = await _contexto.Medios.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();

                        return View(impresoraEdit);
                    }
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

            //Endpoints GET/POST para el borrado (Delete) de registros
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
