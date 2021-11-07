using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mov.Core.CRUD;
using Mov.Core.DataListResult;
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
        public virtual async Task<ActionResult<TViewModel>> Create(TViewModel viewModel) // protected yapinca 404 notfound aliyorum??
        {
            if (ModelState.IsValid)
            {
                TDataModel dataModel = _mapper.Map<TDataModel>(viewModel);
                var createdModel = _mapper.Map<TViewModel>(await _dataService.Create(dataModel));
                return Ok(new ServiceResponse<TViewModel> { Data = createdModel, Success = true, Total = 1 });
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                return Ok(ServiceResponse.FailedResponse(errors.FirstOrDefault()));
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<ServiceResponse>> Update(TViewModel viewModel) // protected yapinca 404 notfound aliyorum??
        {
            if (ModelState.IsValid)
            {
                TDataModel dataModel = _mapper.Map<TDataModel>(viewModel);
                return Ok(await _dataService.Update(dataModel));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                return Ok(ServiceResponse.FailedResponse(errors.FirstOrDefault()));
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<ServiceResponse>> Delete(Identity<TId> Id) // protected yapinca 404 notfound aliyorum??
        {
                return Ok(await _dataService.Delete(Id));
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TViewModel>>> List() // protected yapinca 404 notfound aliyorum??
        {
            var list = _mapper.Map<IEnumerable<TViewModel>>(await _dataService.List());
            return Ok(new ServiceResponse<IEnumerable<TViewModel>> { Data = list, Success = true, Total = list.Count() });
        }
    }
}
