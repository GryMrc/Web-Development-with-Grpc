using Microsoft.EntityFrameworkCore;
using Mov.Core.CRUD;
using Mov.Core.ServiceResponse;
using Mov.DataModels.User;
using Mov.Mutual;
using Mov.Service;
using Mov.ServicesContrats.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Services.Authenticate
{
    public class AuthenticateService :CRUDService<DataModels.User.User, Identity<int>>, IAuthenticateService
    {
        private readonly ApplicationDbContext context;

        public AuthenticateService(ApplicationDbContext context):base(context,context.Users)
        {
            this.context = context;
        }

        public async Task<ServiceResponse> Register(User model)
        {
            if(await isUserExist(model.UserName) != null)
            {
                return ServiceResponse.FailedResponse("Username already exists!");
            }

            try
            {
                CreatePasswordHash(model.password, out byte[] pwhash, out byte[] pwsalt);
                model.PasswordHash = pwhash;
                model.PasswordSalt = pwsalt;
                await context.Users.AddAsync(model);
                await context.SaveChangesAsync();
                return ServiceResponse.SuccessfulResponse();
            }

            catch (Exception ex)
            {
                if (ex.InnerException.Message.Equals(""))
                {
                return ServiceResponse.FailedResponse(ex.Message);
                }
                return ServiceResponse.FailedResponse(ex.InnerException.Message);
            }
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

        public async Task<ServiceResponse> Login(User model)
        {
            var _user = await isUserExist(model.UserName);
            if (_user != null)
            {
                if (VerifyPasswordHash(model.password, _user.PasswordHash, _user.PasswordSalt))
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

       

        public override Task<ServiceResponse> Delete(Identity<int> id)
        {
            throw new NotImplementedException();
        }

        public override Task<User> Read(Identity<int> id)
        {
            throw new NotImplementedException();
        }
    }
}
