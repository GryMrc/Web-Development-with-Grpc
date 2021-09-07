using Mov.Core.Model;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.DataModels.User
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Privilege : DataModel
    {
        [Column("PRIVILEGEID")]
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
