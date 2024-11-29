using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class SinglyLinkedList<T> : LinkedListBase<T>
        where T : IEquatable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }
            public Node(T value)
            {
                Value = value;
            }
        }

        private Node? Head { get; set; }
        
        public SinglyLinkedList()
        {
            Head = null;
        }

        public SinglyLinkedList(T value)
        {
            Head = new Node(value);
            Count = 1;
        }

        public override T this[int index]
        {
            get
            {
                // Index Validation
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                Node current = Head!;

                // Linked List Traversal
                for(int i = 0; i < index; i++) 
                {
                    current = current.Next!;
                }

                return current!.Value;
            }
        }
        public override void Insert(T value)
        {
            Insert(value, Count);
        }

        public override void Insert(T value, int index)
        {
            // Index Validation
            if (index > Count || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node newNode = new Node(value);

            // List is empty
            if (Head == null)
            {
                Head = newNode;
            }
            
            // Inserting at the beginning
            else if (index == 0)
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else 
            {
                Node current = Head!;

                // - 1 because we want to stop at the node before the insert
                for (int i = 0; i < index - 1; i++)
                {
                    // Traversing through the linked list
                    current = current!.Next!;
                }

                // Initialize new node's reference
                newNode.Next = current.Next;

                // Update existing node's reference
                current.Next = newNode;
            }

            Count++;
        }

        public override void Remove(T value)
        {
            Node current = Head!;
            Node previous = null!;

            for(int i = 0; i < Count; i++)
            {
                if(current.Value.Equals(value))
                {
                    // Decapitation
                    if (previous == null)
                    {
                        Head = Head!.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    Count--;
                    return;
                }

                // Traversing through the linked list
                previous = current;
                current = current!.Next!;
            }
        }

        public override void RemoveAt(int index)
        {
            // Index Validation
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            // Decapitation
            if (index == 0)
            {
                Head = Head!.Next;
            }
            else
            {
                Node current = Head!;

                // Traversal
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next!;
                }

                // Removal
                current.Next = current.Next!.Next;
                Count--;
            }
        }

        public override int Search(T value)
        {
            Node current = Head!;
            
            for (int i = 0; i < Count; i++)
            {
                if(current.Value.Equals(value))
                {
                    return i;
                }
                
                current = current.Next!;
            }

            return -1;
        }

        public override void Clear()
        {
            Head = null;
            Count = 0;
        }
    }
}
