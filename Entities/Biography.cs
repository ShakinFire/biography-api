using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biography.API.Entities
{
    public class Biography
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Guid? UserId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
