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
        public int ErrorNo { get; }
        public string Label { get; set; }
        public string ErrorText { get; set; }
        public object[] StateParameters { get; }
        public int ErrorLevel { get; set; }
        public long ErrorType { get; set; }

        public MovException(int errorNo, string title, string message, Exception innerException, params object[] stateParameters)
            : base(message, innerException)
        {
            this.ErrorNo = errorNo;
            this.Label = title;
            this.ErrorText = message;
            this.StateParameters = stateParameters;
        }

        public MovException(MovErrors error)
          : this((int)error, null, null, null)
        {

        }

       

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(ErrorNo), this.ErrorNo);
            info.AddValue(nameof(ErrorLevel), this.ErrorLevel);
            info.AddValue(nameof(ErrorType), this.ErrorType);
            info.AddValue(nameof(Label), this.Label);
            info.AddValue(nameof(ErrorText), this.ErrorText);
            info.AddValue(nameof(StateParameters), this.StateParameters);
        }
    }
}
