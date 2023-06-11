using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Interfaces;
using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.Pages
{
    [Authorize]
    public class PostModel : PageModel
    {
        public readonly IBlogService _blogService;
        public readonly UserManager<IdentityUser> _userManager;

        public PostModel(IBlogService blogService, UserManager<IdentityUser> userManager) 
        { 
            _blogService = blogService;
            _userManager = userManager; 
        }

        public Post Post { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if(id == null && _blogService == null)
            {
                return NotFound();
            }

            Post = _blogService.GetPostById(id);

            if(Post == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
