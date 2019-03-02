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

            List<Item> vendingMachineInventory = new List<Item>();

            Console.WriteLine("This will simulate a vending machine");

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

        static float addCredit(float currentCredit, float creditToAdd)
        {
            currentCredit = currentCredit + creditToAdd;
            return currentCredit;
        }

        static float subtractCredit(float currentCredit, float creditToSubtract)
        {
            currentCredit = currentCredit - creditToSubtract;
            return currentCredit;
        }
    }

    abstract class Item // base class that food and drink will inherit from
    {
        static int itemID;
        string category;
        float price;

        static int itemCount;

        public Item(string pCategory, float pPrice)
        {
            itemID = itemCount;
            category = pCategory;
            price = pPrice;
            itemCount++;
        }

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

        public abstract float GetVolumeOrWeight();
    }

    class Snack : Item
    {
        float weight;

        public Snack(string pCategory, float pPrice, int pWeight):base (pCategory, pPrice)
        {
            weight = pWeight;
        }

        public float GetWeight()
        {
            return weight;
        }

        public override float GetVolumeOrWeight()
        {
            return weight;
        }

    }
    class Drink : Item
    {
        float capacity;

        public Drink(string pCategory, float pPrice, int pCapacity):base (pCategory, pPrice)
        {
            capacity = pCapacity;
        }

        public override float GetVolumeOrWeight()
        {
            return capacity;
        }
    }
}
