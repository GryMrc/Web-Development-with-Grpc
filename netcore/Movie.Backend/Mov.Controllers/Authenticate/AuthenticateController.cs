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

namespace Mov.Controllers.Authenticate
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;

        public AuthenticateController(IAuthenticateService authenticateService,IMapper mapper)
        {
            _authenticateService = authenticateService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            
             return Ok( await _authenticateService.Register(_mapper.Map<DataModels.User.User>(user)));
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var a = _mapper.Map<DataModels.User.User>(user);
            return Ok(await _authenticateService.Login(a));
        }
    }
}
