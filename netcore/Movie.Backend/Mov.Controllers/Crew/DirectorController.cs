using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Controller;
using Mov.Core.CRUD;
using Mov.ServicesContrats.Crew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Controllers.Crew
{
    [ApiController]
    [Route("api/Crew/[controller]/[action]")]
    public class DirectorController : CRUDController<DataModels.Crew.Director, IDirectorService, ViewModels.Crew.Director, int>
    {
        public DirectorController(IDirectorService directorService, IMapper mapper):base(directorService,mapper)
        {

        }
    }
}
