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

            RemoveDoublyLinkedListNode(currentNode, prevNode);
            // returned the removed element
            return currentNode.Element;

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
                node.PreviousNode = null;
            }
            else
            {
                //REdirect the pointers to skip the removed node
                prevNode.NextNode = node.NextNode;

                if (node.NextNode != null)
                {
                    node.NextNode.PreviousNode = prevNode;
                }
            }
            // Fix the tail in case it was removed

            if (object.ReferenceEquals(this.tail, node))
            {
                this.tail = prevNode;
                this.tail.NextNode = null;
            }
        }

        // Removes the specified item and return its index
        public int Remove(T item)
        {
            // Find the element containing the searched item
            int currentIndex = 0;
            DoublyLinkedListNode currentNode = this.head;
            DoublyLinkedListNode prevNode = null;

            while (currentNode != null)
            {
                if (object.Equals(currentNode.Element, item))
                {
                    break;
                }
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
            if (currentNode != null)
            {
                //The element is found in the list -> remove it
                RemoveDoublyLinkedListNode(currentNode, prevNode);
                return currentIndex;
            }
            else
            {
                // The element is not found in the list -> return -1
                return -1;
            }

        }

        public int IndexOf(T item)
        {
            int index = 0;
            DoublyLinkedListNode currentNode = this.head;
            while (currentNode != null)
            {
                if (object.Equals(currentNode.Element, item))
                {
                    return index;
                }
                currentNode = currentNode.NextNode;
                index++;
            }
            return -1;
        }


        //Checks if the specified element exists in the list
        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool found = (index != -1);
            return found;
        }

        // Gets or sets the element at the specified position
        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                DoublyLinkedListNode currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                return currentNode.Element;
            }
            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                DoublyLinkedListNode currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                currentNode.Element = value;
            }
        }

        //Gets the count of elements in the list

        public int Count
        {
            get
            {
                return this.count;
            }
        }
    }
}