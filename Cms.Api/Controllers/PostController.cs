using Cms.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        public IPostRepository _postRepository { get; }
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        // Post/GetLatestPosts
        [HttpGet("GetLatestPosts")]
        public async Task<IActionResult> GetLatestPosts()
        {
            return Ok(await _postRepository.GetLatestPosts(10));
        }

    }
}