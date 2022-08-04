using Cms.Core.Interfaces.Repository;
using CategoryDomain = Cms.Core.Domains.Category;
using CategoryEntity = Cms.Infrastructure.Entities.Category;

namespace Cms.Infrastructure.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public CmsDbContext _cmsDbContext { get; }
        public CategoryRepository(CmsDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }
        public int Add(CategoryDomain category)
        {
            var dbModel = new CategoryEntity
            {
                CreatedDate = DateTime.Now,
                Title = category.Title
            };
            _cmsDbContext.Categories.Add(dbModel);

            _cmsDbContext.SaveChanges();

            return dbModel.Id;
        }



        public void Delete(int id)
        {
            var finded = GetCategory(id);

            _cmsDbContext.Remove(finded);
            _cmsDbContext.SaveChanges();
        }

        public void Edit(CategoryDomain category)
        {
            var finded = GetCategory(category.Id);
            finded.Title = category.Title;

            _cmsDbContext.Categories.Update(finded);
            _cmsDbContext.SaveChanges();
        }

        public List<CategoryDomain> GetAll()
        {
            return _cmsDbContext.Categories.Select(x => new CategoryDomain
            {
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                Id = x.Id
            }).ToList();
        }

        public CategoryDomain GetById(int id)
        {
            var item = _cmsDbContext.Categories.Select(x => new CategoryDomain
            {
                Id = x.Id,
                Title = x.Title,
                CreatedDate = x.CreatedDate
            }).FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }

        private CategoryEntity GetCategory(int id)
        {
            var item = _cmsDbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }
    }
}
