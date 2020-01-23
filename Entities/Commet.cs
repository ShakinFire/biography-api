using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using biography_api.Entities;

namespace biography.API.Entities
{
    public class Comment : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(350)]
        public string Content { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("BiographyId")]
        public virtual Biography Biography { get; set; }

        public Guid? BiographyId { get; set; }
    }
}
