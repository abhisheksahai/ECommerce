using DataAccess.Data;
using DataAccess.Repository.IRepository;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepo { get; private set; }

        public ISubCategoryRepository SubCategoryRepo { get; private set; }

        public IProductRepository ProductRepo { get; private set; }

        private ECommerceDbContext _db;

        public UnitOfWork(ECommerceDbContext db)
        {
            _db = db;
            ProductRepo = new ProductRepository(_db);
            CategoryRepo = new CategoryRepository(_db);
            SubCategoryRepo = new SubCategoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
