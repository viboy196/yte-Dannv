using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Xcomp.Api.Security.Auth
{
    public interface ITokenBuilder
    {
        string Build(string name, string[] roles, string[] permissions, List<Claim> extendClaims, TimeSpan expireTime);
    }
}
