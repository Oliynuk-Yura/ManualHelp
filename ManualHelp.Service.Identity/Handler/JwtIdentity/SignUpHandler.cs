using ManualHelp.Common.Handlers.Abstract;
using ManualHelp.Service.Identity.Query.JwtIdentity;
using ManualHelp.Service.Identity.Repository.Abstract.JwtIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Service.Identity.Handler.JwtIdentity
{
    public class SignUpHandler : IQueryHandler<JwtSignUpQuery, JsonWebToken>
    {
        private readonly IIdentityService _identityService;

        public SignUpHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public  async Task<JsonWebToken> HandleAsync(JwtSignUpQuery query)
        {
            var result =  await _identityService.SignInAsync(query.Email, query.Password);
            return result;
        }
    }
}
