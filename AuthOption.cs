using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace dotnetcore_webapi_ang
{
    public class AuthOptions
    {
        public const string ISSUER = "OwnAuthServer";//издатель токена
        public const string AUDIENCE = "OwnSite";//потребитель токена
        const string KEY = "secretkey_ownserver";//
        public const int LIFETIME= 10 ;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}