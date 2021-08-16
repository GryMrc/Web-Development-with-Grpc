using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Controllers
{
    public class MappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "MappingProfile";
            }
        }

        public MappingProfile()
        {
            ConfigureMappings();
        }


        /// <summary>
        /// Creates a mapping between source (Domain) and destination (ViewModel)
        /// </summary>
        private void ConfigureMappings()
        {
            CreateMap<DataModels.User.User, ViewModels.User.User>().ReverseMap();
            CreateMap<DataModels.User.Privilege, ViewModels.User.Privilege>().ReverseMap();
            CreateMap<DataModels.Crew.Director, ViewModels.Crew.Director>().ReverseMap();
            CreateMap<DataModels.Movies.Movie, ViewModels.Movies.Movie>().ReverseMap();
        }
    }
}
