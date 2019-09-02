using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Authentication.JwtIdentity.Attributes
{
    public class JwtAuthAttribute : AuthAttribute
    {
        public JwtAuthAttribute(string policy = "") : base(JwtBearerDefaults.AuthenticationScheme, policy)
        {
        }
    }
}
