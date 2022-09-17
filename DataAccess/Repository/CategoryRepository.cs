using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models.Entities;

namespace DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ECommerceDbContext _db;
        public CategoryRepository(ECommerceDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}