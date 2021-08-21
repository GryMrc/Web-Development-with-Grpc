using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mov.Core.CRUD;
using Mov.Core.Model;
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
        protected virtual async Task<ActionResult<TViewModel>> Create(TViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TDataModel dataModel = _mapper.Map<TDataModel>(viewModel);
                var createdModel = await _dataService.Create(dataModel);
                return _mapper.Map<TViewModel>(createdModel);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw new Exception("Falan filan");
            }

        }
    }
}
