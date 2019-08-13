using System;

namespace array_list_implem
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomArrayList<string> myList = new CustomArrayList<string>(45);
            myList.Add("It works");
            Console.WriteLine(myList.Count);

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

        //Doubles the size of this.arr(grow) if it is full

        private void GrowIfArrIsFull()
        {
            if (this.count + 1 > this.arr.Length)
            {
                T[] extendedArr = new T[this.arr.Length * 2];
                Array.Copy(this.arr, extendedArr, this.count);
                this.arr = extendedArr;
            }
        }

        //Clears the list(remove everything)

        public void Clear()
        {
            this.arr = new T[INITIAL_CAPACITY];
            this.count = 0;
        }

        //Returns the index of the first occurence of the specified element in this list(or -1 if it does not exist)

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (object.Equals(item, this.arr[i]))
                {
                    return i;
                }
            }
            return -1;
        }


        // Checks if an element exists

        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool found = (index != -1);
            return found;
        }


        //Indexer:access to element at a given index

        public T this[int index]
        {
            get
            {
                if (index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                return this.arr[index];
            }
            set
            {
                if (index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }
                this.arr[index] = value;
            }
        }

        public T RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException(
    "Invalid index: " + index);
            }

            T item = this.arr[index];
            Array.Copy(this.arr, this.count + 1, this.arr, index, this.count - index - 1);
            this.arr[this.count - 1] = default(T);
            this.count--;
            return item;
        }
        // Removes the specified item

        public int Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                this.RemoveAt(index);
            }
            return index;
        }

    }
}
