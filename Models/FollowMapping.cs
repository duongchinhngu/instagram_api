using System;
using System.Collections.Generic;

#nullable disable

namespace Instagram.Models
{
    public partial class FollowMapping
    {
        public Guid Id { get; set; }
        public Guid FollowerId { get; set; }
        public Guid FolloweeId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User Followee { get; set; }
        public virtual User Follower { get; set; }
    }
}
