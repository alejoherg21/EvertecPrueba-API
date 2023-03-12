using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Service.Jwt;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly JwtUtils jwtUtils;

        public UsersController(JwtParams jwt)
        {
            jwtUtils = new JwtUtils(jwt);
        }

        // GET: api/Users
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(User user)
        {
            try
            {
                if (user.UserId == "alejo" && user.Password == "1234")
                {
                    string token = jwtUtils.GenerateToken(user);

                    return Ok(token);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server error");
            }
            //   return await _context.User.ToListAsync();
        }

        [HttpGet("saludar")]
        public async Task<ActionResult<IEnumerable<User>>> Saludar()
        {
            try
            {
                return Ok("hola");
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server error");
            }
            //return await _context.User.ToListAsync();
        }
    }
    // GET: api/Users/5
}
