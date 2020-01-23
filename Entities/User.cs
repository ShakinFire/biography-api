using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using biography_api.Entities;

namespace biography.API.Entities
{
    public class User
    {
        [Key]       
        public Guid Id { get; set; }

        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int Age { get; set; }

        public string AvatarImage { get; set; }

        public virtual Biography Biography { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<GalleryImage> Gallery { get; set; }
    }
}
