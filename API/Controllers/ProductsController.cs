using API.Settings;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.ViewModels;
using Utility;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private IUnitOfWork _uw;
        private IWebHostEnvironment _whe;
        private ILogger<ProductsController> _logger;

        public ProductsController(IUnitOfWork uw, IWebHostEnvironment whe, ILogger<ProductsController> logger)
        {
            this._uw = uw ?? throw new ArgumentNullException(nameof(IUnitOfWork));
            this._whe = whe ?? throw new ArgumentNullException(nameof(IWebHostEnvironment));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region "API"

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _uw.ProductRepo.GetAll(includeProperties: "Category,SubCategory");
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
        public async Task<ActionResult<Product>> Get(int Id)
        {
            var product = await _uw.ProductRepo.GetFirstOrDefault(prod => prod.Id == Id, includeProperties: "Category,SubCategory");
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

        [HttpPost]
        public async Task<IActionResult> Upsert([FromForm] ProductUpsert productVM)
        {
            if (ModelState.IsValid)
            {
                productVM.PictureUrl = await FileUtility.UploadFile(_whe.WebRootPath, ApiHelper.GetFileUploadPath(), productVM.FormFile, productVM.PictureUrl);

                Product product = new()
                {
                    Id = productVM.Id,
                    Code = productVM.Code,
                    Name = productVM.Name,
                    Quantity = productVM.Quantity,
                    Price = productVM.Price,
                    Description = productVM.Description,
                    CategoryId = productVM.CategoryId,
                    SubCategoryId = productVM.SubCategoryId,
                    PictureUrl = productVM.PictureUrl
                };
                if (productVM.Id == 0)
                {
                    await _uw.ProductRepo.Add(product);
                }
                else
                {
                    _uw.ProductRepo.Update(product);
                }
                _uw.Save();
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int? Id)
        {
            var productFromDb = await _uw.ProductRepo.GetFirstOrDefault(prod => prod.Id == Id);
            if (productFromDb == null)
            {
                return base.NotFound($"{nameof(Product)} with Id {Id} not found");
            }
            else
            {
                FileUtility.DeleteFile(_whe.WebRootPath, productFromDb.PictureUrl);
                _uw.ProductRepo.Remove(productFromDb);
                _uw.Save();
                return Ok($"{productFromDb.Name} deleted");
            }
        }

        #endregion
    }
}