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
            int choice = -1;

            Console.WriteLine("This will simulate a vending machine");

            while (vendorOn)
            {
                Console.WriteLine("Current Credit: " + credit);

                Console.WriteLine("What would you like to do? ");
                Console.WriteLine("1 - Add Credit");
                Console.WriteLine("2 - Get info on an item");
                Console.WriteLine("3 - Dispense an Item");
                Console.WriteLine("4 - Add new / Add more of an existing item");
                Console.WriteLine("5 - Remove item / All item");
                Console.WriteLine("6 - Shut down machine");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1: // add credit
                        Console.WriteLine("How much credit would you like to add?");
                        credit = addCredit(credit, float.Parse(Console.ReadLine()));
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        string nameToAdd = Console.ReadLine();
                        string categoryToAdd = Console.ReadLine();
                        float priceToAdd = float.Parse(Console.ReadLine());
                        Item itemToAdd = new Item(nameToAdd, categoryToAdd, priceToAdd);
                        vendingMachineInventory = addItem(itemToAdd, vendingMachineInventory);
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                }

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

        static List<Item> addItem(Item itemToAdd, List<Item> currentItemList)
        {
            List<Item> listToReturn = currentItemList;
            listToReturn.Add(itemToAdd);
            return listToReturn;
        }
    }

    abstract class Item // base class that food and drink will inherit from
    {
        static int itemID;
        string name;
        string category;
        float price;

        static int itemCount;

        public Item(string pName, string pCategory, float pPrice)
        {
            itemID = itemCount;
            name = pName;
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

        public Snack(string pName, string pCategory, float pPrice, int pWeight):base (pName, pCategory, pPrice)
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

        public Drink(string pName, string pCategory, float pPrice, int pCapacity):base (pName, pCategory, pPrice)
        {
            capacity = pCapacity;
        }

        public override float GetVolumeOrWeight()
        {
            return capacity;
        }
    }
}
