using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mov.Core.CRUD;
using Mov.Core.Model;
using Mov.Core.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Controller
{
    [ApiController]
    public abstract class CRUDController<TDataModel, TServiceContract, TViewModel, TId> : BaseController<TServiceContract>
    where TDataModel : DataModel, new()
    where TServiceContract : ICRUDServiceContract<TDataModel, Identity<TId>>
    where TViewModel : ViewModel, new()
    {
        protected CRUDController(TServiceContract dataService, IMapper mapper)
           : base(dataService, mapper)
        {
        }

        [HttpPost]
        public virtual async Task<ActionResult<ServiceResponse>> Create(TViewModel viewModel) // protected yapinca 404 notfound aliyorum??
        {
            if (ModelState.IsValid)
            {
                TDataModel dataModel = _mapper.Map<TDataModel>(viewModel);
                return await _dataService.Create(dataModel);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw new Exception(errors.FirstOrDefault()); // bu kisim cozulecek
            }

        }
    }
}
