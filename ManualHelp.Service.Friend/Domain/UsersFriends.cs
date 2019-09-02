using ManualHelp.Common.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Services.Friends.Domain
{
    public class UsersFriends : Identifiable
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }

    }
}
