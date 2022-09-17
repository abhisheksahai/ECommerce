namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepo { get; }

        ICategoryRepository CategoryRepo { get; }

        ISubCategoryRepository SubCategoryRepo { get; }

        void Save();
    }
}