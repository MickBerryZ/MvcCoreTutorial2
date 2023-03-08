using Microsoft.AspNetCore.Mvc;
using MvcCoreTutorial2.Models.Domain;

namespace MvcCoreTutorial2.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
            
        public PersonController(DatabaseContext ctx) 
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.greeting = "Hello world";
            ViewData["greeting2"] = "I am using ViewData";
            //ViewBag and ViewData can send data only from ControllerToView

            //Tempdata can send data from ome controller method to another controller
            TempData["greeting3"] = "It's temData msg";
            return View();
        }

        // IT is get method
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Added successfully";
                return RedirectToAction("AddPerson");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added!!!";
                return View();
            }
        }
    }
}
