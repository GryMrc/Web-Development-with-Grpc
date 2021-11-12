using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.MovException
{
    [Serializable]
    public class MovException : Exception
    {
        public MovException(string error)
          : base(error)
        {

        }
    }
}
