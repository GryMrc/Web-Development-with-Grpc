using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mov.Core.CRUD;
using Mov.Core.DataListResult;
using Mov.Core.Model;
using Mov.Core.MovException;
using Mov.Core.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Service
{
   public abstract class CRUDService<TDataModel,TId>
        where TDataModel : DataModel, new()
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TDataModel> _modelDbSet;

        protected CRUDService(DbContext dbContext,DbSet<TDataModel> modelDbset)
        {
            _dbContext = dbContext;
            _modelDbSet = modelDbset;
        }

        public virtual async Task<TDataModel> Create(TDataModel model) // try catch bloklarini kaldirdik database islemlerinde entity throwluyor olabilir?? arastir
        {
                var dbResult = await _modelDbSet.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return dbResult.Entity;
        }

        public virtual async Task<ServiceResponse> Update(TDataModel model) // override edilmeli modeli bulmak icin eger model yoksa hata dondurulmeli
        {
                _modelDbSet.Update(model); // why update is no async?
                await _dbContext.SaveChangesAsync();
                return ServiceResponse.SuccessfulResponse();
        }

        public virtual async Task<IEnumerable<TDataModel>> List()
        {
            return await _modelDbSet.ToListAsync();
        }

        public abstract Task<TDataModel> Read(TId id);


        public abstract Task<ServiceResponse> Delete(TId id);
    }
}
