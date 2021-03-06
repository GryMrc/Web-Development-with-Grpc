using Mov.Core.Model;
using System.Collections.Generic;
using System.ServiceModel;
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
        Task<IEnumerable<TDataModel>> ListAll();
        Task<IEnumerable<TDataModel>> List(ListParams.ListParams listParams);
    }
}
