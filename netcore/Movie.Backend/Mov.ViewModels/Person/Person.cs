using Mov.Core.Model;
using Mov.ViewModels.Country;


namespace Mov.DataModels.Person
{
    public class Person : ViewModel
    {
        public int Id { get; set; } // Integer kisimlar icin required vermek gerekiyor fakat Id otomatik not null oluyor entityFramework tools.
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
