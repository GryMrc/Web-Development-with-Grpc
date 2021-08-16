using Mov.DataModels.Crew;
using Mov.DataModels.Movies;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mov.DataModels.User
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [DataContract]
    public class User
    {
        [Column("USERID")]
        public int Id { get; set; }
        [Column("USER_NAME")]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Column("PRIVILEGE")]
        public int PrivilegeId { get; set; }
        public Privilege Privilege { get; set; }
        public List<Director> Directors { get; set; }
        public List<Movie> Movies { get; set; }

        [NotMapped]
        public string password { get; set; }
    }
}
