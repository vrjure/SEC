using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC
{
    public class SECParser
    {
        private readonly TextReader tr;
        public SECParser(string text, Type resultType)
        {
            this.tr = new StringReader(text);
        }

    }
}
