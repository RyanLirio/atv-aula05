using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace Aula05.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;
        private readonly IWebHostEnvironment environment;

        public ProductController(IWebHostEnvironment environment)
        {
            _productRepository = new ProductRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _productRepository.RetrieveAll();

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(Product c)
        {
            _productRepository.Save(c);
            List<Product> products = _productRepository.RetrieveAll();

            return View("Index", products);
        }

        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            string fileContent = string.Empty;

            foreach (Product p in CustomerData.Products)
            {
                fileContent += $"{p.Id}; {p.ProductName}; {p.Description}; {p.CurrentPrice}; \n";
            }

            var path = Path.Combine(
                environment.WebRootPath,
                "TextFiles"
                );

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            var filepath = Path.Combine(
                path,
                "Delimitado.txt"
                );

            if (!System.IO.File.Exists(filepath)) // Vai verificar se o arquivo que estamos criando já não existe
            {
                using (StreamWriter sw = System.IO.File.CreateText(filepath))
                {
                    sw.Write(fileContent);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id.Value < 0)
                return NotFound();

            Product product = _productRepository.Retrieve(id.Value);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id is null || id.Value < 0)
                return NotFound();

            if (!_productRepository.DeleteById(id.Value))
                return NotFound();



            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id is null || id.Value < 0)
                return NotFound();

            Product product = _productRepository.Retrieve(id.Value);

            if (product == null)
                return NotFound();

            return View(product);
        }

        public IActionResult ConfirmUpdate(int? id)
        {
            return View();
        }
    }
}
