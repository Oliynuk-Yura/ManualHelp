using ManualHelp.Common.Database.MsSqlDatabase.Abstract;
using ManualHelp.Services.Friends.Database;
using ManualHelp.Services.Friends.Domain;
using ManualHelp.Services.Friends.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Services.Friends.Repository.Implementation
{
    public class UsersFriendsRepository : IUsersFriendsRepository
    {
        private readonly IMsSqlDbRepository<UsersFriends, FriendsServiceDatabase> _dbRepository;

        public UsersFriendsRepository
            (
            IMsSqlDbRepository<UsersFriends, FriendsServiceDatabase> dbRepository
            )
        {
            _dbRepository = dbRepository;
        }

        public async Task AddFriend(UsersFriends model)
        {
             await  _dbRepository.AddAsync(model);
        }

       
    }
}
