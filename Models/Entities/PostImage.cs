using System;
using System.Collections.Generic;

#nullable disable

namespace Instagram.Models
{
    public partial class PostImage
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public Guid PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Post Post { get; set; }
    }
}
