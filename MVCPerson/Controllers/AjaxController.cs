using Microsoft.AspNetCore.Mvc;

namespace MVCPerson.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
