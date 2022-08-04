using Cms.Core.Domains;
using Cms.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cms.Infrastructure.Data.Repository
{
    public class PostRepository : IPostRepository
    {
        public CmsDbContext _cmsDbContext { get; }
        public PostRepository(CmsDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }
        public async Task<List<Post>> GetLatestPosts(int count)
        {
            return await _cmsDbContext.Posts
                .Select(x => new Post   // Auto Mapper
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate
                })
                .OrderByDescending(x => x.CreatedDate)
                .Take(count)
                .ToListAsync();
        }
    }
}
