using GestionImpresoras.Data;
using GestionImpresoras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionImpresoras.Services;
using GestionImpresoras.DTOs;

namespace GestionImpresoras.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly ApplicationDBContext _contexto;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EmailService _emailService;
        private readonly String folderSolicitudes = @"imagenes\solicitudes";

        public SolicitudesController(ApplicationDBContext contexto, IWebHostEnvironment webHostEnvironment, EmailService emailService)
        {
            this._contexto = contexto;
            this._webHostEnvironment = webHostEnvironment;
            this._emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lista = await _contexto.Solicitudes
                .Include(x => x.Impresora)
                // .ThenInclude(i => i.CodigoActivoFijo) // Cargar el CodigoActivoFijo de Impresora
                .Include(x => x.Color)
                .Include(x => x.EstadoSolicitud)
                .ToListAsync();
            return View(lista);
        }
    

    // Metodos GET POST Solicitudes Crear
    [HttpGet]
    public async Task<IActionResult> Create()
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
    public async Task<IActionResult> Create(Solicitud solicitud)
    {
        if (ModelState.IsValid)
        {
            //  Capturo los archivos seleccionados 
            var archivos = HttpContext.Request.Form.Files;
            string rootPath = _webHostEnvironment.WebRootPath;
            // Verifica si se está cargando un archivo
            if (archivos.Count > 0)
            {
                // Para verificar si el directorio existe  
                var pathFullSolicitudes = System.IO.Path.Combine(rootPath, folderSolicitudes);
                if (!Directory.Exists(pathFullSolicitudes))
                {
                    Directory.CreateDirectory(pathFullSolicitudes);
                }
                // Almacena el archivo en el servidor
                string fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(archivos[0].FileName).ToLower(); ;
                if (extension != ".png" && extension != ".jpg" && extension != ".jpeg")
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                using (var fileStreams = new FileStream(Path.Combine(pathFullSolicitudes, fileName + extension), FileMode.Create))
                {
                    await archivos[0].CopyToAsync(fileStreams);
                }
                String bslash = @"\";
                solicitud.UrlImagen = bslash + folderSolicitudes + bslash + fileName + extension;
                //solicitud.FechaSolicitud = DateTime.Now;
            }
            _contexto.Solicitudes.Add(solicitud);
            await _contexto.SaveChangesAsync();

                // Obtener la información para el correo
                var emailData = await GetEmailData(solicitud.Id);
                if (emailData != null)
                {
                    await _emailService.SendEmail("registro", solicitud, emailData);
                }
               
            return RedirectToAction(nameof(Index));
        }
        ///<!----------------------  Grupo de SelectListItems --------------------------->
        ViewBag.ImpresoraId = await _contexto.Impresoras.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CodigoActivoFijo }).ToListAsync();
        ViewBag.EstadoSolicitudId = await _contexto.EstadoSolicitudes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToListAsync();
        ViewBag.ColorId = await _contexto.Colores.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();
        ViewBag.MedioId = await _contexto.Medios.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();
        return View();
    }
        private async Task<EmailData> GetEmailData(int solicitudId)
        {
            var solicitud = await _contexto.Solicitudes
                .Include(x => x.Impresora)
                .Include(x => x.Color)
                .Include(x => x.EstadoSolicitud)
                .FirstOrDefaultAsync(x => x.Id == solicitudId);

            if (solicitud != null)
            {
                var emailData = new EmailData
                {
                    FechaSolicitud = solicitud.FechaSolicitud,
                    Solicitante = solicitud.Solicitante,
                    Correo = solicitud.Email,
                    ImpresoraCodigo = solicitud.Impresora.CodigoActivoFijo,
                    ColorNombre = solicitud.Color.Nombre,
                    EstadoSolicitudNombre = solicitud.EstadoSolicitud.Nombre
                };
                return emailData;
            }

            return null;
        }
        // ----------------->>>>>   Metodos GET POST Solicitudes Editar
        [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Noencontrado", "Home");
        }
        else
        {
            var itemDisplay = await _contexto.Solicitudes.FindAsync(id);
            if (itemDisplay == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }
            else
            {
                ///<!----------------------   Grupo de SelectListItems --------------------------->
                ViewBag.ImpresoraId = await _contexto.Impresoras.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CodigoActivoFijo }).ToListAsync();
                ViewBag.EstadoSolicitudId = await _contexto.EstadoSolicitudes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToListAsync();
                ViewBag.ColorId = await _contexto.Colores.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();
                ViewBag.MedioId = await _contexto.Medios.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();

                return View(itemDisplay);
            }
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Solicitud solicitud)
    {
        if (ModelState.IsValid)
        {
            //  Capturo los archivos seleccionados 
            var archivos = HttpContext.Request.Form.Files;
            string rootPath = _webHostEnvironment.WebRootPath;
            string ToRemove = null;
            if (!String.IsNullOrEmpty(solicitud.UrlImagen))
            {
                ToRemove = Path.Combine(rootPath, solicitud.UrlImagen);
            }
            // Verifica si se está cargando un archivo
            if (archivos.Count > 0)
            {
                // Para verificar si el directorio existe  
                var pathFullSolicitudes = System.IO.Path.Combine(rootPath, folderSolicitudes);
                if (!Directory.Exists(pathFullSolicitudes))
                {
                    Directory.CreateDirectory(pathFullSolicitudes);
                }
                // Almacena el archivo en el servidor
                string fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(archivos[0].FileName).ToLower(); ;
                if (extension != ".png" && extension != ".jpg" && extension != ".jpeg")
                {
                    return RedirectToAction("Noencontrado", "Home");
                }
                // ------------>>>>>>>  Eliminar archivo anterior   <<<<<<<<------------------- 
                if (System.IO.File.Exists(ToRemove))
                {
                    System.IO.File.Delete(ToRemove);
                }
                // ------------>>>>>>>  Almacenar nuevo archivo   <<<<<<<<------------------- 
                using (var fileStreams = new FileStream(Path.Combine(pathFullSolicitudes, fileName + extension), FileMode.Create))
                {
                    await archivos[0].CopyToAsync(fileStreams);
                }
                String bslash = @"\";
                solicitud.UrlImagen = bslash + folderSolicitudes + bslash + fileName + extension;
                //solicitud.FechaSolicitud = DateTime.Now;
            }
            _contexto.Solicitudes.Update(solicitud);
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

    //Endpoints GET/POST para el borrado (Delete) de registros
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Noencontrado", "Home");
        }
        var impresoraDisplay = await _contexto.Solicitudes
            .Include(i => i.Impresora)
            .Include(es => es.EstadoSolicitud)
            .Include(c => c.Color)
            .Include(m => m.Medio)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (impresoraDisplay == null)
        {
            return RedirectToAction("Noencontrado", "Home");
        }

        ///<!----------------------   Grupo de SelectListItems --------------------------->
        ViewBag.ImpresoraId = await _contexto.Impresoras.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CodigoActivoFijo }).ToListAsync();
        ViewBag.EstadoSolicitudId = await _contexto.EstadoSolicitudes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToListAsync();
        ViewBag.ColorId = await _contexto.Colores.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();
        ViewBag.MedioId = await _contexto.Medios.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();

        return View(impresoraDisplay);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]  //Para validar ataques 
    public async Task<IActionResult> DeleteImpresora(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Noencontrado", "Home");
        }
        var itemDisplay = await _contexto.Solicitudes.FindAsync(id);
        if (itemDisplay == null)
        {
            return RedirectToAction("Noencontrado", "Home");
        }

        string rootPath = _webHostEnvironment.WebRootPath;
        var archivos = HttpContext.Request.Form.Files;
        var pathImagesSolicitudes = Path.Combine(rootPath, folderSolicitudes);
        var fileToDelete = itemDisplay.UrlImagen;

        // Borrado de la imagen en el sistema de imagenes 
        if (System.IO.File.Exists(fileToDelete))
        {
            System.IO.File.Delete(fileToDelete);
        }
        // Borrado de registro en la base de datos 
        _contexto.Solicitudes.Remove(itemDisplay);
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
        var impresoraDisplay = await _contexto.Solicitudes
            .Include(i => i.Impresora)
            .Include(es => es.EstadoSolicitud)
            .Include(c => c.Color)
            .Include(m => m.Medio)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (impresoraDisplay == null)
        {
            return RedirectToAction("Noencontrado", "Home");
        }
        ///<!----------------------   Grupo de SelectListItems --------------------------->
        ViewBag.ImpresoraId = await _contexto.Impresoras.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CodigoActivoFijo }).ToListAsync();
        ViewBag.EstadoSolicitudId = await _contexto.EstadoSolicitudes.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToListAsync();
        ViewBag.ColorId = await _contexto.Colores.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();
        ViewBag.MedioId = await _contexto.Medios.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre }).ToListAsync();

        return View(impresoraDisplay);
    }
}
}
