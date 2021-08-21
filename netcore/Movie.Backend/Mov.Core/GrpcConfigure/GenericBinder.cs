using ProtoBuf.Grpc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core
{
        public class GenericBinder : ServiceBinder
        {
            protected override string GetDefaultName(Type contractType)
            {
                var val = base.GetDefaultName(contractType);
                if (val.EndsWith("`1") && contractType.IsGenericType)
                {   // replace IFoo`1 with IFoo`TheThing
                    var args = contractType.GetGenericArguments();
                    if (args.Length == 1)
                    {
                        val = val[0..^1] + args[0].Name;
                    }
                }
                return val;
            }
        }
    }

