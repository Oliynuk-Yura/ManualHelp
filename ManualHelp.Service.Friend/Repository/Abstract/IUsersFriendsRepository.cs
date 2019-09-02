using ManualHelp.Services.Friends.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Services.Friends.Repository.Abstract
{
    public interface IUsersFriendsRepository
    {
         Task AddFriend(UsersFriends model);
    }
}
