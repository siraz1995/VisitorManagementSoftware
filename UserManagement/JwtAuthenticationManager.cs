using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.AccessControl;
using Microsoft.IdentityModel.Tokens;

namespace UserManagement
{
    public class JwtAuthenticationManager
    {
        //private readonly string Key;
        //private readonly IDictionary<string, string> _claims = new Dictionary<string, string>()
        //{
        //    {"test","password" },{"test1","pwd"}
        //};
        //public JwtAuthenticationManager(string key)
        //{
        //    this.Key = key;
           
        //}
        //public string Authenticate(string username, string password)
        //{
        //    if(!_claims.Any(u=>u.Key==username && u.Value==password))
        //    {
        //        return null;
        //    }
        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        //    var tokenKey=Encoding.UTF8.GetBytes(Key);
        //    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, username),

        //        }),
        //        Expires= DateTime.UtcNow.AddHours(1),
        //        SigningCredentials=new SigningCredentials
        //        (
        //            new SymmetricSecurityKey(tokenKey)
        //        )
        //    };
        //    return null;
       // }
    }
}
