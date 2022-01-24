using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mov.Core.CRUD;
using Mov.Core.DataListResult;
using Mov.Core.ListParams;
using Mov.Core.Model;
using Mov.Core.MovException;
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
                return Ok(new ServiceResponse<TViewModel> { Message = errors.FirstOrDefault()});
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

        [HttpDelete]
        public virtual async Task<ActionResult<ServiceResponse>> Delete(TId Id) // protected yapinca 404 notfound aliyorum??
        {
            var model = await _dataService.Read(new Identity<TId> { Id = Id });

            if (model == null)
            {
                return Ok(ServiceResponse.FailedResponse("Model Not Found!"));
            }
            return Ok(await _dataService.Delete(new Identity<TId> { Id = Id }));
        }

        [HttpGet]
        public virtual async Task<TViewModel> Read(TId Id) // protected yapinca 404 notfound aliyorum??
        {

            return _mapper.Map<TViewModel>(await _dataService.Read(new Identity<TId> { Id = Id }));
        }
            
               //?? throw new MovException(MovErrors.ModelNotFound); // daha sonra yapilacak

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TViewModel>>> ListAll() // protected yapinca 404 notfound aliyorum??
        {
            var list = _mapper.Map<IEnumerable<TViewModel>>(await _dataService.ListAll());
            return Ok(new ServiceResponse<IEnumerable<TViewModel>> { Data = list, Success = true, Total = list.Count() });
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TViewModel>>> List(int pageSize, int page) // protected yapinca 404 notfound aliyorum??
        {
            return Ok(_mapper.Map<IEnumerable<TViewModel>>(await _dataService.List(new ListParams {pageSize= pageSize, page = page })));
        }
    }
}
