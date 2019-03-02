using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool vendorOn = true;
            float credit = 0.0f;

            Console.WriteLine("This will simulate a vending machine");

            Dog tempDog = new Dog();

            tempDog.GetAge();

            while (vendorOn)
            {
                Console.WriteLine("Current Credit: " + credit);

                Console.WriteLine("What would you like to do? ");
                Console.WriteLine("1 - Add Credit");
                Console.WriteLine("2 - Get info on an item");
                Console.WriteLine("3 - Dispense an Item");
                Console.WriteLine("4 - Add new / Restock item");
                Console.WriteLine("5 - Remove item / All item");
                Console.WriteLine("6 - Shut down machine");
                Console.ReadLine();
            }
        }
    }

    class Item // base class that food and drink will inherit from
    {
        public int itemID;
        public string category;
        public float price;
        public string nutritionalInfo;

        public int GetItemID()
        {
            return itemID;
        }
        public string GetCategory()
        {
            return category;
        }
        public float GetPrice()
        {
            return price;
        }
        public string GetNutritionalInfo()
        {
            return nutritionalInfo;
        }
    }

    class Snack : Item
    {
        float weight;

        float GetWeight()
        {
            return weight;
        }
        
    }

    class Drink : Item
    {
        float capacity;

        float GetCapacity()
        {
            return capacity;
        }
    }












    class Animal
    {
        string name;
        int age;
        float happiness;

        public void PrintBaseValues()
        {
            Console.WriteLine(name + " "  + age + " " + happiness);
        }

        public int GetAge()
        {
            return age;
        }
    }

    class Dog : Animal
    {
        public int spotCount;
        public void Bark ()
        {
            Console.WriteLine("Woof");
        }

        public int DogGetAge()
        {
            return (GetAge());
        }
    }
}
