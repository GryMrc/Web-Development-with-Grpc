using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.MovException
{ 
    [AttributeUsage(AttributeTargets.All)]
    public class MovErrorDetailAttribute : Attribute
    {
        public string Message { get; set; }
    }
}
