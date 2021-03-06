using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Mov.Core.CRUD;
using Mov.Core.Exceptionhandler;
using Mov.Core.MovException;
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
    public class PrivilegeService : CRUDService<DataModels.User.Privilege, Identity<int>>, IPrivilegeService
    {
        private readonly ApplicationDbContext context;

        public PrivilegeService(ApplicationDbContext context) : base(context,context.Privileges)
        {
            this.context = context;
        }

        public override async Task<ServiceResponse> Delete(Identity<int> id)
        {
            if(await context.Users.AnyAsync(u => u.PrivilegeId == id.Id))
            {
                throw new MovException("Some User have this privilege!");
            }
            _modelDbSet.Remove(new DataModels.User.Privilege { Id = id.Id });
            await _dbContext.SaveChangesAsync();
            return ServiceResponse.SuccessfulResponse();
        }

        public override async Task<DataModels.User.Privilege> Read(Identity<int> id)
        {

            try
            {
               return await _modelDbSet.FindAsync(id.Id);
            }
            catch (Exception ex)
            {
                throw;
            }
                
        }
    }
}
