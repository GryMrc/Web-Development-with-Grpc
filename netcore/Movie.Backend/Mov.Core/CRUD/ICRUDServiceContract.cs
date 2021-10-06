using Mov.Core.Model;
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
        Task<Mov.Core.ServiceResponse.ServiceResponse> Create(TDataModel model);
        Task<TDataModel> Read(TIdentity id);
        Task<TDataModel> Update(TDataModel model);
        Task<TDataModel> Delete(TIdentity id);
        Task<IEnumerable<TDataModel>> List();
    }
}
