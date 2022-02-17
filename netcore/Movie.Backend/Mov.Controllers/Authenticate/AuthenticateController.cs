using Microsoft.AspNetCore.Mvc;
using Mov.ServicesContrats.Authenticate;
using Mov.ViewModels.User;
using System;
using System.Linq;
using System.Threading.Tasks;
using Mov.Controller;
using AutoMapper;

namespace Mov.Controllers.Authenticate
{
    [ApiController]
    [Route("api/Authenticate/[controller]/[action]")]
    public class AuthenticateController : CRUDController<DataModels.User.User,IAuthenticateService, ViewModels.User.User,int>
    {

        public AuthenticateController(IAuthenticateService authenticateService,IMapper mapper)
            :base(authenticateService,mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
            return Ok(await _dataService.Login(_mapper.Map<DataModels.User.User>(user)));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw new Exception(errors.FirstOrDefault());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var dataModel = _mapper.Map<DataModels.User.User>(user);
            return Ok(await _dataService.Register(dataModel));
        }
    }
}
