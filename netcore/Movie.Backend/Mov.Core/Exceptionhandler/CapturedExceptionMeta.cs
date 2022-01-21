using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Exceptionhandler
{
    public class CapturedExceptionMeta
    {
        [JsonProperty("ExceptionType")]
        public Type ExceptionType { get; }

        [JsonProperty("Serialized")]
        public byte[] Serialized { get; }

        [JsonConstructor]
        public CapturedExceptionMeta(Type exceptionType, byte[] serialized)
        {
            ExceptionType = exceptionType;
            Serialized = serialized;
        }
    }
}
