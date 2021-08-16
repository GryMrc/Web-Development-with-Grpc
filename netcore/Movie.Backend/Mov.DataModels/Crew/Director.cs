using Mov.DataModels.Movies;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.DataModels.Crew
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Director
    {
        [Column("DIRECTORID")]
        public int Id { get; set; }
        [Column("DIRECTOR_NAME")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Nation { get; set; }
        [Column("CREATE_DT")]
        public DateTime CreateDate { get; set; }
        [Column("UPDATE_DT")]
        public DateTime UpdateDate { get; set; }
        [Column("CREATE_USER")]
        public int UserId { get; set; }
        public User.User User { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
