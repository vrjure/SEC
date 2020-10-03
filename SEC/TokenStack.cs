using SEC.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SEC
{
    public class TokenStack : ICollection, IEnumerable<INodeToken>, IEnumerable
    {
        private INodeToken[] array;
        private int size;
        private int version;

        private object syncObject;

        public int Count => size;

        public bool IsSynchronized => false;

        public object SyncRoot
        {
            get
            {
                if (syncObject == null)
                {
                    return System.Threading.Interlocked.CompareExchange<Object>(ref syncObject, new Object(), null);
                }
                return syncObject;
            }
        }

        private static int defaultCapacity = 4;
        public TokenStack()
        {
            array = new INodeToken[0];
            size = 0;
            version = 0;
        }

        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<INodeToken> GetEnumerator()
        {
            int ver = version;
            for (int i = 0; i < size; i++)
            {
                if (ver != version)
                {
                    throw new InvalidOperationException("Collection is changed");
                }

                yield return array[i];
            }
        }

        public bool TryFindLastOperator(out OperatorToken op)
        {
            for (int i = size - 1; i >=0; i--)
            {
                var token = array[i];
                if (token is OperatorToken opt)
                {
                    op = opt;
                    return true;
                }
            }
            op = null;
            return false;
        }

        public IEnumerable<INodeToken> PopEnd(INodeToken end)
        {
            while (size > 0)
            {
                var token = Pop();
                yield return token;
                if (token.Equals(end))
                {
                    break;
                }
            }
        }

        public INodeToken Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("stack is empty");
            }
            return array[size - 1];
        }

        public INodeToken Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("stack is empty");
            }
            version++;
            var token = array[--size];
            array[size] = null;
            return token;
        }

        public void Push(INodeToken token)
        {
            if (size == array.Length)
            {
                INodeToken[] newArray = new INodeToken[array.Length == 0 ? defaultCapacity : 2 * array.Length];
                Array.Copy(array, 0, newArray, 0, size);
                array = newArray;
            }
            array[size++] = token;
            version++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
