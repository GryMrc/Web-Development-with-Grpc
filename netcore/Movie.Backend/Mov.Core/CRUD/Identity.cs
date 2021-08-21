using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.CRUD
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Identity<TId>
    {
        public TId Id { get; set; }
    }
}
