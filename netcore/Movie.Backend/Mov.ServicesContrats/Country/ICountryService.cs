using Mov.Core.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ServicesContrats.Country
{
    [ServiceContract]
    public interface ICountryService : ICRUDServiceContract<DataModels.Country.Country, Identity<int>>
    {
    }
}
