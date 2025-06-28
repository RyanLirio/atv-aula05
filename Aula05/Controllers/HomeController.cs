using System.Diagnostics;
using Aula05.Models;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace Aula05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private Order _order;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Customer c1 = new Customer();
            c1.Name = "Frodo";
            c1.ObjectCount++;
            Customer.InstanceCount++;

            var c2 = new Customer();
            c2.Name = "Galadriel";
            c2.ObjectCount++;
            Customer.InstanceCount++;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
