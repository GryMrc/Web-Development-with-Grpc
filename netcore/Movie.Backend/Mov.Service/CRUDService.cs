using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mov.Core.CRUD;
using Mov.Core.DataListResult;
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

        protected CRUDService(DbContext dbContext,DbSet<TDataModel> modelDbset)
        {
            _dbContext = dbContext;
            _modelDbSet = modelDbset;
        }

        public virtual async Task<ServiceResponse<TDataModel>> Create(TDataModel model)
        {
            try
            {
                await _modelDbSet.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse<TDataModel>() { Data = model,  Success = true};
            }
            catch(Exception ex)
            {
                return new ServiceResponse<TDataModel>() { Errors = ex.InnerException != null ? ex.InnerException.Message : ex.Message }; // ex.message yerine database islemi oldugu icin inner.exmessage olabilir
            }
            
        }

        public virtual async Task<ServiceResponse<TDataModel>> Update(TDataModel model) // override edilmeli modeli bulmak icin eger model yoksa hata dondurulmeli
        {
            try
            { 
                _modelDbSet.Update(model); // why update is no async?
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse<TDataModel>() { Data = model, Success = true };
            }
            catch(Exception ex)
            {
                return new ServiceResponse<TDataModel>() { Errors = ex.InnerException != null ? ex.InnerException.Message : ex.Message};  // bu alanlar icin ortak bi yapi kurulabilir butun islemlerde aynisini kullandik dublicate oluyor.
            }
        }

        public virtual async Task<ServiceResponse<IEnumerable<TDataModel>>> List()
        {
            var dataList = await _modelDbSet.AsQueryable().ToListAsync();
            return new ServiceResponse<IEnumerable<TDataModel>>() { Data = dataList, Total = dataList.Count, Success = true };
        }

        public Task<ServiceResponse<TDataModel>> Read(TId id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<TDataModel>> Delete(TId id)
        {
            try
            {
                var model = await _modelDbSet.FindAsync(id);

                if(model == null)
                {
                    return new ServiceResponse<TDataModel>() { Errors = "Model Not Found With " + id };
                }
                _modelDbSet.Remove(model); // why delete is no async?
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse<TDataModel>() { Data = null, Success = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TDataModel>() { Errors = ex.InnerException != null ? ex.InnerException.Message : ex.Message };  // bu alanlar icin ortak bi yapi kurulabilir butun islemlerde aynisini kullandik dublicate oluyor.
            }
        }
    }
}
