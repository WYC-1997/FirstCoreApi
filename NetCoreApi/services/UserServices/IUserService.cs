using NetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.services.UserServices
{
    public interface IUserService
    {
        Task<bool> GetUserinfoAsync(Userinfo userinfo);
        Task<Userinfo> UserinfoAddAsync(Userinfo userinfo);
    }
}
