using System;
using System.Collections.Generic;

#nullable disable

namespace Instagram.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Reactions = new HashSet<Reaction>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Caption { get; set; }
        public bool IsAvailable { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
    }
}
