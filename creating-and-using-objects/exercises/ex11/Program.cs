using System;
using customNamespace;

namespace ex11
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomAdvert advert = new RandomAdvert();
            Console.WriteLine(advert.GenerateRandomAd());
            Console.WriteLine(advert.GenerateRandomAd());
            Console.WriteLine(advert.GenerateRandomAd());
            Console.WriteLine(advert.GenerateRandomAd());

        }
    }
}
