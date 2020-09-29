using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC
{
    public class SECParserBuilder
    {
        internal Dictionary<string, int> OperatorDict = new Dictionary<string, int>();

        public void AddOperator(string op, int priority)
        {
            this.OperatorDict.Add(op, priority);
        }

    }
}
