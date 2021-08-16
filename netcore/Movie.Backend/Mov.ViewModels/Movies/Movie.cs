using Mov.ViewModels.Crew;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ViewModels.Movies
{
    public class Movie
    {

        public string Name { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public float IMDB { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Promo { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
        public User.User User { get; set; }
        public string UserComment { get; set; }
    }
}
