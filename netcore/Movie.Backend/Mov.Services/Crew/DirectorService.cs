using Microsoft.EntityFrameworkCore;
using Mov.Core.CRUD;
using Mov.Core.ListParams;
using Mov.Core.ServiceResponse;
using Mov.DataModels.Crew;
using Mov.Mutual;
using Mov.Service;
using Mov.ServicesContrats.Crew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Services.Crew
{
    public class DirectorService : CRUDService<Director, Identity<int>>, IDirectorService
    {
        private readonly ApplicationDbContext _context;
        public DirectorService(ApplicationDbContext context):base(context, context.Directors)
        {
            this._context = context;
        }

        public async override Task<Director> Create(Director model)
        {
            await _context.People.AddAsync(model.Person);
            await _dbContext.SaveChangesAsync();
            model.PersonId = model.Person.Id;
            model.Person = null;
            model.CreateDate = DateTime.Now; // Bu iki create date ve userId appContext gibi bir
                                             // yapidan dolacak ve o appcontext vererek kayit edicez
                                             // tokendan okuyacagiz her bir istekte şimdilik böyle yaptim gecici
                                             // ve iki kayit atiliyor transaction ici olmasi gerek.
            model.UserId = 4;
            return await base.Create(model);
        }
        public async override Task<ServiceResponse> Delete(Identity<int> id)
        {
            throw new NotImplementedException();
        }

        public async override Task<Director> Read(Identity<int> id)
        {
            throw new NotImplementedException();
        }

        public async override Task<IEnumerable<Director>> List(ListParams listParams)
        {
            return await _modelDbSet.Include(p => p.Person).ThenInclude(c => c.Country)
                                    .Skip((listParams.page - 1) * listParams.pageSize)
                                    .Take(listParams.pageSize)
                                    .ToListAsync();
        }
    }
}
