using Microsoft.AspNetCore.Mvc;
using MvcCore.Models.Domain;

namespace MvcCore.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            return View();
        }
    }
}
