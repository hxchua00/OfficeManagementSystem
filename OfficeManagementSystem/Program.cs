using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool enter = true;
            while (enter)
            {
                Console.WriteLine("Are you a User or Staff?");
                Console.WriteLine("1) User");
                Console.WriteLine("2) Staff");
                Console.WriteLine("3) Exit");
                Console.WriteLine();
                int login = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (login)
                {
                    case 1:
                        Console.WriteLine("Please Enter your User ID: ");
                        int userID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        SuperAdmin SA = new SuperAdmin();
                        if (SA.VerifyUser(userID))
                        {
                            UserMenu(userID);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Staff ID here: ");
                        int staffID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        if (staffID == Admin.AdminID)
                        {
                            AdminMenu();
                        }
                        else if (staffID == SuperAdmin.SuperAdminID)
                        {
                            SuperAdminMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid staff ID! Are you an intruder?");
                            Console.WriteLine();
                        }
                        break;
                    default:
                        Console.WriteLine("What are you even here for? Go away before we call security!");
                        Console.WriteLine();
                        break;
                }
            }            
        }

        static void UserMenu(int ID)
        {
            User user = new User();
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1) View Task");
                Console.WriteLine("2) Submit Report");
                Console.WriteLine();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        user.ViewTask(ID);
                        break;
                    case 2:
                        user.SubmitReport(ID);
                        break;
                    case 3:
                        Console.WriteLine("Have you finished your task? Good bye!");
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Permission not granted! Please contact admin or superadmin for other features");
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void AdminMenu()
        {
            Console.WriteLine("Welcome back Admin!");
            Console.WriteLine();

            Admin admin = new Admin();

            bool cont = true;
            while (cont)
            {
                Console.WriteLine("Admin, what will you do today?");
                Console.WriteLine("1) View Available Tasks");
                Console.WriteLine("2) Assign tasks");
                Console.WriteLine("3) Take a break");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        admin.ViewAvalaibleTask();
                        break;
                    case 2:
                        admin.AssignTask();
                        break;
                    case 3:
                        Console.WriteLine("Good job today! See you again!");
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Stop slacking off! Do your work properly!");
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void SuperAdminMenu()
        {
            Console.WriteLine("Welcome back Super Admin!  Great to work with you again!");
            Console.WriteLine();

            SuperAdmin SA = new SuperAdmin();
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("Super Admin, what do you wish to do today?");
                Console.WriteLine("1) Create Users");
                Console.WriteLine("2) Create Tasks");
                Console.WriteLine("3) Assign Tasks");
                Console.WriteLine("4) Print all User Information");
                Console.WriteLine("5) Print all tasks avalaible");
                Console.WriteLine("6) Delete User");
                Console.WriteLine("7) Delete Task");
                Console.WriteLine("8) Take a break");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        SA.CreateUser();
                        break;
                    case 2:
                        SA.CreateTask();
                        break;
                    case 3:
                        SA.AssignTask();
                        break;
                    case 4:
                        SA.PrintAllUsers();
                        break;
                    case 5:
                        SA.PrintAllTasks();
                        break;
                    case 6:
                        SA.DeleteUser();
                        break;
                    case 7:
                        SA.DeleteTask();
                        break;
                    case 8:
                        Console.WriteLine("Understood. Hope your break goes well!");
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Stop joking around Super Admin! Be more serious!");
                        break;
                }
            }
           
           
        }
    }
}
