using ManualHelp.Service.Identity.Domain.JwtIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Service.Identity.Repository.Abstract.JwtIdentity
{
    public interface IIdentityService
    {
        Task<User> SignUpAsync(string email, string password);
        Task<string> SignInAsync(string email, string password); //JsonWebToken
        Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
    }
}
