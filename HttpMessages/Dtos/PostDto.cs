using System;
using System.Collections.Generic;

namespace Instagram.HttpMessages.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Caption { get; set; }
        public List<PostImageDto> Images { get; set; }
        public UserDto Owner { get; set; }
    }
}
