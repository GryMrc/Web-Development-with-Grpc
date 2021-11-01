using Mov.Core.Model;
using Mov.Core.ServiceResponse;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.CRUD
{
    [ServiceContract]
    public interface ICRUDServiceContract<TDataModel, TIdentity> : IBase where TDataModel : DataModel
    {
        Task<ServiceResponse<TDataModel>> Create(TDataModel model);
        Task<ServiceResponse<TDataModel>> Read(TIdentity id);
        Task<ServiceResponse<TDataModel>> Update(TDataModel model);
        Task<ServiceResponse<TDataModel>> Delete(TIdentity id);
        Task<ServiceResponse<IEnumerable<TDataModel>>> List();
    }
}
