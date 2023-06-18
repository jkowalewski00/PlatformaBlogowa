using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformaBlogowa.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [NotMapped]
        public IFormFile Photofile { get; set; }

        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

    }
}
