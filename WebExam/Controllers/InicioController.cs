using Microsoft.AspNetCore.Mvc;

namespace WebExam.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Login()
        {          
            
            return View();
        }

        public IActionResult Usuarios(int estatus , string usuario)
        {
            
            return View();
        }

        public IActionResult Medicina(int estatus, string usuario)
        {
        
            return View();
        }

    }
}
