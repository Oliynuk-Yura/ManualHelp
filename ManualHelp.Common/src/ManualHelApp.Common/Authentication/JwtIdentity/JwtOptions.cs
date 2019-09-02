using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Authentication.JwtIdentity
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int ExpiryMinutes { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateAudience { get; set; }
        public string ValidAudience { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateActor { get; set; }
    }
}
