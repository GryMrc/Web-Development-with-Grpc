using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mov.Controller;
using Mov.ServicesContrats.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Controllers.Country
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CountryController : CRUDController<DataModels.Country.Country, ICountryService, ViewModels.Country.Country, int>
    {
        public CountryController(ICountryService countryService, IMapper mapper)
          : base(countryService, mapper)
        {
        }
    }
}
