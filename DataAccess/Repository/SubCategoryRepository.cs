using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models.Entities;

namespace DataAccess.Repository
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private ECommerceDbContext _db;
        public SubCategoryRepository(ECommerceDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SubCategory subCategory)
        {
            _db.Update(subCategory);
        }
    }
}