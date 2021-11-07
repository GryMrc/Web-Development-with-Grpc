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

        public override async Task<ServiceResponse> Delete(Identity<int> id)
        {
            var model = await _modelDbSet.FindAsync(id);

            if (model == null)
            {
                return ServiceResponse.FailedResponse("Model Not Found With " + id);
            }
            _modelDbSet.Remove(model); // why delete is no async?
            await _dbContext.SaveChangesAsync();
            return ServiceResponse.SuccessfulResponse();
        }

        public override Task<ServiceResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DataModels.User.Privilege> Read(Identity<int> id)
        {
            throw new NotImplementedException();
        }

        public override Task<DataModels.User.Privilege> Read(int id)
        {
            throw new NotImplementedException();
        }
    }
}
