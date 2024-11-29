using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class DoublyLinkedList<T> : LinkedListBase<T>
        where T : IEquatable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }
            public Node? Previous { get; set; }
            public Node(T value)
            {
                Value = value;
            }
        }

        private Node? Head {  get; set; }
        private Node? Tail { get; set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public DoublyLinkedList(T value)
        {
            Head = new Node(value);
            Tail = Head;
            Count = 1;
        }

        public override T this[int index]
        {
            get
            {
                // Index validation
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                Node current = null;

                // Index is closer to the head node
                if (index < Count / 2)
                {
                    current = Head!;

                    // Traversal
                    for (int i = 0; i < index; i++)
                    {
                        current = current!.Next!;
                    }
                }
                
                // Index is closer to the tail node
                else
                {
                    current = Tail!;

                    // Traversal
                    for (int i = Count - 1; i > index; i--)
                    {
                        current = current.Previous!;
                    }
                }

                return current.Value!;
            }
        }
        public override void Insert(T value)
        {
            Insert(value, Count);
        }

        public override void Insert(T value, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node newNode = new Node(value);

            // No nodes exist in the linked list
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }

            // New head
            else if (index == 0)
            {
                // When creating reference types, they point to something by default
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }
            else if (index == Count)
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }
            else
            {
                Node current = null;

                // Index is closer to the head node
                if (index < Count / 2)
                {
                    current = Head!;

                    // Traversal
                    for (int i = 0; i < index; i++)
                    {
                        current = current!.Next!;
                    }

                    // Initialize new node references
                    newNode.Next = current.Next;
                    newNode.Previous = current;
                    
                    // Change existing references
                    current.Next!.Previous = newNode;
                    current.Next = newNode;
                }

                // Index is closer to the tail node
                else
                {
                    current = Tail!;

                    // Traversal
                    for (int i = Count - 1; i > index - 1; i--)
                    {
                        current = current!.Previous!;
                    }

                    // Initialize new node references
                    newNode.Next = current.Next;
                    newNode.Previous = current;

                    // Change existing references
                    current.Next!.Previous = newNode;
                    current.Next = newNode;
                }
            }
            Count++;
        }

        public override void Remove(T value)
        {
            Node? current = Head;

            // Traverse the list
            while (current != null && current.Value.Equals(value) == false)
            {
                current = current.Next!;
            }

            if (current != null)
            {
                // Decapitation
                if (current == Head)
                {
                    Head = Head.Next;
                    Head!.Previous = null;
                }
                
                // Caudectomy
                if (current == Tail)
                {
                    Tail = Tail.Previous;
                    Tail!.Next = null;
                }

                // Standard removal
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }

                Count--;
            }
        }

        public override void RemoveAt(int index)
        {
            // Index validation
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            
            // Decapitation
            if (index == 0)
            {
                Head = Head!.Next;
                Head!.Previous = null;
            }
            // Caudectomy
            else if (index == Count - 1)
            {
                Tail = Tail!.Previous;
                Tail!.Next = null;
            }

            else
            {
                Node current = null!;
                
                // Node to remove is closer to the head
                if (index < Count / 2)
                {
                    current = Head!;

                    // Traversal
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next!;
                    }
                }

                // Node to remove is closer to the tail
                else
                {
                    current = Tail!;

                    // Traversal
                    for (int i = Count - 1; i < index - 1; i--)
                    {
                        current = current.Previous!;
                    }
                }

                // Removal
                current.Next = current.Next!.Next;
                current.Next!.Previous = current;
            }

            Count--;
        }

        public override int Search(T value)
        {
            Node current = Head!;

            // Traversing the linked list
            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(value))
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
            Tail = null;
            Count = 0;
        }
    }
}
