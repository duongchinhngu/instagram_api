using Newtonsoft.Json;
using System;

namespace Instagram.HttpMessages.Responses
{
    public class CreatePostResponse
    {
        [JsonProperty("postId")]
        public Guid PostId { get; set; }
    }
}
