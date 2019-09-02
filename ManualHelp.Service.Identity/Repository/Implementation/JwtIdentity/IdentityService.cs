using ManualHelp.Service.Identity.Domain.JwtIdentity;
using ManualHelp.Service.Identity.Repository.Abstract.JwtIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Service.Identity.Repository.Implementation.JwtIdentity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IdentityService
            (
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> SignInAsync(string email, string password)
        {
            //var user = await _userManager.FindByEmailAsync(email);

            //if (user != null && await _userManager.CheckPasswordAsync(user, password))
            //{
            //    var claims = new Claim[]
            //    {
            //        new Claim("UserId", user.Id.ToString()),
            //        new Claim(ClaimTypes.Email, user.Email),
            //        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            //        new Claim("User", user.ToString())
            //    };

            //    await _userManager.AddClaimsAsync(user, claims);
            //    var tokenDescription = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(claims),
            //        Expires = DateTime.UtcNow.AddMonths(12),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisismycustomsecretkeyforauthnetication")), SecurityAlgorithms.HmacSha256Signature)
            //    };

            //    var result = await _signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);

            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var securityToken = tokenHandler.CreateToken(tokenDescription);
            //    var token = tokenHandler.WriteToken(securityToken);

            //    return Ok(new
            //    {
            //        token = token,
            //        firstName = user.FirstName,
            //        lastName = user.LastName,
            //        email = user.Email,
            //        id = user.Id,
            //        UserImage = user.ImageUser,
            //        UserWallpaper = user.UserWallpaper
            //    });
            //}
            //else
            //{
            //    return BadRequest(new { message = "Error" });
            //}

            return null;
        }

        public async Task<User> SignUpAsync(string email, string password)
        {
            User user =  await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                //throw new DShopException(Codes.EmailInUse,
                //    $"Email: '{email}' is already in use.");
            }

            try
            {
                user = new User
                {
                    Email = email,
                    UserName = email                    
                };

                IdentityResult result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                }
            }
            catch (Exception)
            {
                throw;
                //throw new DShopException(Codes.EmailInUse,
                //    $"Email: '{email}' is already in use.");
            }

            return user;

        }

        public Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
