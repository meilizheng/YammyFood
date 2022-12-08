using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//Meili Zheng;
//11/30/2022;
//Final Order Food Menu;

//I created this code for custmer to order food/drink and calculate the price;

namespace Final_Food_Menu
{
    internal class Program
    {
        //clarify the global variable;
        static double totaltax = 1.101;
        //created the string array;
        static string[] foodname =
            {
                "Hamburger",
                "Hot dog",
                "Pizza",
                "Seafood",
                "Kebab",
                "Tuna Steak",
                "Pancake",
                "Fried Fish",
                "Noodles",
                "Fried Chicken",
            };
        static string[] drinkname =
        {
                "Beer",
                "Hard Soda",
                "Coffee",
                "Liquor",
                "Water",
                "Soft Drinks",
                "Beer Cocktail",
                "Orange Juice",
                "Apple Juice",
                "Green Tea",
            };
        //created the double food and drink price array;
        static double[] foodprice = { 5.60, 3.50, 3.0, 8.50, 6.50, 12.50, 2.50, 3.50, 5.50, 8.50};
        static double[] dringprice = { 4.50, 2.50, 5.00, 3.00, 0.00, 2.50, 4.50, 2.50, 2.50, 3.00 };
        //clarify the global double variable;
        static double orderfoodprice = 0;
        static double orderdrinkprice = 0;
        static double AddFoodPrice = 0;
        static double AddDrinkPrice = 0;
        
        static void Main(string[] args)
        {
            try { //use try catch to control the user input type;
            staroftheloop:;
            //Display the food/drink order menu; give user choice;
            Console.WriteLine("Please enter your choice:\n");
            Console.WriteLine("1. Display Menu.\n");
            Console.WriteLine("2. Order food and drink and Calculate the bill.\n");
            Console.WriteLine("3. Adding food or drink.\n");
            Console.WriteLine("4. Calculate the price.\n");
            string userinput = Console.ReadLine();
            //according user's input use switch to run different code;
            switch (userinput)
            {
                case "1":
                //case 1: call the method, display the food and drink menu;
                    DisplayMenu();            
                    //give user choice to continue or exit the code;
                    Console.WriteLine("Continue or not (Y or N)\n");
                    string Userchoose = Console.ReadLine();
                    if (Userchoose == "Y" || Userchoose == "y")
                    {
                        goto staroftheloop;
                    }
                    else if (Userchoose == "N" || Userchoose == "n")
                    {
                        goto endoftheloop;
                    }
                    break;
                    //case 2: call the method let user order the food/drink, display the food/drink name and the price;
                    case "2":
                    Console.WriteLine("What food do you want?\n");
                    string FoodName = Console.ReadLine();
                    Console.WriteLine("What drink do you want?\n");
                    string DrinkName = Console.ReadLine();
                    Console.WriteLine("------------------------------>>");
                    CustomOrder(FoodName, DrinkName);
                    Console.WriteLine("------------------------------>>");
                    double foodprice = FoodPrice(FoodName);
                    orderfoodprice = foodprice;
                    double drinkprice = PriceOfDrink(DrinkName);
                    orderdrinkprice = drinkprice;        
                    //give user choice to continue or exit the code;
                    Console.WriteLine("Continue or not (Y or N)\n");
                    string userchoose = Console.ReadLine();
                    if (userchoose == "Y" || userchoose == "y")
                    {
                        goto staroftheloop;
                    }
                    else if (userchoose == "N" || userchoose == "n")
                    {
                        goto endoftheloop;
                    }
                    break;
                    //case 3: call the method to add more food or drink, display the added food/drink name and the price;
                    case "3": 
                   Console.WriteLine("Please add the food:\n");
                   string addfoodname = Console.ReadLine();
                   Console.WriteLine("Please add the drink:\n");
                   string adddrinkname = Console.ReadLine();
                   Console.WriteLine("------------------------------>>");
                   CustomOrder(addfoodname, adddrinkname);
                   Console.WriteLine("------------------------------>>");
                   double addfoodprice = FoodPrice(addfoodname);
                   AddFoodPrice = addfoodprice;
                   double adddrinkprice = PriceOfDrink(adddrinkname);
                   AddDrinkPrice = adddrinkprice;
                   //give user choice to continue or exit the code;
                        Console.WriteLine("Continue or not (Y or N)\n");
                        string UserChoose = Console.ReadLine();
                        if (UserChoose == "Y" || UserChoose == "y")
                        {
                            goto staroftheloop;
                        }
                        else if (UserChoose == "N" || UserChoose == "n")
                        {
                            goto endoftheloop;
                        }

                        break;
                    case "4":
                        //case 4:calculate the total price;
                        Console.WriteLine("Calculate the price\n");
                        Console.WriteLine("Please the percentage of tips(0.10, 0.15, 0.18, 0.20): \n");
                        double tips = double.Parse(Console.ReadLine());
                        double finalprice = CalculateFinalPrice(orderfoodprice, orderdrinkprice, AddFoodPrice, AddDrinkPrice, tips, totaltax);
                        Console.WriteLine($"your total is $ {finalprice}\n");
                        //give user choice to continue or exit the code;
                        Console.WriteLine("Continue or not (Y or N)\n");
                        string UChoose = Console.ReadLine();
                        if (UChoose == "Y" || UChoose == "y")
                        {
                            goto staroftheloop;
                        }
                        else if (UChoose == "N" || UChoose == "n")
                        {
                            goto endoftheloop;
                        }
                        break;


                    default:
                    Console.WriteLine("Invaid information.\n");
                     Console.ReadKey();
                    break;
            }
            endoftheloop:;
            }
            catch
            {
                Console.WriteLine("invaid information.");
                Console.ReadKey();
            }        
        }
        
        public static void DisplayMenu()
        {
            for (int i = 0; i < foodname.Length; i++) //use for loop to display the menu;
            {
                Console.Write($"{foodname[i]}\t{foodprice[i]}\t");
                Console.WriteLine($"{drinkname[i]}\t{dringprice[i]}\n");
            }
        }
        public static void CustomOrder(string FoodName, string DrinkName)  
        {
            for(int i = 0; i < foodname.Length; i++)// use for loop to find user entered food/drink;
            {
                if (FoodName == foodname[i])//if found the food name in the food array, display thr result;
                {
                    Console.WriteLine($"you ordered {foodname[i]} for food.\n");                    
                }           
            
                if (DrinkName == drinkname[i])//if found thr drink name in the drink array, display the result;
                {
                    Console.WriteLine($"you ordered {drinkname[i]} for drink.\n");                    
                }
            }           
        }
        public static double FoodPrice(string Orderedfood)
        {
        jumptohere:;
            for (int i = 0; i < foodprice.Length; i++)//use for loop to display the food price.
            {
                if (Orderedfood == foodname[i])//if found display the result;
                {
                    Console.WriteLine($"The price of {foodname[i]} is {foodprice[i]} dollars.\n");
                    //return food price;
                    return foodprice[i];                    
                }             
            }
            Console.WriteLine("can't find the name of food.\n");//if didn't find give user choice to re-enter the food name;
            Console.WriteLine("Do you want re-enter the food name?(Y/N)\n");
            string userchoice = Console.ReadLine();
            //give user choice to continue or exit the loop;
            if (userchoice == "y" || userchoice == "Y")
            {
                Console.WriteLine("Please re-enter the food name:\n");
                string reEnterName = Console.ReadLine();
                Orderedfood = reEnterName;
                goto jumptohere;
            }    
            //if didn't find return 0;
            return 0.00;
        }

        public static double PriceOfDrink(string ordereddrink)
        {
        gobacktohere:;
            for (int i = 0; i < dringprice.Length; i++)//use for loop to display the drink price that user entered;
            {
                if (ordereddrink == drinkname[i])//if found display thr result;
                {
                    Console.WriteLine($"The price of {drinkname[i]} is {dringprice[i]} dollars.\n");
                    //return drink price;
                    return dringprice[i];
                    
                }               
            }
            Console.WriteLine("Do you want re-enter the food name?(Y/N)\n");//if didn't find give user choice to re-enter the drink name;
            string userchoice = Console.ReadLine();
            if (userchoice == "y" || userchoice == "Y")
            {
                Console.WriteLine("Please re-enter the food name:\n");
                string reEnterDrinkName = Console.ReadLine();
                ordereddrink = reEnterDrinkName;
                goto gobacktohere;
            }
            Console.WriteLine("can't find the name of drink.\n");
            // if didn't find return 0;
            return 0.00;
        }
        //the method for total food and drink price;
        public static double CalculateFinalPrice(double foodprice, double drinkprice, double addfoodprice, double adddrinkprice, double tips, double tax)
        {
            double finalprice = Math.Round((foodprice + drinkprice + addfoodprice + adddrinkprice) * (tips + 1) * tax, 2);
            //return finalprice;
            return finalprice;
        }       
    }
}
