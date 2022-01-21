using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Exceptionhandler
{
    public interface IExceptionSerializer
    {
        void Serialize(Exception exception, Stream stream);
        Exception Deserialize(Stream stream);
    }
}
