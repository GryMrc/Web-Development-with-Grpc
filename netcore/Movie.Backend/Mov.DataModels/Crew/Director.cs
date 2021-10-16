using Mov.Core.Model;
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
    public class Director:DataModel
    {
        [Column("DIRECTORID")]
        public int Id { get; set; }
        [Column("PERSON")]
        public int PersonId { get; set; }
        public Person.Person Person{ get; set; }
        [Column("CREATE_DT")]
        public DateTime CreateDate { get; set; }
        [Column("UPDATE_DT")]
        public DateTime UpdateDate { get; set; }
        [Column("CREATEUSER")]
        public int UserId { get; set; }
        public User.User User { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
