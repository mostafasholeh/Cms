using Cms.Core.Domains;

namespace Cms.Core.Interfaces.Repository
{
    public interface IPostRepository
    {
        Task<List<Post>> GetLatestPosts(int count);
    }
}
