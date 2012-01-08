using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TddTetris
{
    public class FieldException:Exception
    {
        public FieldExceptionCode Code { get; set; }
    }

    public enum FieldExceptionCode
    {
        BadBlockPlacement

    }
}
