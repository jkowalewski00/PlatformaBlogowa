using System.ComponentModel.DataAnnotations;


namespace PlatformaBlogowa.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is requied")]
        [Display(Name = "URL")]
        public string FileName { get; set; }

        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

    }
}
