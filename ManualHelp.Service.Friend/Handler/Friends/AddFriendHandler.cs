using ManualHelp.Common.Handlers.Abstract;
using ManualHelp.Common.RabbitMq.Abstract;
using ManualHelp.Services.Friends.Domain;
using ManualHelp.Services.Friends.Messages.Commands.Friends;
using ManualHelp.Services.Friends.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Services.Friends.Handler.Friends
{
    public class AddFriendHandler : ICommandHandler<AddFriend>
    {
        private readonly IUsersFriendsRepository _usersFriendsRepository;

        public AddFriendHandler(IUsersFriendsRepository usersFriendsRepository)
        {
            _usersFriendsRepository = usersFriendsRepository;
        }

        public async Task HandleAsync(AddFriend command, ICorrelationContext context)
        {
            var model = new UsersFriends()
            {
                FriendId = command.FriendId,
                UserId = command.UserId
            };

           await _usersFriendsRepository.AddFriend(model);
        }
    }
}
