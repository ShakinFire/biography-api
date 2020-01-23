using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using biography.API.Entities;

namespace biography_api.Entities
{
    public class GalleryImage
    {
        [Key]
        public Guid Id { get; set; }

        public string Image { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Guid? UserId { get; set; }
    }
}
