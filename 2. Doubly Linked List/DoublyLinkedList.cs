namespace Problem02.DoublyLinkedList
{
    using LinkedList;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(T item)
        {
            Node<T> node = new Node<T>(item);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.NextNode = Head;
                Head.PreviousNode = node;
                Head = node;
            }

            Count++;
        }


        public void AddLast(T item)
        {
            Node<T> node = new Node<T>(item);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.NextNode = node;
                node.PreviousNode = Tail;
                Tail = node;
            }

            Count++;
        }

      
        public T GetFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }

            return Head.Value;
        }


        public T GetLast()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }

            return Tail.Value;
        }


        public T RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }

            T value = Head.Value;


            if (Count == 1)
            {
                Head = null;
                Tail = null;
                Count = 0;

                return value;
            }

       
            Node<T> item = Head;
            Head = Head.NextNode;
            item.NextNode = null;
            Head.PreviousNode = null;
            Count--;

            return value;
        }

        public T RemoveLast()
        {
            if(Head == null)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }

            T value = Tail.Value;

            if (Count == 1)
            {
                Head = null;
                Tail = null;
                Count = 0;

                return value;
            }


            Node<T> item = Tail;

            Tail = Tail.PreviousNode;
            item.PreviousNode = null;
            Tail.NextNode = null;
            Count--;

            return value;
        }


        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = Head;

            while(currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
