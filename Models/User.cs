using System;
using System.Collections.Generic;

#nullable disable

namespace Instagram.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            FollowMappingFollowees = new HashSet<FollowMapping>();
            FollowMappingFollowers = new HashSet<FollowMapping>();
            Posts = new HashSet<Post>();
        }

        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string ProfileUrl { get; set; }
        public string Status { get; set; }
        public DateTime RegisterAt { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FollowMapping> FollowMappingFollowees { get; set; }
        public virtual ICollection<FollowMapping> FollowMappingFollowers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
