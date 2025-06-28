using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;
using System.IO;

namespace Aula05.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly CustomerRepository _customerRepository;

        public CustomerController(IWebHostEnvironment environment)
        {
            _environment = environment;
            _customerRepository = new CustomerRepository();
        }

        // ========================
        // AÇÕES - LISTAGEM & FORMULÁRIOS
        // ========================

        [HttpGet]
        public IActionResult Index()
        {
            var customers = _customerRepository.RetrieveAll();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id < 0)
                return NotFound();

            var customer = _customerRepository.Retrieve(id.Value);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // ========================
        // AÇÕES - ENVIO DE FORMULÁRIOS
        // ========================

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            _customerRepository.Save(c);

            var customers = _customerRepository.RetrieveAll();
            return View("Index", customers);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id is null || id < 0)
                return NotFound();

            if (!_customerRepository.DeleteById(id.Value))
                return NotFound();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update()
        {
            // Ainda não implementado
            return View();
        }

        // ========================
        // AÇÕES - EXPORTAÇÃO DE ARQUIVOS
        // ========================

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            string content = string.Empty;

            foreach (var c in CustomerData.Customers)
            {
                content += $"{c.Id}; {c.Name}; {c.HomeAddress!.Id}; {c.HomeAddress.City}; {c.HomeAddress.StateProvince}; {c.HomeAddress.Country}; {c.HomeAddress.StreetLine1}; {c.HomeAddress.StreetLine2}; {c.HomeAddress.PostalCode}; {c.HomeAddress.AddressType} \n";
            }

            SaveFile(content, "DelimitedFile.txt");

            return View();
        }

        [HttpGet]
        public IActionResult ExportFixedFile()
        {
            string content = string.Empty;

            foreach (var c in CustomerData.Customers)
            {
                content +=
                    string.Format("{0,-5}", c.Id) +
                    string.Format("{0,-64}", c.Name) +
                    string.Format("{0,-5}", c.HomeAddress!.Id) +
                    string.Format("{0,-32}", c.HomeAddress.City) +
                    string.Format("{0,-2}", c.HomeAddress.StateProvince) +
                    string.Format("{0,-32}", c.HomeAddress.Country) +
                    string.Format("{0,-64}", c.HomeAddress.StreetLine1) +
                    string.Format("{0,-64}", c.HomeAddress.StreetLine2) +
                    string.Format("{0,-9}", c.HomeAddress.PostalCode) +
                    string.Format("{0,-16}", c.HomeAddress.AddressType) + "\n";
            }

            SaveFile(content, "FixedFile.txt");

            return RedirectToAction("Index");
        }

        private bool SaveFile(string content, string fileName)
        {
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(fileName))
                return false;

            var directoryPath = Path.Combine(_environment.WebRootPath, "TextFiles");

            try
            {
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                var fullPath = Path.Combine(directoryPath, fileName);

                if (!System.IO.File.Exists(fullPath))
                {
                    using var sw = System.IO.File.CreateText(fullPath);
                    sw.Write(content);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
