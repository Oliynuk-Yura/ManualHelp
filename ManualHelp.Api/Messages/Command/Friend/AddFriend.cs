using ManualHelp.Common.Messages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Api.Messages.Command.Friend
{
    public class AddFriend : ICommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
