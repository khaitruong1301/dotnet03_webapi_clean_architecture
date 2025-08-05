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
        

    }
}