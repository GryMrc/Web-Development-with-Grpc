using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mov.Core.CRUD;
using Mov.Core.Model;
using Mov.Core.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Service
{
   public abstract class CRUDService<TDataModel,TId>:ICRUDServiceContract<TDataModel,TId>
        where TDataModel : DataModel, new()
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TDataModel> _modelDbSet;

        protected CRUDService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<TDataModel> Delete(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<TDataModel> Read(TId id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ServiceResponse> Create(TDataModel model)
        {
            try
            {
                await _modelDbSet.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return ServiceResponse.SuccessfulResponse();
            }
            catch(Exception ex)
            {
                return ServiceResponse.FailedResponse(ex.Message);
            }
            
        }

        public virtual async Task<TDataModel> Update(TDataModel model)
        {
            _modelDbSet.Update(model); // why update is no async?
            await _dbContext.SaveChangesAsync();
            return null;
        }

        
    }
}
