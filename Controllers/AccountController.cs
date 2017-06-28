
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace dotnetcore_webapi_ang
{
    public class AccountController : Controller
    {
        ///Надо что то заполнить посмотрим по ходу
        private List<string> users = new List<string>();

        [HttpPost("/token")]
        public async Task Token()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];

            var identity = GetIdentity(username, password);

            if(identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username.");
                return;
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience:AuthOptions.AUDIENCE,
                notBefore:now,
                claims:identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                                    SecurityAlgorithms.HmacSha256));
    
            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new {
                access_token = encodeJwt,
                username = identity.Name
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response,
             new JsonSerializerSettings{Formatting = Formatting.Indented}));
        }

        ///TODO:Implement
        private ClaimsIdentity GetIdentity(StringValues username, StringValues password)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "admin")
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}