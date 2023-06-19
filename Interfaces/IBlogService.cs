using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.Interfaces
{
    public interface IBlogService
    {
        public void AddPost(Post post);

        public IQueryable<Post> GetPosts();

        public Post GetPostById(int id);

        public void AddComment(Comment comment);    

        public IQueryable<Comment>? GetCommentByPostId(int id);

        public void DeleteComment(int id);

        public void AddPhotoToPost(Photo photo);

        public IQueryable<Photo> GetPhotosByPostId(int Id);

        public void DeletePhoto(int Id);
    }
}
