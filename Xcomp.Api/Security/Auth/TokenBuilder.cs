using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Xcomp.Share.Ultils;

namespace Xcomp.Api.Security.Auth
{
    public class TokenBuilder : ITokenBuilder
    {
        public string Build(string name, string[] roles, string[] permissions, List<Claim> extendClaims, TimeSpan expireTime)
        {
            var handler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>();
            if (roles != null)
            {
                foreach (var userRole in roles.Where(c => c.IsNotNullOrEmpty()))
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                }
            }
            if (permissions != null)
            {
                foreach (var permission in permissions)
                {
                    claims.Add(new Claim(ExtendClaimTypes.Permission, permission));
                }
            }
            if (extendClaims != null)
            {
                claims.AddRange(extendClaims);
            }

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(name, "Bearer"),
                claims
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(expireTime.TotalSeconds)
            });

            return handler.WriteToken(securityToken);
        }
    }
}
