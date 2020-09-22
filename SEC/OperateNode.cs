using System;
using System.Collections.Generic;
using System.Text;

namespace SEC
{
    class OperateNode
    {
        public TokenFilter Operator { get; set; }
        public object Left { get; set; }
        public object Right { get; set; }

        public OperateNode Next { get; set; }
    }
}
