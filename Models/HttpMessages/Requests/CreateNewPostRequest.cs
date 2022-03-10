using Instagram.CustomValidations;
using Instagram.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Instagram.HttpMessages.Requests
{
    public class CreateNewPostRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTimeUtils.GetUtcNow();

        [Required(ErrorMessage = "OwnerId must be provided..")]
        [MaxLength(64, ErrorMessage = ("Owner id must be less than 64 characters"))]
        public string OwnerId { get; set; }

        [JsonIgnore]
        public DateTime ModifiedAt { get; set; } = DateTimeUtils.GetUtcNow();

        [Required]
        [MaxLength(200, ErrorMessage = "Caption must be less than 200 characters")]
        public string Caption { get; set; }

        [JsonIgnore]
        public bool IsAvailable { get; set; } = true;

        [EnsureListElements(min: 1, ErrorMessage = "Post image must be 1 element at least")]
        public List<CreatePostImageRequest> CreatePostImageRequests { get; set; }
    }   

    public class CreatePostImageRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Url(ErrorMessage = "Image Url must be a valid url")]
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public Guid PostId { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTimeUtils.GetUtcNow();

        [JsonIgnore]
        public DateTime ModifiedAt { get; set; } = DateTimeUtils.GetUtcNow();
    }
}
