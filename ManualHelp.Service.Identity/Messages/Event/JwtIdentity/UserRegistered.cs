using ManualHelp.Common.Messages;
using ManualHelp.Common.Messages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Service.Identity.Messages.Event.JwtIdentity
{
    [MessageNamespace("register")]
    public class UserRegistered : IEvent
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
