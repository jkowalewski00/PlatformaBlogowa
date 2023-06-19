using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using PlatformaBlogowa.Models;
using System.Security.Claims;

namespace PlatformaBlogowa.Pages
{
    [Authorize]
    public class PostModel : PageModel
    {
        public readonly IBlogService _blogService;
        public readonly UserManager<IdentityUser> _userManager;
        public readonly IConfiguration _configuration;

        public PostModel(IBlogService blogService, UserManager<IdentityUser> userManager, IConfiguration configuration) 
        { 
            _blogService = blogService;
            _userManager = userManager; 
            _configuration = configuration;
        }

        public Post Post { get; set; }

        [BindProperty]
        public Comment Comment { get; set; }

        public IQueryable<Comment>? Comments { get; set; }

        public string CurrentUser { get; set; }

        public string Username { get; set; }    

        public IActionResult OnGetAsync(int id)
        {
            if(id == null && _blogService == null)
            {
                return NotFound();
            }
            CurrentUser = _userManager.GetUserId(User);
            Username = _userManager.GetUserName(User);
            Post = _blogService.GetPostById(id);
            Comments = _blogService.GetCommentByPostId(id);

            if(Post == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(ClaimsIdentity user)
        {
            Comment.UserId = _userManager.GetUserId(User);
            Comment.CreatedDate = DateTime.Now;
            Comment.Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            _blogService.AddComment(Comment);
            OnGetAsync(Comment.PostId);
            return Page();
        }
        
    }
}
