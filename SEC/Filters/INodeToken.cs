﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public interface INodeToken: IEquatable<INodeToken>
    {
        string Token { get; }
    }
}
