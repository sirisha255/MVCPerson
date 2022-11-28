using Microsoft.AspNetCore.Mvc;
using MVCPerson.Models.Repos;
using MVCPerson.Models.Services;

namespace MVCPerson.Controllers
{
    public class AjaxController : Controller
    {
        IPeopleService _peopleService;
        
        public AjaxController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
