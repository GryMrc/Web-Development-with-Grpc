using Mov.Core.CRUD;
using Mov.DataModels.Crew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ServicesContrats.Crew
{
    [ServiceContract] // service contract vermezsem un resolve service oluyor bunu arastir?
    public interface IDirectorService:ICRUDServiceContract<Director,Identity<int>>
    {
    }
}
