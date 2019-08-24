using System;
using System.Collections;

namespace arrayList
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList list = new ArrayList();
            list.Add("Hello");
            list.Add(5);
            list.Add(3.14159);
            list.Add(DateTime.Now);

            for (int i = 0; i < list.Count; i++)
            {
                object value = list[i];
                Console.WriteLine($"Index={i}; Value={value}");
            }


            var numberList = new ArrayList();
            numberList.Add(2);
            numberList.Add(3.5f);
            numberList.Add(25u);
            numberList.Add(" EUR");

            dynamic sum = 0;

            for (int i = 0; i < numberList.Count; i++)
            {
                dynamic value = numberList[i];
                sum = sum + value;
            }

            Console.WriteLine("Sum = " + sum);


        }
    }
}
