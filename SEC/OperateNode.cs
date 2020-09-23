using System;
using System.Collections.Generic;
using System.Text;

namespace SEC
{
    class OperateNode
    {
        public OperateNode(NodeToken left, NodeToken right, TokenFilter op)
        {
            this.Operator = op;
            this.Left = left;
            this.Right = right;
        }
        public TokenFilter Operator { get; }
        public NodeToken Left { get;  }
        public NodeToken Right { get; }
    }
}
