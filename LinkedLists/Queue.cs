using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class Queue<T>
        where T : IEquatable<T>
    {
        private readonly DoublyLinkedList<T> linkedList = new DoublyLinkedList<T>();
        public int Count => linkedList.Count;
        public bool IsEmpty => linkedList.IsEmpty;
        public void Enqueue(T value)
        {
            linkedList.Insert(value);
        }
        public T Dequeue()
        {
            if (linkedList.IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T value = linkedList[0];
            linkedList.RemoveAt(0);
            return value;
        }
        public T Peek()
        {
            if (linkedList.IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return linkedList[0];
        }
        public void Clear() => linkedList.Clear();
        public override string ToString() => linkedList.ToString();
        
    }
}
