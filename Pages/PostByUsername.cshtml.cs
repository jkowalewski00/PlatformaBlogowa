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
    public class PostByUsernameModel : PageModel
    {
        private readonly PlatformaBlogowa.Data.ApplicationDbContext _context;

        public PostByUsernameModel(PlatformaBlogowa.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        public void OnGetAsync(string username)
        {
            if (_context.Posts != null)
            {
                Post = (IList<Post>)_context.Posts.Where(p => p.UserName == username).OrderByDescending(p => p.Date).ToList();
            }
        }
    }
}
