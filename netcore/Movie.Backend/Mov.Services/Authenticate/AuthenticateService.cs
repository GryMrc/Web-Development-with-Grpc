using Microsoft.EntityFrameworkCore;
using Mov.DataModels.ServiceResponse;
using Mov.DataModels.User;
using Mov.Mutual;
using Mov.ServicesContrats.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Services.Authenticate
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ApplicationDbContext context;

        public AuthenticateService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse> Login(User user)
        {
            var _user = await isUserExist(user.UserName);
            if ( _user != null)
            {
                if (VerifyPasswordHash(user.password, _user.PasswordHash,_user.PasswordSalt))
                {
                    //TODO create token and return token
                    return ServiceResponse.SuccessfulResponse();
                }
                else
                {
                    return ServiceResponse.FailedResponse("Wrong Password!");
                }
            }
            else
            {
                return ServiceResponse.FailedResponse("Wrong Username!");
            }
        }

        public async Task<ServiceResponse> Register(User user)
        {
            if(await isUserExist(user.UserName) != null)
            {
                return ServiceResponse.FailedResponse("Username already exists!");
            }

            CreatePasswordHash(user.password, out byte[] pwhash, out byte[] pwsalt);
            user.PasswordHash = pwhash;
            user.PasswordSalt = pwsalt;
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return ServiceResponse.SuccessfulResponse();
        }

        private void CreatePasswordHash(string pw, out byte[] pwhash, out byte[] pwsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                pwsalt = hmac.Key;
                pwhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pw));
            }
        }


        private bool VerifyPasswordHash(string pw, byte[] pwhash, byte[] pwsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(pwsalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pw));
                for (int i = 0; i < computedHash.Length; i++)
                {

                    if (computedHash[i] != pwhash[i])
                    {
                        return false;
                    }


                }
                return true;
            }
        }

        private async Task<User> isUserExist(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user != null)
            {
                return user;
            }

            return null;
        }
    }
}
