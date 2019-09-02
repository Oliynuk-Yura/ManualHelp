using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Authentication.JwtIdentity.Attributes
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(string schema, string policy= ""): base(policy)
        {

        }
    }
}
