namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepo { get; }

        ICategoryRepository CategoryRepo { get; }

        void Save();
    }
}