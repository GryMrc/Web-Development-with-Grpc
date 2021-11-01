using Mov.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ViewModels.User
{
    public class Privilege:ViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
