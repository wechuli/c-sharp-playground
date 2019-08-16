using System;
namespace linked_list_implementation
{
    public class DynamicList<T>
    {
        private class ListNode
        {
            public T Element { get; set; }
            public ListNode NextNode { get; set; }

            public ListNode(T element)
            {
                this.Element = element;
                NextNode = null;
            }
            public ListNode(T element, ListNode prevNode)
            {
                this.Element = element;
                prevNode.NextNode = this;
            }
        }
        private T head;
        private ListNode tail;
        private ListNode count;

        public DynamicList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        // Add an element at the end of the list

        public void Add(T item)
        {
            if (this.head == null)
            {
                // We have an empty list -> create a new head and tail
                this.head = new ListNode(item);
                this.tail = this.head;
            }
            else
            {
                //We have a non-empty list - > append the item after the tail
                ListNode newNode = new ListNode(item, this.tail);
                this.tail = newNode;
            }

            this.count++;
        }

        //Removies and returns element on the specified index
        public T RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            // Find the element at the specified index
            int currentIndex = 0;
            ListNode currentNode = this.head;
            ListNode prevNode = null;

            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            //Remove the found element from the list of nodes

            RemoveListNode(currentNode, prevNode);

            //return the removed element
            return currentNode.Element;
        }

        //Remove the specified node from the list of nodes

        private void RemoveListNode(ListNode node, ListNode prevNode)
        {
            count--;
            if (count == 0)
            {
                //The list becomes empty -> remove head and tail
                this.head = null;
                this.tail = null;
            }
            else if (prevNode == null)
            {
                //The head node was removed --> update the head
                this.head = node.NextNode;
            }
            else
            {
                //Redirect the pointers to skip the removed node
                prevNode.NextNode = node.NextNode;
            }
            //Fix the tail in case it was removed
            if (object.ReferenceEquals(this.tail, noe))
            {
                this.tail = prevNode;
            }
        }
    }
}