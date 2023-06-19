using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Interfaces;
using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.Pages
{
    public class PhotosToPostModel : PageModel
    {
        private readonly IFileUploadService _uploadService;
        private readonly IBlogService _blogService;

        public PhotosToPostModel(IFileUploadService uploadService, IBlogService blogService)
        {
            _uploadService = uploadService;
            _blogService = blogService;  
        }

        public IQueryable<Photo>? Photos { get; set; }

        [BindProperty] 
        public Photo Photo { get; set; }

        [BindProperty]
        public int tmpId { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            tmpId = id;
            Photos = _blogService.GetPhotosByPostId(id);

            return Page();

        }

        public IActionResult OnPostAsync()
        { 
            _blogService.AddPhotoToPost(Photo);
            
            OnGet(tmpId);
            return Redirect("/PhotosToPost?id=" + Photo.PostId.ToString());
        }
    }
}
