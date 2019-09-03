using ManualHelp.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Service.Identity.Query.JwtIdentity
{
    public class JwtSignUpQuery : IQuery<JsonWebToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
