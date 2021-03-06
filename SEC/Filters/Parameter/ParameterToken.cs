﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class ParameterToken : NodeToken
    {
        private readonly Func<string, double> getValueFunc;
        public ParameterToken(string token, Func<string, double> getValFunc) : base(token)
        {
            this.getValueFunc = getValFunc;
        }

        public override void Parse(TokenStack stack, IEnumerator<INodeToken> reader, ISECParser parser)
        {
            var value = getValueFunc(Token);
            var numberToken = new NumberToken(value.ToString(), value);
            stack.Push(numberToken);
        }
    }
}
