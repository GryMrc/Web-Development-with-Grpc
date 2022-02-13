using Mov.Core.Model;
using Mov.ViewModels.Movies;
using Mov.ViewModels.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ViewModels.Crew
{
    public class Director:ViewModel
    {
        public int Id { get; set; } // Oto Id oldugu icin  required koymadim.
        //[Required]
        public int PersonId { get; set; }
        public Person.Person Person { get; set; }
        //[Required]
        public int UserId { get; set; }
        public User.User User { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
