using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Interfaces;
using PlatformaBlogowa.Models;
using System.Security.Claims;

namespace PlatformaBlogowa.Pages
{
    [Authorize]
    public class AddPostModel : PageModel
    {
        private readonly IBlogService _blogService;
        private readonly UserManager<IdentityUser> _userManager;

        public AddPostModel(IBlogService blogService, UserManager<IdentityUser> userManager) 
        {
            _blogService = blogService;
            _userManager = userManager;
        }

        [BindProperty]
        public Post Post { get; set; }

        public IList<Photo>? Photos { get; set; }

        public IActionResult OnPost(ClaimsPrincipal user)
        {
            if(Post.Title != null && Post.Description != null)
            {
                Post.Date = DateTime.Now;
                Post.UserName = _userManager.GetUserName(User);
                Post.UserId = _userManager.GetUserId(User);
                _blogService.AddPost(Post);
            } 
            
            return Page();
        }

        public void OnGet()
        {
            
        }


    }
}
