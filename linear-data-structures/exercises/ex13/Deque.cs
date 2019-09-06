using System.Collections.Generic;
using System;


namespace ex13
{
    class Deque<T>
    {
        private List<T> queue;
        private int count;
        public int Count
        {
            get
            {
                return this.count;
            }

        }
        public Deque()
        {
            this.queue = new List<T>();
            this.count = 0;
        }

        public void Enqueue(T item)
        {
            this.queue.Add(item);
            this.count++;
        }

        public void EnqueueStart(T item)
        {
            this.queue.Insert(0, item);
            this.count++;
        }

        public T Dequeue()
        {
            this.count--;
            var element = this.queue[0];
            this.queue.RemoveAt(0);
            return element;

        }
        public T Peek()
        {
            return this.queue[0];
        }

        public void Clear()
        {
            this.queue.Clear();
        }

        public bool Contains(T item)
        {
            return this.queue.Contains(item);
        }
    }
}