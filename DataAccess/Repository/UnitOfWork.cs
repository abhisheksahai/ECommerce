using DataAccess.Data;
using DataAccess.Repository.IRepository;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepo { get; private set; }

        private ECommerceDbContext _db;

        public UnitOfWork(ECommerceDbContext db)
        {
            _db = db;
            ProductRepo = new ProductRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
