using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Controller;
using Mov.Core.ServiceResponse;
using Mov.ServicesContrats.Privilege;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Controllers.Privilege
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PrivilegeController : CRUDController<DataModels.User.Privilege, IPrivilegeService, ViewModels.User.Privilege, int>
    {
        public PrivilegeController(IPrivilegeService privilegeService, IMapper mapper)
           : base(privilegeService, mapper)
        {
        }
    }
}
