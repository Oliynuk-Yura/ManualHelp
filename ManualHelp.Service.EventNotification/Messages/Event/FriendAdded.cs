using ManualHelp.Common.Messages;
using ManualHelp.Common.Messages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Service.EventNotification.Messages.Event
{
    [MessageNamespace("friend")]
    public class FriendAdded : IEvent
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
