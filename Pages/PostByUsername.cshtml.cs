using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatformaBlogowa.Data;
using PlatformaBlogowa.Models;
using Microsoft.Extensions.Configuration;

namespace PlatformaBlogowa.Pages
{
    public class PostByUsernameModel : PageModel
    {
        private readonly PlatformaBlogowa.Data.ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public PostByUsernameModel(PlatformaBlogowa.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
/*        public IQueryable<Post> Posts { get; set; }
*/
        public PaginatedList<Post> PostsListed { get;set; } 

        public async void OnGetAsync(string username, int? pageIndex)
        {
            if (_context.Posts != null)
            {
                pageIndex = pageIndex ?? 1;
                IQueryable<Post> Posts = _context.Posts.Where(p => p.UserName == username).OrderByDescending(p => p.Date).AsQueryable();
                var pageSize = _configuration.GetValue("PageSize", 11);
                PostsListed = await PaginatedList<Post>.CreateAsync(Posts.AsNoTracking(), pageIndex.Value, pageSize);
            }
            
        }
    }
}
