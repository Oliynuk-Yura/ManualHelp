using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Api.Services.Identity
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    interface IIdentityService
    {
        //[AllowAnyStatusCode]
        [Get("signUp")]
        Task<object> SignUpAsync([Path] Guid id);

    }
}
