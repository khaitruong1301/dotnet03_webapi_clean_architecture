using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet03_ebay.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using dotnet03_ebay.api.Models;

namespace dotnet03_ebay.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("RegisterBuyer")]
        public async Task<ActionResult> RegisterBuyer([FromBody] UserBuyerRegister model)
        {
            var res = await _userService.RegisterBuyer(model);
            return Ok(res);
        }
        [HttpPost("RegisterSeller")]
        public async Task<ActionResult> RegisterSeller([FromBody] UserSellerRegister model)
        {
            var res = await _userService.RegisterSeller(model);
            return Ok(res);
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO model)
        {
            var res = await _userService.Login(model);
            if(res == MessageLogin.UserNotFound)
            {
                return NotFound(res);
            }
            else if (res == MessageLogin.PasswordIncorrect)
            {
                return Unauthorized(res);
            }
            else if (res == MessageLogin.ErrorInServer)
            {
                return StatusCode(500, res);
            }
            return Ok(res);
        }

    }
}