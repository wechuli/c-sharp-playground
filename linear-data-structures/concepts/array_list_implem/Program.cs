using System;

namespace array_list_implem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class CustomArrayList<T>
    {
        private T[] arr;
        private int count;

        //Returns the actual list length
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        private const int INITIAL_CAPACITY = 4;

        //Initializes the array-based list - allocate memory

        public CustomArrayList(int capacity = INITIAL_CAPACITY)
        {
            this.arr = new T[capacity];
            this.count = 0;
        }

        //Adds element to the list

        public void Add(T item)
        {
            GrowIfArrIsFull();
            this.arr[this.count] = item;
            this.count++;
        }

        //Insert the specified element at a given position in this list

        public void Insert(int index, T item)
        {
            if (index > this.count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            GrowIfArrIsFull();
            Array.Copy(this.arr, index, this.arr, index + 1, this.count - index);
            this.arr[index] = item;
            this.count++;

        }
    }
}
