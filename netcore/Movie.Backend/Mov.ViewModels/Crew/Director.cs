using Mov.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ViewModels.Crew
{
    public class Director
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Nation { get; set; }
        public int UserId { get; set; }
        public User.User User { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
