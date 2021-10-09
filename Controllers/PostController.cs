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
                if (request is null) return BadRequest("request must not be null..");


                if (!ModelState.IsValid) return BadRequest("Request has an invalid field input..");


                var result = await service.QueryPost(request);

                if (result is null || result.Data is null || !result.Data.Any()) return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "internal error at : " + e.Message);
            }
        }

        [HttpGet("{id}")]
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
    }
}
