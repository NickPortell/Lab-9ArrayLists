
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Write a program that will recognize invalid inputs when the user requests information about students in a class
             *
             * What will the application do?
             * -Provide information about students in a class
             * -Prompt the user to ask about a particular student
             * -Give proper responses according to user-submitted information
             * -Ask if user would like to learn about another student
             * 
             * Build Specifications:
             * 1) Account for invalid user input with exceptions
             * 2) Try to incorporate IndexOutOfRangeException and FormatException
             * 
             * **Hint** Make it easy for the user -- tell them what information is available
             */

            int student;
            string firstChoice, secondChoice,name,place,food,color;
            bool repeat = true;

            while (repeat == true)
            {
                Console.WriteLine("Welcome to our C# class!");
                Console.WriteLine("Would you like to: \n1) Learn about a student \n2) Add new student info?");
                string answer = Console.ReadLine();

                if (answer == "2")
                {
                    EnteringNewInfo: //start of questions

                    Console.Write("What is their Name: ");
                    name = GetName();

                    Console.Write("What is their HomeTown: ");
                    place = GetHomeTown();

                    Console.Write("What is their Favorite Food: ");
                    food = GetFood();

                    Console.Write("What is their Favorite Color: ");
                    color = GetColor();

                    Console.WriteLine("Is this the correct information? ");
                    Console.WriteLine($"Student Name: {name}\nHomeTown: {place}\nFavoriteFood: {food}\nFavorite Color: {color}");
                    string isCorrect = Console.ReadLine();

                    if(isCorrect.ToLower() == "y")
                    {
                        Students().Add(name);
                        HomeTown().Add(place);
                        FavFood().Add(food);
                        FavColor().Add(color);
                    }
                    else
                    {
                        Console.WriteLine("Please re-enter the correct information.");
                        goto EnteringNewInfo;//restarts question process.
                    }


                }
                else if (answer == "1")
                {
                    Console.Write("Which student would you like to learn more about");

                    student = CheckStudent();


                    Console.WriteLine($"Student {student} is {Students()[student - 1]}");


                    Console.WriteLine($"What would you like to know about {Students()[student - 1]}?");
                    firstChoice = Console.ReadLine();

                    if (firstChoice.ToLower() != "hometown" && firstChoice.ToLower() != "favorite food")
                    {

                        firstChoice = CheckFirstChoice();

                    }

                    if (firstChoice.ToLower() == "hometown")
                    {
                        Console.Write($"{Students()[student - 1]} is from {HomeTown()[student - 1]}.");
                        Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                        secondChoice = Console.ReadLine();

                        if (secondChoice.ToLower() == "yes")
                        {
                            Console.WriteLine($"{Students()[student - 1]}'s favorite food is {FavFood()[student - 1]}.");
                        }
                    }
                    else if (firstChoice.ToLower() == "favorite food")
                    {
                        Console.Write($"{Students()[student - 1]}'s favorite food is {FavFood()[student - 1]}.");
                        Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                        secondChoice = Console.ReadLine();

                        if (secondChoice.ToLower() == "yes")
                        {
                            Console.WriteLine($"{Students()[student - 1]} is from {HomeTown()[student - 1]}.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Would you like to stop? (y/n): ");
                    string response1 = Console.ReadLine();

                    if(response1.ToLower() == "y")
                    {
                        repeat = false;
                    }
                }

                Console.WriteLine("Would you like to stop? (y/n): ");
                string response2 = Console.ReadLine();

                if(response2.ToLower() == "y")
                {
                    repeat = false;
                }

            }
                Console.WriteLine("Thanks!");
            


        }

        //Method Space

        public static int CheckStudent()
        {
            Console.WriteLine("\n(enter a number 1-20): ");
            int student;
            bool isNum = int.TryParse(Console.ReadLine(), out student);

            if (student < 1 || student > 20)
            {
                Console.WriteLine("That student does not exist. Please try again.");
                return CheckStudent();
            }
            else if (!isNum)
            {
                Console.WriteLine("That student does not exist. Please try again.");
                return CheckStudent();
            }
            return student;

        }

        public static string CheckFirstChoice()
        {
            Console.WriteLine($"Please try again. \n(enter \"hometown\" or \"favorite food\")");
            string choice = Console.ReadLine();

            if (choice.ToLower() != "hometown" && choice.ToLower() != "favorite food")
            {
                return CheckFirstChoice();
            }
            else if (choice.ToLower() == "hometown")
            {
                return "hometown";
            }
            else
            {
                return "favorite food";
            }
        }

        public static List<string> Students()
        {
            List<string> students = new List<string>{ "Pikachu", "Bulbasaur", "Charmander", "Squirtle", "Ivysaur", "Charmeleon", "Wartortle",
                "Venesaur", "Charizard", "Blastoise", "MewTwo", "Articuno", "Moltres", "Zapdos", "Slowbro", "Slowpoke",
                "Kabuto", "Kabutops", "Lugia", "Ho-oh" };

            return students;
        }

        public static List<string> HomeTown()
        {
            List<string> homeTowns = new List<string>{"Pewter City","Saffron City","Pallet Town",
                "Fuchsia City","Goldenrod City", "Cerulean City", "Vermillion City",
                "Lavender Town", "Celadon City", "Cinnabar Island", "Diglett's Cave",
                "Indigo Plateau", "Mt. Moon", "Safari Zone", "Seafoam Islands", "Victory Road",
                "Viridian Forest", "Cerulean Cave", "Rock Tunnel", "Pokemon Mansion"};

            return homeTowns;
        }

        public static List<string> FavFood()
        {
            List<string> favFood = new List<string>{"Sushi","Pizza","Pasta","Burritos","Bananas", "Ice Cream",
                "Fried Rice", "Pulled Pork", "Steak", "Hot Dogs", "Cheeseburger","Pineapple",
                "Cake", "Pie","Chicken", "Salad", "Cotton Candy", "Donuts", "Calzone", "Lasagna" };

            return favFood;
        }

        public static List<string> FavColor()
        {
            List<string> favColor = new List<string> {"Blue","Green","Yellow","Cyan","Magenta", "Indigo",
                "Pink", "Red", "Purple", "Navy Blue", "Lime Green", "Olive", "Brown",
                "Black", "Gray", "Teal", "Orange", "Beige", "Burgundy", "Maroon"};

            return favColor;
        }

        public static List<string> AddtoList(List<string> List, string info)
        {
            List.Add(info);

            return List;
        }
        public static string GetName()
        {
            string userInput;
            bool regexName, regexFullName;

            userInput = Console.ReadLine();
            regexFullName = Regex.IsMatch(userInput, @"(\b[A-Z][a-z]{1,30}\s[A-Z][a-z]{1,30}\b)");
            regexName = Regex.IsMatch(userInput, @"(\b[A-Z][a-z]{1,30}\b)");


            if (regexFullName)
            {
                return userInput;
            }
            else if (regexName)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("That is not a valid name, please try again.");
                return GetName();
            }
            
        }
        public static string GetHomeTown()
        {
            string userInput;
            bool regexName, regexFullName;

            userInput = Console.ReadLine();
            regexFullName = Regex.IsMatch(userInput, @"(\b[A-Z][a-z]{1,30}\s[A-Z][a-z]{1,30}\b)");
            regexName = Regex.IsMatch(userInput, @"(\b[A-Z][a-z]{1,30}\b)");


            if (regexFullName)
            {
                return userInput;
            }
            else if (regexName)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("That is not a valid Location, please try again.");
                return GetHomeTown();
            }

        }
        public static string GetFood()
        {
            string userInput;
            bool regexName, regexFullName;

            userInput = Console.ReadLine();
            regexFullName = Regex.IsMatch(userInput, @"(\b[A-Z][a-z]{1,30}\s[A-Z][a-z]{1,30}\b)");
            regexName = Regex.IsMatch(userInput, @"(\b[A-Z][a-z]{1,30}\b)");


            if (regexFullName)
            {
                return userInput;
            }
            else if (regexName)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("That is not a valid type of Food, please try again.");
                return GetFood();
            }

        }
        public static string GetColor()
        {
            string userInput;
            bool regexName, regexFullName;

            userInput = Console.ReadLine();
            regexFullName = Regex.IsMatch(userInput, @"(\b[A-Z][a-z]{1,30}\s[A-Z][a-z]{1,30}\b)");
            regexName = Regex.IsMatch(userInput, @"(\b[A-Z][a-z]{1,30}\b)");


            if (regexFullName)
            {
                return userInput;
            }
            else if (regexName)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("That is not a valid Color, please try again.");
                return GetColor();
            }

        }
    }
}