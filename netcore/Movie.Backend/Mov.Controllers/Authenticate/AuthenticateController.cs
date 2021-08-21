using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.DataModels.ServiceResponse;
using Mov.ServicesContrats.Authenticate;
using Mov.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mov.Core.CRUD;
using Mov.Controller;

namespace Mov.Controllers.Authenticate
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticateController : CRUDController<DataModels.User.User,IAuthenticateService, ViewModels.User.User,int>
    {

        public AuthenticateController(IAuthenticateService authenticateService,IMapper mapper)
            :base(authenticateService,mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {

            return Ok(await _dataService.Login(_mapper.Map<DataModels.User.User>(user)));
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {

            return Ok(await _dataService.Register(_mapper.Map<DataModels.User.User>(user)));
        }
    }
}
