using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public interface ITokenCollection : ICollection<INodeToken>
    {
        new void Add(INodeToken item);
        new void CopyTo(INodeToken[] array, int arrayIndex);
        new bool Remove(INodeToken item);

        void Push(INodeToken token);
        INodeToken Peek();
        INodeToken Pop();
        IEnumerable<INodeToken> Peek(int count);
        IEnumerable<INodeToken> PeekEnd(INodeToken token);
    }
}
