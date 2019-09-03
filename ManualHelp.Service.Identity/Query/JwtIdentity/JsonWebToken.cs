using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Service.Identity.Query.JwtIdentity
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }        
        public string Role { get; set; }
        public SecurityTokenDescriptor  SecurityTokenDescriptor { get; set; }
    }
}
