using Cms.Core.Domains;

namespace Cms.Core.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        // CRUD
        Category GetById(int id);
        List<Category> GetAll();
        int Add(Category category);
        void Edit(Category category);
        void Delete(int i);

    }
}
