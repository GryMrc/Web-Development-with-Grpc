using Mov.Core;
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
   public  interface IAuthenticateService:IBase
    {

        
        Task<ServiceResponse> Register(User user);
        Task<ServiceResponse> Login(User user);

    }
}
