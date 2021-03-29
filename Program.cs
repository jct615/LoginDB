using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LoginDB.User;

namespace LoginDB
{
    static class Program
    {
        static string usn, pw, cpw;

        public static void Register()
        {
            Console.Clear();
            Console.Write("Enter Username: ");
            usn = Console.ReadLine();

            Console.Write("Enter Password: ");
            pw = Console.ReadLine();

            Console.Write("Confirm Password: ");
            cpw = Console.ReadLine();

            if (pw != cpw)
            {
                Console.WriteLine("Password does not match!");
            }
            else 
            {
                if (CheckUser(usn) > 0)
                {
                    Console.WriteLine("Username already taken!");
                }
                else 
                {
                    RegisterUser(usn, pw);
                    Console.WriteLine("Registered Successfully!");
                }
            }
            Console.ReadLine();
        }

        public static void Login()
        {
            int found;
            try 
            {
                do 
                {
                    Console.Clear();
                    Console.Write("Enter Username: ");
                    usn = Console.ReadLine();

                    Console.Write("Enter Password: ");
                    pw = Console.ReadLine();
                    found = LoginUser(usn, pw);
                    if (found == 1)
                    {
                        Console.WriteLine("Welcome!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Username or Password!");
                    }
                    Console.ReadLine();
                } while (found<1);
            }
            catch 
            {
                Console.WriteLine("Unexpected Error!");
            }
        }

        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("[1] Register User");
            Console.WriteLine("[2] Login User");
            Console.Write("Enter the number of your choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Register();
                    break;

                case 2:
                    Login();
                    break;

                default:
                    Console.WriteLine("Choose a valid option.");
                    break;
            }
        }
    }
}