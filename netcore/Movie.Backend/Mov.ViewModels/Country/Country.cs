using Mov.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace Mov.ViewModels.Country
{
    public class Country : ViewModel
    {
        public int? id { get; set; } // Bu kisim ulke alan kodlari olacak on taraftan manuel olarak girilecek.
                                    // ViewModel mapper ederken eksik alanlar olunca neden hata veriyor?
        [Required]
        public string Name { get; set; }
    }
}
