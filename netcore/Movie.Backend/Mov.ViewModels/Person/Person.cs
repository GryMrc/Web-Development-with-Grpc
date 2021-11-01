using Mov.Core.Model;
using Mov.ViewModels.Country;
using System.ComponentModel.DataAnnotations;

namespace Mov.ViewModels.Person
{
    public class Person : ViewModel
    {
        public int Id { get; set; } // Integer kisimlar icin required vermek gerekiyor fakat Id otomatik(Primary Key oldugu icin) not null oluyor entityFramework tools.
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(typeof(int), "0", "100")]
        public int Age { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public int? CountryId { get; set; } // int'in default valuesi oldugu icin ? ile nullable yapip required dedim ( modelState kontrolu icin )
        public Country.Country Country { get; set; }
    }
}
