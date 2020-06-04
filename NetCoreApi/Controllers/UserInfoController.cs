using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Core.Attributes;
using NetCoreApi.Models;
using NetCoreApi.services.UserServices;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserInfoController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        [AllowAnonymous] 
        [HttpPost]
        public async Task<bool> GetUser(Userinfo userinfo) 
        {
            return await _userService.GetUserinfoAsync(userinfo);
        } 
    }
}