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
            do
            {
                Console.Clear();
                Console.Write("Enter Username: ");
                usn = Console.ReadLine();

                if (CheckUser(usn) > 0)
                {
                    Console.WriteLine("Username already taken!");
                    Console.ReadLine();
                }
            } while (CheckUser(usn) > 0);

            do 
            {
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
                    RegisterUser(usn, pw);
                    Console.WriteLine("Registered Successfully!");
                }
                Console.ReadLine();
            } while (pw!=cpw);
        }

        public static string Login()
        {
            int found;
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
            return usn;
        }

        public static void ChangePassword()
        {
            Console.Write("Enter New Password: ");
            pw = Console.ReadLine();
            Console.Write("Confirm New Password: ");
            cpw = Console.ReadLine();

            if (pw != cpw)
            {
                Console.WriteLine("Password does not match!");
            }
            else
            {
                UpdateUser(usn, pw);
                Console.WriteLine("Password has been updated!");
            }
        }

        public static void DeleteAccount(string getUSN)
        {
            if (AnswerYN("Delete User Account? (Y/N): ") == true)
            {
                DeleteUser(getUSN);
                Console.WriteLine("User has been deleted!");
            }
        }

        public static void MainMenu()
        {
            string[] menu = { "Register User", "Login User"};
            int choice;
            do
            {
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine("[{0}] - {1}", i+1, menu[i]);
                }

                Console.Write("Enter the number of action: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Register();
                        break;

                    case 2:
                        usn = Login();
                        UserMenu(usn);
                        break;

                    default:
                        Console.WriteLine("Choose a valid option.");
                        break;
                }
                Console.ReadLine();
            } while (choice < menu.Length);
        }

        public static void UserMenu(string getUSN)
        {
            string[] menu = { "Change Password", "Delete Account" };
            int choice;

            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine("[{0}] - {1}", i + 1, menu[i]);
            }

            Console.Write("Enter the number of action: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ChangePassword();
                    break;

                case 2:
                    DeleteAccount(getUSN);
                    break;

                default:
                    Console.WriteLine("Choose a valid option.");
                    break;
            }
        }

        public static bool AnswerYN(string msg)
        {
            string answer;
            do
            {
                Console.Write(msg);
                answer = Console.ReadLine();
                if (!answer.Equals("Y", StringComparison.OrdinalIgnoreCase) && !answer.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Answer only between Y or N.");
                }
            } while (!answer.Equals("Y", StringComparison.OrdinalIgnoreCase) && !answer.Equals("N", StringComparison.OrdinalIgnoreCase));
            return answer.Equals("Y", StringComparison.OrdinalIgnoreCase);
        }

        static void Main(string[] args)
        {
            try
            {
                do
                {
                    MainMenu();
                } while (AnswerYN("Return to Main Menu? (Y/N): "));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}