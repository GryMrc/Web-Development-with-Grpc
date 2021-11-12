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
        Task<TDataModel> Create(TDataModel model);
        Task<TDataModel> Read(TIdentity id);
        Task<ServiceResponse.ServiceResponse> Update(TDataModel model);
        Task<ServiceResponse.ServiceResponse> Delete(TIdentity id);
        Task<IEnumerable<TDataModel>> List();
    }
}
