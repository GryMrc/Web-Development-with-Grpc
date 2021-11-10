using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.MovException
{
    public enum MovErrors
    {
        [MovErrorDetail(Message = "Model Not Found")]
        ModelNotFound = 0
    }
}
