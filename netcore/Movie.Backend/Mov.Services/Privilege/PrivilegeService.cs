using Mov.Core.CRUD;
using Mov.Core.ServiceResponse;
using Mov.Mutual;
using Mov.Service;
using Mov.ServicesContrats.Privilege;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Services.Privilege
{
    public class PrivilegeService : CRUDService<DataModels.User.Privilege, int>, IPrivilegeService
    {
        private readonly ApplicationDbContext context;

        public PrivilegeService(ApplicationDbContext context) : base(context,context.Privileges)
        {
            this.context = context;
        }

        public Task<DataModels.User.Privilege> Delete(Identity<int> id)
        {
            throw new NotImplementedException();
        }

        public Task<DataModels.User.Privilege> Read(Identity<int> id)
        {
            throw new NotImplementedException();
        }
    }
}
