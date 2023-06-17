using System.ComponentModel.DataAnnotations;

namespace PlatformaBlogowa.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Descritpion is required")]
        [Display(Name ="Description")]
        [MaxLength(256)]
        public string Description { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }


    }
}
