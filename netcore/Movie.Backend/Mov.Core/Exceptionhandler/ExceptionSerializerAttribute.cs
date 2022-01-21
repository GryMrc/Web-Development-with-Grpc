using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Exceptionhandler
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExceptionSerializerAttribute : Attribute
    {
        public Type SerializerType { get; }

        public ExceptionSerializerAttribute(Type serializerType)
        {
            SerializerType = serializerType;
        }
    }
}
