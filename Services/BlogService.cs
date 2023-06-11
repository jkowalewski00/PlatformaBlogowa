using PlatformaBlogowa.Data;
using PlatformaBlogowa.Interfaces;
using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public IQueryable<Post> GetPosts() 
        {
            return _context.Posts.AsQueryable();
        }

    }
}
