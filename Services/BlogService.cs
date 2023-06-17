using Microsoft.EntityFrameworkCore;
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

        public Post GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void AddComment (Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges ();
        }

        public IQueryable<Comment> GetCommentByPostId(int postId)
        {
            return _context.Comments.Where(p => p.PostId == postId);    
        }

    }
}
