
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
            bool repeat = true, cont = true;
            List<string> students = Students(), hometown = HomeTown(), favfood = FavFood(), favcolor = FavColor();


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

                    Console.WriteLine("Is this the correct information? (y/n): ");
                    Console.WriteLine($"Student Name: {name}\nHomeTown: {place}\nFavorite Food: {food}\nFavorite Color: {color}");
                    string isCorrect = Console.ReadLine();

                    if(isCorrect.ToLower() == "y")
                    {
                        AddtoList(students, name);
                        AddtoList(hometown, place);
                        AddtoList(favfood, food);
                        AddtoList(favcolor, color);
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

                    student = CheckStudent(students);


                    Console.WriteLine($"Student {student} is {students[student - 1]}");


                    Console.WriteLine($"What would you like to know about {students[student - 1]}?");
                    firstChoice = Console.ReadLine();

                    if (firstChoice.ToLower() != "hometown" && firstChoice.ToLower() != "favorite food" && firstChoice.ToLower() != "favorite color" )
                    {

                        firstChoice = CheckFirstChoice();

                    }

                    while(cont == true)
                    {
                        if (firstChoice.ToLower() == "hometown")
                        {
                            Console.Write($"{students[student - 1]} is from {hometown[student - 1]}.");
                            Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                            secondChoice = Console.ReadLine();

                            if (secondChoice.ToLower() != "yes")
                            {
                                cont = false;
                            }
                            else
                            {
                                firstChoice = ChoseHomeTown();

                                if (firstChoice.ToLower() == "favorite food")
                                {
                                    Console.Write($"{students[student - 1]}'s favorite food is {favfood[student - 1]}.");
                                    Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                                    secondChoice = Console.ReadLine();

                                    if (secondChoice.ToLower() == "yes")
                                    {
                                        Console.WriteLine($"{students[student - 1]}'s favorite color is {favcolor[student - 1]}.");
                                        cont = false;
                                    }
                                }
                                else if (firstChoice.ToLower() == "favorite color")
                                {
                                    Console.Write($"{students[student - 1]}'s favorite color is {favcolor[student - 1]}.");
                                    Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                                    secondChoice = Console.ReadLine();

                                    if (secondChoice.ToLower() == "yes")
                                    {
                                        Console.WriteLine($"{students[student - 1]}'s favorite food is {favfood[student - 1]}.");
                                        cont = false;
                                    }
                                }
                            }

                        }
                        else if (firstChoice.ToLower() == "favorite food")
                        {
                            Console.Write($"{students[student - 1]}'s favorite food is {favfood[student - 1]}.");
                            Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                            secondChoice = Console.ReadLine();

                            if (secondChoice.ToLower() != "yes")
                            {
                                cont = false;
                            }
                            else
                            {
                                firstChoice = ChoseFavoriteFood();

                                if (firstChoice.ToLower() == "hometown")
                                {
                                    Console.Write($"{students[student - 1]} is from {hometown[student - 1]}.");
                                    Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                                    secondChoice = Console.ReadLine();

                                    if (secondChoice.ToLower() == "yes")
                                    {
                                        Console.WriteLine($"{students[student - 1]}'s favorite color is {favcolor[student - 1]}.");
                                        cont = false;
                                    }
                                }
                                else if (firstChoice.ToLower() == "favorite color")
                                {
                                    Console.Write($"{students[student - 1]}'s favorite color is {favcolor[student - 1]}.");
                                    Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                                    secondChoice = Console.ReadLine();

                                    if (secondChoice.ToLower() == "yes")
                                    {
                                        Console.WriteLine($"{students[student - 1]} is from {hometown[student - 1]}.");
                                        cont = false;
                                    }
                                }
                            }
                        }
                        else if (firstChoice.ToLower() == "favorite color")
                        {

                            Console.Write($"{students[student - 1]}'s favorite color is {favcolor[student - 1]}.");
                            Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                            secondChoice = Console.ReadLine();

                            if (secondChoice.ToLower() != "yes")
                            {
                                cont = false;
                            }
                            else
                            {
                                firstChoice = ChoseFavoriteColor();

                                if (firstChoice.ToLower() == "hometown")
                                {
                                    Console.Write($"{students[student - 1]} is from {hometown[student - 1]}.");
                                    Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                                    secondChoice = Console.ReadLine();

                                    if (secondChoice.ToLower() == "yes")
                                    {
                                        Console.WriteLine($"{students[student - 1]}'s favorite food is {favfood[student - 1]}.");
                                        cont = false;
                                    }
                                }
                                else if(firstChoice.ToLower() == "favorite food")
                                {
                                    Console.Write($"{students[student - 1]}'s favorite food is {favfood[student - 1]}.");
                                    Console.WriteLine(" \nWould you like to know more? (enter \"yes\" or \"no\")");
                                    secondChoice = Console.ReadLine();

                                    if (secondChoice.ToLower() == "yes")
                                    {
                                        Console.WriteLine($"{students[student - 1]} is from {hometown[student - 1]}.");
                                        cont = false;
                                    }
                                }
                            }

                        }
                        //Outer edge of While loop (below)
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

        public static int CheckStudent(List<string> students)
        {
            Console.WriteLine($"\n(enter a number 1-{students.Count}): ");
            int student;
            bool isNum = int.TryParse(Console.ReadLine(), out student);

            if (student < 1 || student > students.Count)
            {
                Console.WriteLine("That student does not exist. Please try again.");
                return CheckStudent(students);
            }
            else if (!isNum)
            {
                Console.WriteLine("That student does not exist. Please try again.");
                return CheckStudent(students);
            }
            return student;

        }

        public static string CheckFirstChoice()
        {
            Console.WriteLine($"Please try again. \n(enter \"hometown\" or \"favorite food\" or \"favorite color\")");
            string choice = Console.ReadLine().ToLower();
            

            if (choice != "hometown" && choice != "favorite food" && choice != "favorite color")
            {
                return CheckFirstChoice();
            }
            else if (choice == "hometown")
            {
                return "hometown";
            }
            else if (choice == "favorite food")
            {
                return "favorite food";
            }
            else
            {
                return "favorite color";
            }
        }

        public static string ChoseHomeTown()
        {
            Console.WriteLine($"\n(enter \"favorite color\" or \"favorite food\")");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "favorite color":
                    {
                        return "favorite color";
                    }
                case "favorite food":
                    {
                        return "favorite food";
                    }
                default:
                    return "(Please try again) " + ChoseFavoriteColor();
            }
        }

        public static string ChoseFavoriteFood()
        {
            Console.WriteLine($"\n(enter \"hometown\" or \"favorite color\")");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "hometown":
                    {
                        return "hometown";
                    }
                case "favorite color":
                    {
                        return "favorite color";
                    }
                default:
                    return "(Please try again) " + ChoseFavoriteColor();
            }
        }

        public static string ChoseFavoriteColor()
        {
            Console.WriteLine($"\n(enter \"hometown\" or \"favorite food\")");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "hometown":
                    {
                        return "hometown";
                    }
                case "favorite food":
                    {
                        return "favorite food";
                    }
                default:
                    return "(Please try again) " + ChoseFavoriteColor();
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

        public static void AddtoList(List<string> List, string info)
        {
            List.Add(info);

            //return List;
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