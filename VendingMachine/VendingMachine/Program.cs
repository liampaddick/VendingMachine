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
                        Console.WriteLine("What would you like to add?");
                        Console.WriteLine("1 - Snack");
                        Console.WriteLine("2 - Drink");
                        Console.WriteLine("3 - Other (currently unuseable)");
                        int addChoice = int.Parse(Console.ReadLine());

                        addItem(vendingMachineInventory, addChoice);

                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                }

                Console.WriteLine("");

                for (int i = 0; i < vendingMachineInventory.Count(); i++)
                {
                    Console.WriteLine("Item Category: " + vendingMachineInventory[i].GetCategory());
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

        static Item checkItemIsInMachine(string itemNameToCheck, List<Item> currentInventory)
        {
            for (int i = 0; i < currentInventory.Count; i++)
            {
                if(currentInventory[i].GetName() == itemNameToCheck)
                {
                    return currentInventory[i]; // item is already in the list
                }
            }
            return null;
        }
        static List<Item> addItem(List<Item> currentInventory, int choice)
        {
            List<Item> listToReturn = currentInventory;

            if (choice == 1)
            {
                Console.WriteLine("Name of product to add: ");
                string nameToAdd = Console.ReadLine();
                Item nameToCheck = checkItemIsInMachine(nameToAdd, listToReturn);

                if (nameToCheck == null)
                {
                    Console.WriteLine("Category of product to add: ");
                    string categoryToAdd = Console.ReadLine();
                    Console.WriteLine("Price of product to add: ");
                    float priceToAdd = float.Parse(Console.ReadLine());
                    Console.WriteLine("Weight(g) of product to add: ");
                    int weightToAdd = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many are you putting in the machine to start with?");
                    int quantityToAdd = int.Parse(Console.ReadLine());
                    Snack itemToAdd = new Snack(nameToAdd, categoryToAdd, priceToAdd, weightToAdd, quantityToAdd);
                    listToReturn.Add(itemToAdd);
                    return listToReturn;
                }
                else
                {
                    Console.WriteLine("Item is already in the machine. Would you like to add more of it?");
                    Console.WriteLine("1 - yes");
                    Console.WriteLine("2 - no");
                    int tempChoice = int.Parse(Console.ReadLine());
                    if (tempChoice == 1)
                    {
                        Console.WriteLine("How many would you like to add? There are currently " + nameToCheck.GetQuantity() + " of this item in the machine.");
                        int quantityToAdd = int.Parse(Console.ReadLine());

                        for (int i = 0; i < listToReturn.Count(); i++)
                        {
                            if (listToReturn[i].GetName() == nameToCheck.GetName())
                            {
                                listToReturn[i].SetQuantity(listToReturn[i].GetQuantity() + quantityToAdd);
                            }
                        }
                        return listToReturn;
                    }
                    return listToReturn;
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Name of product to add: ");
                string nameToAdd = Console.ReadLine();
                Item nameToCheck = checkItemIsInMachine(nameToAdd, listToReturn);

                if (nameToCheck == null)
                {
                    Console.WriteLine("Category of product to add: ");
                    string categoryToAdd = Console.ReadLine();
                    Console.WriteLine("Price of product to add: ");
                    float priceToAdd = float.Parse(Console.ReadLine());
                    Console.WriteLine("Weight(g) of product to add: ");
                    int capacityToAdd = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many are you putting in the machine to start with?");
                    int quantityToAdd = int.Parse(Console.ReadLine());
                    Drink itemToAdd = new Drink(nameToAdd, categoryToAdd, priceToAdd, capacityToAdd, quantityToAdd);
                    listToReturn.Add(itemToAdd);
                    return listToReturn;
                }
                else
                {
                    Console.WriteLine("Item is already in the machine. Would you like to add more of it?");
                    Console.WriteLine("1 - yes");
                    Console.WriteLine("2 - no");
                    int tempChoice = int.Parse(Console.ReadLine());
                    if (tempChoice == 1)
                    {
                        Console.WriteLine("How many would you like to add? There are currently " + nameToCheck.GetQuantity() + " of this item in the machine.");
                        int quantityToAdd = int.Parse(Console.ReadLine());

                        for (int i = 0; i < listToReturn.Count(); i++)
                        {
                            if (listToReturn[i].GetName() == nameToCheck.GetName())
                            {
                                listToReturn[i].SetQuantity(listToReturn[i].GetQuantity() + quantityToAdd);
                            }
                        }
                        return listToReturn;
                    }
                    return listToReturn;
                }
            }
            else if (choice == 3)
            {
                // not in use currently
                return currentInventory;
            }
            else
            {
                //incompatible input
                return currentInventory;
            }
        }
    }

    abstract class Item // base class that food and drink will inherit from
    {
        static int itemID;
        string name;
        string category;
        float price;
        int quantity;

        static int itemCount;

        public Item(string pName, string pCategory, float pPrice, int startingQuantity)
        {
            itemID = itemCount;
            name = pName;
            category = pCategory;
            price = pPrice;
            quantity = startingQuantity;
            itemCount++;
        }

        public int GetItemID()
        {
            return itemID;
        }
        public string GetName()
        {
            return name;
        }
        public string GetCategory()
        {
            return category;
        }
        public float GetPrice()
        {
            return price;
        }
        public int GetQuantity()
        {
            return quantity;
        }
        public void SetQuantity(int quantityToSet)
        {
            quantity = quantityToSet;
        }


        public abstract float GetVolumeOrWeight();
    }

    class Snack : Item
    {
        float weight;

        public Snack(string pName, string pCategory, float pPrice, int pWeight, int startingQuantity) :base (pName, pCategory, pPrice, startingQuantity)
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

        public Drink(string pName, string pCategory, float pPrice, int pCapacity, int startingQuantity) :base (pName, pCategory, pPrice, startingQuantity)
        {
            capacity = pCapacity;
        }

        public override float GetVolumeOrWeight()
        {
            return capacity;
        }
    }
}
