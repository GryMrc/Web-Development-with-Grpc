using Mov.Core.Model;
using Mov.DataModels.Crew;
using Mov.DataModels.Movies;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mov.DataModels.User
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class User:DataModel
    {
        [Column("USERID")]
        public int Id { get; set; }
        [Column("USERNAME")]
        [Required]
        public string UserName { get; set; }
        [Column("PASSWORDHASH")]
        public byte[] PasswordHash { get; set; }
        [Column("PASSWORDSALT")]
        public byte[] PasswordSalt { get; set; }
        [Column("PRIVILEGE")]
        public int PrivilegeId { get; set; }
        public Privilege Privilege { get; set; }
        public List<Movie> Movies { get; set; }
        [NotMapped]
        public string password { get; set; }
    }
}
