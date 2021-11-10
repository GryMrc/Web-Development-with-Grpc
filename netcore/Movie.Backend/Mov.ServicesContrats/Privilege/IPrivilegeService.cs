using Mov.Core.CRUD;
using Mov.Core.ServiceResponse;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ServicesContrats.Privilege
{
    [ServiceContract]
    public interface IPrivilegeService:ICRUDServiceContract<DataModels.User.Privilege,Identity<int>>
    {
    }
}
