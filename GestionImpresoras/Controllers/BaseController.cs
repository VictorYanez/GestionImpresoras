using Microsoft.AspNetCore.Mvc;

namespace GestionImpresoras.Controllers
{
    public class BaseController : Controller
    {
        protected void ShowAlert(string alertType, string alertTitle, string alertMessage)
        {
            TempData["AlertType"] = alertType;
            TempData["AlertTitle"] = alertTitle;
            TempData["AlertMessage"] = alertMessage;
        }
    }

}
