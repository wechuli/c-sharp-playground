using System;

namespace customNamespace
{
    public class RandomAdvert
    {

        private string[] laudatoryPhrases = { "The product is excellent.", "This is a great product.", "I use this product constantly.", "This is the best product from this category." };
        private string[] laudatoryStories = { "Now I feel better.", "I managed to change.", "It made some miracle.", "I can’t believe it, but now I am feeling great.", "You should try it, too. I am very satisfied." };
        private string[] firstNames = { "Dayan", "Stella", "Hellen", "Kate" };
        private string[] lastNames = { "Johnson", "Peterson", "Charls" };
        private string[] cities = { "London", "Paris", "Berlin", "New York", "Madrid" };

        public RandomAdvert()
        {


        }

        public string GenerateRandomAd()
        {
            Random rand = new Random();

            string laudatoryPhrase = laudatoryPhrases[rand.Next(laudatoryPhrases.Length)];
            string laudatoryStory = laudatoryStories[rand.Next(laudatoryStories.Length)];
            string firstName = firstNames[rand.Next(firstNames.Length)];
            string lastName = lastNames[rand.Next(lastNames.Length)];
            string city = cities[rand.Next(cities.Length)];

            return laudatoryPhrase + " " + laudatoryStory + " --" + firstName + " " + lastName + "," + city;
        }


    }

}