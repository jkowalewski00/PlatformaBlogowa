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
            return _context.Posts.OrderByDescending(x => x.Date).Take(10).AsQueryable();
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
            return _context.Comments.Where(p => p.PostId == postId).AsQueryable();    
        }

        public void DeleteComment(int id)
        {   var comment = _context.Comments.FirstOrDefault(p => p.Id == id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public void AddPhotoToPost(Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        public IQueryable<Photo> GetPhotosByPostId(int id)
        {
            return _context.Photos.AsQueryable().Where(p =>p.PostId == id);
        }

        public void DeletePhoto(int Id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == Id);
            _context.Photos.Remove(photo);  
            _context.SaveChanges();
        }
    }
}
