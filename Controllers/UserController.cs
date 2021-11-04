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
    [Route("u")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<UserDto>> GetById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("id must be provided..");
                }

                if (!Guid.TryParse(id, out Guid guidId))
                {
                    return BadRequest("Id must be a guid");
                }

                var result = await service.GetById(guidId);
                if( result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal error: " + e.Message);
            }

        }
    }
}
