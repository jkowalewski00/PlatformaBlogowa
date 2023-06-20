using System.ComponentModel.DataAnnotations;

namespace PlatformaBlogowa.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Field is required")]
        [Display(Name = "Description")]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string Ip { get; set; }

        [Required]
        public string UserId { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

    }
}
