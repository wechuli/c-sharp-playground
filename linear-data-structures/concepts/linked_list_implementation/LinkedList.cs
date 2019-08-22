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
        private ListNode head;
        private ListNode tail;
        private int count;

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
            if (object.ReferenceEquals(this.tail, node))
            {
                this.tail = prevNode;
            }
        }

        //Removes the specified item and return its index

        public int Remove(T item)
        {
            //Find the element containing the searched item
            int currentIndex = 0;
            ListNode currentNode = this.head;
            ListNode prevNode = null;
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
                // The element is found in the list -> remove it
                RemoveListNode(currentNode, prevNode);
                return currentIndex;
            }
            else
            {
                //The element is not found in the list -> return -1
                return -1;
            }
        }

        //Searches for given element in the list

        public int IndexOf(T item)
        {
            int index = 0;
            ListNode currentNode = this.head;
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

        //Checks if the specified element exists in thenlist

        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool found = (index != -1);
            return found;
        }


        //Gets or sets the element at the specified position

        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                ListNode currentNode = this.head;
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
                ListNode currentNode = this.head;
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
            get { return this.count; }
        }
    }
}