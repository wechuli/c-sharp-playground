using System;
using System.Collections.Generic;

namespace ex11
{
    public class DoublyLinkedList<T>
    {


        // hold the tail reference
        private DoublyLinkedListNode tail;

        //holds the head
        private DoublyLinkedListNode head;

        // element count
        private int count;

        private class DoublyLinkedListNode
        {
            public T Element { get; set; }
            public DoublyLinkedListNode PreviousNode { get; set; }
            public DoublyLinkedListNode NextNode { get; set; }

            // The first element of the chain, without prev and next
            public DoublyLinkedListNode(T element)
            {
                this.Element = element;
                this.PreviousNode = null;
                this.NextNode = null;
            }

            public DoublyLinkedListNode(T element, DoublyLinkedListNode prevNode)
            {
                this.Element = element;
                prevNode.NextNode = this;
                this.PreviousNode = prevNode;
            }

        }

        // Constructor

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        // add element to the end of the list
        public void Add(T item)
        {
            if (this.head == null)
            {
                // we have an empty list -> create a new head and tail
                this.head = new DoublyLinkedListNode(item);
                this.tail = this.head;
            }
            else
            {
                //we have a non-empty list - > append the item after the tail
                DoublyLinkedListNode newNode = new DoublyLinkedListNode(item, this.tail);
                this.tail = newNode;

            }
            this.count++;
        }


        // Removes and returns element on the specified index
        public T RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException($"Invalid index: ${index}");
            }
            // Find the element at the specified index
            int currentIndex = 0;
            DoublyLinkedListNode currentNode = this.head;
            DoublyLinkedListNode prevNode = null;

            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            // Remove the found element from the list of nodes

        }

        // Remove the specified node from the list of node

        private void RemoveDoublyLinkedListNode(DoublyLinkedListNode node, DoublyLinkedListNode prevNode)
        {
            count--;
            if (count == 0)
            {
                //The list becomes empty - > remove head and tail
                this.head = null;
                this.tail = null;
            }
            else if (prevNode == null)
            {
                //The head node was removed -- > update the head
                this.head = node.NextNode;
            }
        }
        public T RemoveItem(T item)
        {

        }

        public bool Contains(T item)
        {

        }


    }
}