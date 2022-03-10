using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.HttpMessages.Dtos;
using Instagram.HttpMessages.Requests;
using Instagram.HttpMessages.Responses;
using Instagram.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    [Route("p")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService service;

        public PostController(IPostService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PagingResponse<PostDto>>> GetHomeScreenPost([FromQuery] GetHomePostRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest("request must not be null..");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Request has an invalid field input..");
                }

                var result = await service.QueryPost(request);

                bool isNotNullOrEmpty = result is null || result.Data is null || !result.Data.Any();
                if (isNotNullOrEmpty)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "internal error at : " + e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public async Task<ActionResult<PostDto>> GetById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("Id must be provided..");
                }

                if (!Guid.TryParse(id, out Guid guidId))
                {
                    return BadRequest("Id must be a guid..");
                }

                var result = await service.GetByID(guidId);

                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error: " + e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostNewPost([FromBody] CreateNewPostRequest createNewPostRequest)
        {
            try
            {
                if (createNewPostRequest is null)
                {
                    return BadRequest("Create new post request must be provided..");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("There is an invalid attribute..");
                }

                CreatePostResponse response = await service.CreateNewPost(createNewPostRequest);

                return CreatedAtRoute("GetPostById", new { id = response.PostId.ToString() }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal exception: " + ex.Message);
            }
        }
    }
}
