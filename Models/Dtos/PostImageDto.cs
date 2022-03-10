using Instagram.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Instagram.HttpMessages.Dtos
{
    public class PostImageDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Url(ErrorMessage = "Image Url must be a valid url")]
        public string ImageUrl { get; set; }

        public Guid PostId { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTimeUtils.GetUtcNow();
        
        public DateTime ModifiedAt { get; set; } = DateTimeUtils.GetUtcNow();
    }
}
