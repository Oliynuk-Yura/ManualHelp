using ManualHelp.Services.Friends.Domain;
using Microsoft.EntityFrameworkCore;

namespace ManualHelp.Services.Friends.Database
{
    public class FriendsServiceDatabase : DbContext
    {
        public FriendsServiceDatabase(DbContextOptions<FriendsServiceDatabase> options): base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        public DbSet<UsersFriends> UsersFriends { get; set; }
    }
}
