using Mov.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace Mov.ViewModels.Country
{
    public class Country : ViewModel
    {
        [Required]
        public int Id { get; set; } // Bu kisim ulke alan kodlari olacak on taraftan manuel olarak girilecek.
        [Required]
        public string Name { get; set; }
    }
}
