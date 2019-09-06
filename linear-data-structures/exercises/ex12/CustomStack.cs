using System;
using System.Collections.Generic;

namespace ex12
{
    class CustomStack<T>
    {
        private int count;
        private LinkedList<T> stack;

        public CustomStack()
        {
            this.count = 0;
            this.stack = new LinkedList<T>();
        }

        public void Push(T item)
        {
            stack.AddFirst(item);
            this.count++;
        }

        public T Pop()
        {
            if (this.count == 0)
            {
                throw new ApplicationException("Empty Stack, no item to Pop");
            }
            this.count--;
            var topItem = stack.First;
            stack.RemoveFirst();
            return topItem.Value;

        }
        public T Peek()
        {
            return stack.First.Value;
        }

        public int Count()
        {
            return this.count;
        }

        public void Clear()
        {
            stack.Clear();
        }
        public bool Contains(T element)
        {
            return stack.Contains(element);
        }

    }
}