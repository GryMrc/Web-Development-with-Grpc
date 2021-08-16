using Mov.ViewModels.Crew;
using Mov.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ViewModels.User
{
    [DataContract]
    public class User
    {
        public string UserName { get; set; }
        public int PrivilegeId { get; set; }
        public string password { get; set; }
        public Privilege Privilege { get; set; }
        public List<Director> Directors { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
