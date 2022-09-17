using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private IUnitOfWork _uw;
        private ILogger<ProductsController> _logger;

        public ProductsController(IUnitOfWork uw, ILogger<ProductsController> logger)
        {
            this._uw = uw ?? throw new ArgumentNullException(nameof(IUnitOfWork));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region "API"

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _uw.ProductRepo.GetAll();
            if (products.Any())
            {
                return Ok(products);
            }
            else
            {
                _logger.LogError($"No {nameof(Product)} found");
                return NotFound($"No {nameof(Product)} found");
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            var product = await _uw.ProductRepo.GetFirstOrDefault(prod => prod.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                _logger.LogError($"{nameof(Product)} with Id {Id} not found");
                return base.NotFound($"{nameof(Product)} with Id {Id} not found");
            }
        }

        #endregion
    }
}
