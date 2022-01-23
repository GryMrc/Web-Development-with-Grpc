using Mov.Core.CRUD;
using Mov.Core.ServiceResponse;
using Mov.Mutual;
using Mov.Service;
using Mov.ServicesContrats.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Services.Country
{
    public class CountryService : CRUDService<DataModels.Country.Country, Identity<int>>, ICountryService
    {
        private readonly ApplicationDbContext context;

        public CountryService(ApplicationDbContext context) : base(context, context.Countries)
        {
            this.context = context;
        }
        public override Task<ServiceResponse> Delete(Identity<int> id)
        {
            throw new NotImplementedException();
        }

        public override Task<DataModels.Country.Country> Read(Identity<int> id)
        {
            throw new NotImplementedException();
        }
    }
}
