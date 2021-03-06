﻿using System;
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
                choice = GetChoice(credit);

                switch(choice)
                {
                    case 1: // add credit
                        Console.WriteLine("How much credit would you like to add?");
                        credit = addCredit(credit, float.Parse(Console.ReadLine()));
                        break;
                    case 2: // get nutritional info
                        Console.WriteLine("Enter the name of the item you would like to see nutritional info for: "); // will be changed to id once the bug has been fixed

                        string itemToGetInfo = Console.ReadLine();
                        for (int i = 0; i < vendingMachineInventory.Count(); i++)
                        {
                            if (vendingMachineInventory[i].GetName() == itemToGetInfo)
                            {
                                var nutritionalValues = vendingMachineInventory[i].GetNutritionalValues();
                                float[] tempNutritionArray = nutritionalValues.Item2;
                                Console.WriteLine("These values are " + nutritionalValues.Item1);
                                Console.WriteLine("Calories: " + tempNutritionArray[0]); // calories
                                Console.WriteLine("Fat: " + tempNutritionArray[1]); // fat
                                Console.WriteLine("Carbohydrates: " + tempNutritionArray[2]); //carbs
                                Console.WriteLine("Fibre: " + tempNutritionArray[3]); //fibre
                                Console.WriteLine("Protein " + tempNutritionArray[4]); //protein
                                Console.WriteLine("Salt " + tempNutritionArray[5]); //salt
                            }
                        }

                        break;
                    case 3: // dispense item
                        Console.WriteLine("Please enter the name of the item you wish to dispense: ");
                        string dispenseChoice = Console.ReadLine();
                        DecreaseQuantityOfItem(vendingMachineInventory, dispenseChoice); //this will use IDs once ID bug has been fixed.
                        credit = DecreaseCredit(credit, vendingMachineInventory, dispenseChoice);
                        break;
                    case 4: // add item to vending machine
                        Console.WriteLine("What would you like to add?");
                        Console.WriteLine("1 - Snack");
                        Console.WriteLine("2 - Drink");
                        int addChoice = int.Parse(Console.ReadLine());

                        addItem(vendingMachineInventory, addChoice);
                        break;
                    case 5: // remove an item / all items
                        Console.WriteLine("Would you like to remove a single item or all items?");
                        Console.WriteLine("1 - Single item");
                        Console.WriteLine("2 - Delete all");
                        int tempChoice = int.Parse(Console.ReadLine());
                        if (tempChoice == 1)
                        {
                            // remove single item
                            Console.WriteLine("Please enter the name of the item you wish to remove: "); // replace with id once id bug has been fixed
                            string itemToRemove = Console.ReadLine();
                            for (int i = 0; i < vendingMachineInventory.Count(); i++)
                            {
                                if (vendingMachineInventory[i].GetName() == itemToRemove)
                                {
                                    vendingMachineInventory.RemoveAt(i);
                                }
                            }

                        }
                        else if (tempChoice == 2)
                        {
                            //remove all items from inventory
                            vendingMachineInventory.Clear();
                            Console.WriteLine("All items have been removed.");
                        }
                        break;
                    case 6: // shut down the machine
                        break;
                }

                Console.WriteLine("");

                //debug to show items in vending machine
                for (int i = 0; i < vendingMachineInventory.Count(); i++)
                {
                    Console.WriteLine("Item ID: " + vendingMachineInventory[i].GetItemID() + " Item Name: " + vendingMachineInventory[i].GetName() + " Item quantity: " + vendingMachineInventory[i].GetQuantity());
                }
            }
        }

        static int GetChoice(float currentCredit)
        {
            Console.WriteLine("Current Credit: " + currentCredit);

            Console.WriteLine("What would you like to do? ");
            Console.WriteLine("1 - Add Credit");
            Console.WriteLine("2 - Get nutritional info on an item");
            Console.WriteLine("3 - Dispense an Item");
            Console.WriteLine("4 - Add new / Add more of an existing item");
            Console.WriteLine("5 - Remove item / All item");
            Console.WriteLine("6 - Shut down machine");
            return int.Parse(Console.ReadLine());
        }

        static List<Item>DecreaseQuantityOfItem(List<Item> currentInventory, string dispenseChoice) //this will use IDs once ID bug has been fixed.
        {
            List <Item> listToReturn = currentInventory;
            for (int i = 0; i < listToReturn.Count(); i++)
            {
                if (listToReturn[i].GetName() == dispenseChoice)
                {
                    if (listToReturn[i].GetQuantity() >= 1) // decrease by 1 if this is true
                    {
                        listToReturn[i].SetQuantity(listToReturn[i].GetQuantity() - 1);
                    }
                    else if (listToReturn[i].GetQuantity() == 0)
                    {
                        //remove item from vending machine
                        listToReturn.RemoveAt(i);
                    }
                }
            }
            return listToReturn;
        }
        static float DecreaseCredit(float currentCredit, List<Item> currentInventory, string dispenseChoice)
        {
            float tempCredit = currentCredit;
            for (int i = 0; i < currentInventory.Count(); i++)
            {
                if (currentInventory[i].GetName() == dispenseChoice)
                {
                    if (tempCredit >= currentInventory[i].GetPrice())
                    {
                        tempCredit = tempCredit - currentInventory[i].GetPrice();
                        return tempCredit;
                    }
                    else
                    {
                        Console.WriteLine("Not enough credit. Please pick another item.");
                        return tempCredit;
                    }
                }
            }
            Console.WriteLine("That choice doesn't match anything in the machine.");
            return tempCredit;
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
                    //info needed for dispensing and invnetory management
                    Console.WriteLine("Category of product to add: ");
                    string categoryToAdd = Console.ReadLine();

                    Console.WriteLine("Price of product to add: ");
                    float priceToAdd = float.Parse(Console.ReadLine());

                    Console.WriteLine("Weight(g) of product to add: ");
                    int weightToAdd = int.Parse(Console.ReadLine());

                    Console.WriteLine("How many are you putting in the machine to start with?");
                    int quantityToAdd = int.Parse(Console.ReadLine());


                    //info needed for nutritional information
                    string perString;
                    float calories, fat, carbohydrates, fibre, protein, salt;
                    Console.WriteLine("Per portion statement: ");
                    perString = Console.ReadLine();

                    Console.WriteLine("How many calories are in this item? ");
                    calories = float.Parse(Console.ReadLine());

                    Console.WriteLine("How much fat is in the Item? ");
                    fat = float.Parse(Console.ReadLine());

                    Console.WriteLine("How many carbohydrates are there in this item?");
                    carbohydrates = float.Parse(Console.ReadLine());

                    Console.WriteLine("how much fibre is in this item? ");
                    fibre = float.Parse(Console.ReadLine());

                    Console.WriteLine("How much protein is in this item? ");
                    protein = float.Parse(Console.ReadLine());

                    Console.WriteLine("finally, how much salt is in the item? ");
                    salt = float.Parse(Console.ReadLine());

                    Snack itemToAdd = new Snack(nameToAdd, categoryToAdd, priceToAdd, weightToAdd, quantityToAdd, perString, calories, fat, carbohydrates, fibre, protein, salt);
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
                    //info needed for dispensing and inventory management
                    Console.WriteLine("Category of product to add: ");
                    string categoryToAdd = Console.ReadLine();
                    Console.WriteLine("Price of product to add: ");
                    float priceToAdd = float.Parse(Console.ReadLine());
                    Console.WriteLine("capacity(ml) of product to add: ");
                    int capacityToAdd = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many are you putting in the machine to start with?");
                    int quantityToAdd = int.Parse(Console.ReadLine());

                    //info needed for nutritional info
                    string perString;
                    float calories, fat, carbohydrates, fibre, protein, salt;
                    Console.WriteLine("Per portion statement: ");
                    perString = Console.ReadLine();

                    Console.WriteLine("How many calories are in this item? ");
                    calories = float.Parse(Console.ReadLine());

                    Console.WriteLine("How much fat is in the Item? ");
                    fat = float.Parse(Console.ReadLine());

                    Console.WriteLine("How many carbohydrates are there in this item?");
                    carbohydrates = float.Parse(Console.ReadLine());

                    Console.WriteLine("how much fibre is in this item? ");
                    fibre = float.Parse(Console.ReadLine());

                    Console.WriteLine("How much protein is in this item? ");
                    protein = float.Parse(Console.ReadLine());

                    Console.WriteLine("finally, how much salt is in the item? ");
                    salt = float.Parse(Console.ReadLine());

                    Drink itemToAdd = new Drink(nameToAdd, categoryToAdd, priceToAdd, capacityToAdd, quantityToAdd, perString, calories, fat, carbohydrates, fibre, protein, salt);
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

        //default values are for testing
        string perString;
        float calories;
        float fat;
        float carbohydrates;
        float fibre;
        float protein;
        float salt;

        static int itemCount;

        public Item(string pName, string pCategory, float pPrice, int startingQuantity, string pPerString, float pCalories, float pFat, float pCarbohydrates, float pFibre, float pProtein, float pSalt)
        {
            //dispensing and inventory management info
            itemID = itemCount;
            name = pName;
            category = pCategory;
            price = pPrice;
            quantity = startingQuantity;

            //nutritional info
            perString = pPerString;
            calories = pCalories;
            fat = pFat;
            carbohydrates = pCarbohydrates;
            fibre = pFibre;
            protein = pProtein;
            salt = pSalt;

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

        public void SetNutritionalValues(string pPerString, float pCalories, float pFat, float pCarbohydrates, float pFibre, float pProtein, float pSalt)
        {
            perString = pPerString;
            calories = pCalories;
            fat = pFat;
            carbohydrates = pCarbohydrates;
            fibre = pFibre;
            protein = pProtein;
            salt = pSalt; 
        }
        public Tuple<string, float[]> GetNutritionalValues()
        {
            float[] nutritionArray = new float[6];
            nutritionArray[0] = calories;
            nutritionArray[1] = fat;
            nutritionArray[2] = carbohydrates;
            nutritionArray[3] = fibre;
            nutritionArray[4] = protein;
            nutritionArray[5] = salt;
            var returnTuple = Tuple.Create(perString, nutritionArray);
            return returnTuple;
        }

        public abstract float GetVolumeOrWeight();
    }

    class Snack : Item
    {
        float weight;

        public Snack(string pName, string pCategory, float pPrice, int pWeight, int startingQuantity, string pPerString, float pCalories, float pFat, float pCarbohydrates, float pFibre, float pProtein, float pSalt) :base (pName, pCategory, pPrice, startingQuantity, pPerString, pCalories, pFat, pCarbohydrates, pFibre, pProtein, pSalt)
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

        public Drink(string pName, string pCategory, float pPrice, int pCapacity, int startingQuantity, string pPerString, float pCalories, float pFat, float pCarbohydrates, float pFibre, float pProtein, float pSalt) :base (pName, pCategory, pPrice, startingQuantity, pPerString, pCalories, pFat, pCarbohydrates, pFibre, pProtein, pSalt)
        {
            capacity = pCapacity;
        }

        public override float GetVolumeOrWeight()
        {
            return capacity;
        }
    }
}
