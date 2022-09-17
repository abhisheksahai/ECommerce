using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    public class SubCategoryController : BaseController
    {
        private IUnitOfWork _uw;
        private ILogger<SubCategoryController> _logger;

        public SubCategoryController(IUnitOfWork uw, ILogger<SubCategoryController> logger)
        {
            this._uw = uw ?? throw new ArgumentNullException(nameof(IUnitOfWork));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region "API"

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategory>>> Get()
        {
            var subCategories = await _uw.SubCategoryRepo.GetAll();
            if (subCategories.Any())
            {
                return Ok(subCategories);
            }
            else
            {
                _logger.LogError($"No {nameof(SubCategory)} found");
                return NotFound($"No {nameof(SubCategory)} found");
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<SubCategory>> Get(int Id)
        {
            var subCategory = await _uw.SubCategoryRepo.GetFirstOrDefault(cat => cat.Id == Id);
            if (subCategory != null)
            {
                return subCategory;
            }
            else
            {
                _logger.LogError($"{nameof(SubCategory)} with Id {Id} not found");
                return base.NotFound($"{nameof(SubCategory)} with Id {Id} not found");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SubCategory>> Create(SubCategory category)
        {
            if (ModelState.IsValid)
            {
                await _uw.SubCategoryRepo.Add(category);
                _uw.Save();
                return category;

            }
            else
            {
                _logger.LogError($"Bad request");
                return base.BadRequest();
            }
        }

        [HttpPut]
        public ActionResult<SubCategory> Edit(SubCategory subCategory)
        {
            var subCategoryFromDb = _uw.SubCategoryRepo.GetFirstOrDefault(c => c.Id == subCategory.Id).Result;
            if (subCategoryFromDb == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _uw.SubCategoryRepo.Update(subCategory);
                _uw.Save();
                return subCategory;

            }
            else
            {
                _logger.LogError($"Bad request");
                return base.BadRequest();
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int? Id)
        {
            var subCategory = _uw.SubCategoryRepo.GetFirstOrDefault(c => c.Id == Id).Result;
            if (subCategory == null)
            {
                return NotFound();
            }
            _uw.SubCategoryRepo.Remove(subCategory);
            _uw.Save();
            return Ok("Subcategory deleted");
        }

        #endregion

    }
}
