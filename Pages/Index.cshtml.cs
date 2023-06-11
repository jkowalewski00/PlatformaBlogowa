using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Interfaces;
using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogService _blogService;

        public IndexModel(ILogger<IndexModel> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }

        public IQueryable<Post> Posts { get; set; }

        public void OnGet()
        {
            if(_blogService != null)
            {
                Posts = _blogService.GetPosts();
            }
        }


    }
}