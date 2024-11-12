using Base.Interfaces;
using Base.Models;
using BaseApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace TplApi.Services
{
    public class MyBaseUserS : IBaseUserSvc
    {
        //get base user info
        public BaseUserDto GetData()
        {
            var authStr = _Http.GetRequest().Headers["Authorization"]
                .ToString().Replace("Bearer ", "");
            var token = new JwtSecurityTokenHandler().ReadJwtToken(authStr);
            var userId = token.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            return new BaseUserDto()
            {
                UserId = userId,
            };
        }
    }
}
