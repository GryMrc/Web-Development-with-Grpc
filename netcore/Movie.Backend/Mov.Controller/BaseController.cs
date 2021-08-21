using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mov.Core;
using Mov.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controller
{
    public class BaseController<TServiceContract>:ControllerBase
        where TServiceContract : IBase
    {
        protected readonly TServiceContract _dataService;
        protected readonly IMapper _mapper;

        protected BaseController(TServiceContract dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
    }
}
