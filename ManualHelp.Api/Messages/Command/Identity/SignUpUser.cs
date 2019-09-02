using ManualHelp.Common.Messages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Api.Messages.Command.Identity
{
    public class SignUpUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
