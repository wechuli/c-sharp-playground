using System;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<Dog> dogHouse = new GenericList<Dog>(5);

            Dog maxi = new Dog("Maxi");
            Dog sandac = new Dog("Sandac");

            dogHouse.AddElementToList(maxi);
            dogHouse.ToString();
            dogHouse.AddElementToList(sandac);
            Console.WriteLine(dogHouse.AddElementToList(maxi));
            dogHouse.AddElementToList(sandac);
            dogHouse.AddElementToList(sandac);
            dogHouse.ToString();
            Console.WriteLine(dogHouse.AddElementToList(maxi));
            dogHouse.RemoveElementByIndex(5);
            Console.WriteLine(dogHouse.AddElementToList(maxi));



        }
    }


    class Dog
    {
        public string Name { get; set; }
        public Dog(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }

    class GenericList<T>
    {
        private T[] elementList;

        public GenericList(int arraySize)
        {

            this.elementList = new T[arraySize];
        }

        public bool AddElementToList(T element)
        {

            for (int i = 0; i < this.elementList.Length; i++)
            {
                if (this.elementList[i] == null)
                {
                    this.elementList[i] = element;
                    return true;
                }
            }
            return false;
        }
        public T AccessElementByIndex(int index)
        {
            if (index >= this.elementList.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            return this.elementList[index];
        }
        public bool RemoveElementByIndex(int index)
        {
            if (index >= this.elementList.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            this.elementList.SetValue(null, index);
            return true;
        }
        public bool ClearList()
        {
            for (int i = 0; i < this.elementList.Length; i++)
            {
                elementList[i] = default(T);
            }
            return true;
        }
        public bool InsertItemAtPosition(T item, int index)
        {
            if (index >= this.elementList.Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            this.elementList[index] = item;
            return true;
        }

        public new void ToString()
        {

            for (int i = 0; i < this.elementList.Length; i++)
            {
                Console.WriteLine(this.elementList[i]);
            }
        }
    }
}
