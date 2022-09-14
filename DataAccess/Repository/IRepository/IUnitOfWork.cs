namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepo { get; }

        void Save();
    }
}