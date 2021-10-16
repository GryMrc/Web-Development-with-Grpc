using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov.Core.Model;
using Mov.DataModels.Country;
using Mov.DataModels.Crew;
using ProtoBuf;

namespace Mov.DataModels.Person
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Person:DataModel
    {
        [Column("PERSONID")]
        public int Id { get; set; } // Integer kisimlar icin required vermek gerekiyor fakat Id otomatik not null oluyor entityFramework tools.
        [Column("NAME")]
        [Required]
        public string Name { get; set; }
        [Column("AGE")]
        [Required]
        public int Age { get; set; }
        [Column("GENDER")]
        [Required]
        public char Gender { get; set; }
        [Column("COUNTRY")]
        public int CountryId { get; set; }
        public Country.Country Country { get; set; }
    }
}
