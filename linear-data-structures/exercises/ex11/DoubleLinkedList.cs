using System;
using System.Collections.Generic;

namespace ex11
{
    public class DoublyLinkedList<T>
    {

        private DoublyLinkedListNode tail;
        private DoublyLinkedListNode head;

        private class DoublyLinkedListNode
        {
            private T item;
            private DoublyLinkedListNode previousNode;
            private DoublyLinkedListNode nextNode;

        }

        // add element to the list
        public void Add(T item)
        {

        }

        public T RemoveAt(int index)
        {

        }
        public T RemoveItem(T item)
        {

        }

        public bool Contains(T item)
        {

        }


    }
}