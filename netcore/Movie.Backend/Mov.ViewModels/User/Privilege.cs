using Mov.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ViewModels.User
{
    public class Privilege:ViewModel
    {
        public string Role { get; set; }
    }
}
