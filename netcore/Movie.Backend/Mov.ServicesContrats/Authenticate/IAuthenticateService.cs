using Mov.Core;
using Mov.Core.CRUD;
using Mov.DataModels.ServiceResponse;
using Mov.DataModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ServicesContrats.Authenticate
{
   [ServiceContract]
   public  interface IAuthenticateService:ICRUDServiceContract<DataModels.User.User,Identity<int>>
    {

        Task<ServiceResponse> Login(User model);
        Task<ServiceResponse> Register(User model);

    }
}
