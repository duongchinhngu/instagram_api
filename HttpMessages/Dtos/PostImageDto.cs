using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.HttpMessages.Dtos
{
    public class PostImageDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public Guid PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
