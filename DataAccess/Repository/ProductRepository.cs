using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models.Entities;

namespace DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ECommerceDbContext _db;
        public ProductRepository(ECommerceDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            Product producFromDb = _db.Products.SingleOrDefault(p => p.Id == product.Id);
            if (producFromDb != null)
            {
                producFromDb.Name = product.Name;
                producFromDb.Description = product.Description;
                producFromDb.Price = product.Price;
                producFromDb.CategoryId = product.CategoryId;
                producFromDb.SubCategoryId = product.SubCategoryId;
                producFromDb.Quantity = product.Quantity;
                if (!string.IsNullOrEmpty(product.PictureUrl))
                {
                    producFromDb.PictureUrl = product.PictureUrl;
                }
            }
        }
    }
}
