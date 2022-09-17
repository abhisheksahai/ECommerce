using Models.Entities;

namespace DataAccess.Repository.IRepository
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        void Update(SubCategory subCategory);
    }
}