using Microsoft.AspNetCore.Mvc;
using MvcCore.Models.Domain;

namespace MvcCore.Controllers
{
    public class PersonController : Controller
    {
        public DatabaseContext Ctx { get; }

        public PersonController(DatabaseContext _ctx)
        {
            Ctx = _ctx;
        }

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
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                Ctx.Person.Add(person);
                Ctx.SaveChanges();
                TempData["msg"] = "Added successfuly.";
                return RedirectToAction("AddPerson");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Error during saving.";
                return View();
            }
        }



        public IActionResult DisplayPersons() 
        {
            var Persons = Ctx.Person.ToList();
            return View(Persons);
        }

        public IActionResult DeletePerson(int id) 
        {
            try
            {
                var person = Ctx.Person.Find(id);
                if (person != null)
                {
                    Ctx.Person.Remove(person);
                    Ctx.SaveChanges();
                    TempData["msg"] = "Deleted successfuly.";
                    return RedirectToAction("DisplayPersons");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Deleted successfuly.";
                return View();
            }
            return RedirectToAction("DisplayPersons");
        }

        public IActionResult EditPerson(int id) 
        {
            var person = Ctx.Person.Find(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                Ctx.Person.Update(person);
                Ctx.SaveChanges();
                TempData["msg"] = "Updated successfuly.";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Error during updating.";
                return View();
            }
        }
    }
}
