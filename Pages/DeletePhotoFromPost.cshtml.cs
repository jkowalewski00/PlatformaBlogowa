using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatformaBlogowa.Data;
using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.Pages
{
    public class DeletePhotoFromPostModel : PageModel
    {
        private readonly PlatformaBlogowa.Data.ApplicationDbContext _context;

        public DeletePhotoFromPostModel(PlatformaBlogowa.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Photo Photo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos.FirstOrDefaultAsync(m => m.Id == id);

            if (photo == null)
            {
                return NotFound();
            }
            else 
            {
                Photo = photo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }
            var photo = await _context.Photos.FindAsync(id);
            var postId = photo.PostId.ToString();

            if (photo != null)
            {
                Photo = photo;
                _context.Photos.Remove(Photo);
                await _context.SaveChangesAsync();
            }

            return Redirect("/PhotosToPost?id=" + postId);
        }
    }
}
