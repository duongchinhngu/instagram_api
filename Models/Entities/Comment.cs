using System;
using System.Collections.Generic;

#nullable disable

namespace Instagram.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Reactions = new HashSet<Reaction>();
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsAvailable { get; set; }

        public virtual User Creator { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
    }
}
