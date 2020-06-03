using Microsoft.EntityFrameworkCore;
using NetCoreApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace NetCoreApi.services.UserServices
{
    public class UserService : IUserService
    {
        public DataBaseContent _dataBaseContent;
        public UserService(DataBaseContent dataBaseContent)
        {
            _dataBaseContent = dataBaseContent;
        }

        public async Task<bool> GetUserinfoAsync(Userinfo userinfo)
        {
            var result = await _dataBaseContent.userinfo.FirstOrDefaultAsync(c => c.Name == userinfo.Name && c.Pwd == userinfo.Pwd);
            return result != null ? true : false;
        }

        public Task<Userinfo> UserinfoAddAsync(Userinfo userinfo)
        {
            throw new NotImplementedException();
        }
    }
}
