using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public abstract class LinkedListBase<T>
        where T : IEquatable<T>
    {
        // Indexing override
        public abstract T this[int index] { get; }
        public int Count { get; protected set; }
        public bool IsEmpty => Count == 0;

        protected LinkedListBase()
        {
            Count = 0;
        }

        public abstract void Insert(T value);
        public abstract void Insert(T value, int index);
        public abstract void Remove(T value);
        public abstract void RemoveAt(int index);
        public abstract int Search(T value);
        public abstract void Clear();
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < Count; i++)
            {
                sb.AppendLine($"[{i}]: {this[i]}");
            }

            return sb.ToString();
        }

    }
}
