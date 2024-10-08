using DataBaseInMemory.DataContext;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaPlatec.Models;
using PruebaTecnicaPlatec.Repositorios;
using System.Net;

namespace PruebaTecnicaPlatec.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {        
        private readonly ILogger<ProductController> _logger;

        readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Obtener una lista de todos los productos.
        /// </summary>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetProducts();
        }

        /// <summary>
        /// Obtener un producto por su ID.
        /// </summary>
        [HttpGet("{id}")]
        public Product GetProductsId(int id)
        {
            return _productRepository.GetProductsId(id);
        }

        /// <summary>
        /// Crear un nuevo producto 
                /// </summary>
                [HttpPost]
        public HttpStatusCode Post(Product product)
        {
            if (_productRepository.PostProduct(product).Equals("OK"))
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }

        }

        /// <summary>
        /// Eliminar un producto por su ID.
        /// </summary>
        [HttpDelete]
        public HttpStatusCode Delete(int id)
        {
            if (_productRepository.DeleteProduct(id).Equals("OK"))
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }

        }

        /// <summary>
        /// Actualizar un producto existente.
        /// </summary>
        [HttpPut]
        public HttpStatusCode Put(Product product)
        {
            if (_productRepository.PutProduct(product).Equals("OK"))
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }

        }

    }
}
