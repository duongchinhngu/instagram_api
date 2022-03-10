using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.HttpMessages.Dtos;
using Instagram.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    [Route("post-images")]
    [ApiController]
    public class PostImageController : ControllerBase
    {
        private readonly IPostImageService service;

        public PostImageController(IPostImageService service)
        {
            this.service = service;
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<IEnumerable<PostImageDto>>> GetByPostId(string postId)
        {
            try
            {
                if (string.IsNullOrEmpty(postId))
                {
                    return BadRequest("post Id must be provided..");
                }

                if (!Guid.TryParse(postId, out Guid guidId))
                {
                    return BadRequest("post Id must be a guid..");
                }

                var result = await service.GetByPostId(guidId);

                if( result is null || !result.Any())
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "internal error exception: " + e.Message);
            }
        }
    }
}
