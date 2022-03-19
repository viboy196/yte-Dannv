using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xcomp.Api.Security
{
    public interface ISecurityContext
    {
        //User User { get; }

        bool IsAdministrator { get; }
    }
}
