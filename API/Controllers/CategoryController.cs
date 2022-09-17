using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    public class CategoryController : BaseController
    {
        private IUnitOfWork _uw;
        private ILogger<CategoryController> _logger;

        public CategoryController(IUnitOfWork uw, ILogger<CategoryController> logger)
        {
            this._uw = uw ?? throw new ArgumentNullException(nameof(IUnitOfWork));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region "API"

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await _uw.CategoryRepo.GetAll();
            if (categories.Any())
            {
                return Ok(categories);
            }
            else
            {
                _logger.LogError($"No {nameof(Category)} found");
                return NotFound($"No {nameof(Category)} found");
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Category>> Get(int Id)
        {
            var category = await _uw.CategoryRepo.GetFirstOrDefault(cat => cat.Id == Id);
            if (category != null)
            {
                return category;
            }
            else
            {
                _logger.LogError($"{nameof(Category)} with Id {Id} not found");
                return base.NotFound($"{nameof(Category)} with Id {Id} not found");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _uw.CategoryRepo.Add(category);
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
        public ActionResult<Category> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _uw.CategoryRepo.Update(category);
                _uw.Save();
                return category;

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
            var category = _uw.CategoryRepo.GetFirstOrDefault(c => c.Id == Id).Result;
            if (category == null)
            {
                return NotFound();
            }
            _uw.CategoryRepo.Remove(category);
            _uw.Save();
            return Ok("Category deleted");
        }

        #endregion

    }
}
