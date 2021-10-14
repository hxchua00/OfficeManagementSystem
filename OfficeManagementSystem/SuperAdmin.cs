using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementSystem
{
    class SuperAdmin : Admin
    {
        public static int SuperAdminID = 9999;

        public bool VerifyUser(int ID)
        {
            bool verified = false;
            if(UserList.Count != 0)
            {
                foreach (User u in UserList)
                {
                    if (u.UserID == ID)
                    {
                        verified = true;
                    }
                    else
                    {
                        Console.WriteLine("UserID not found! Enter valid UserID!");
                        Console.WriteLine();
                        verified = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no Users available right now!");
                Console.WriteLine();
            }
           
            return verified;
        }
        public void CreateUser()
        {
            Console.WriteLine("Enter User's Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter User's ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            User newUser = new User(name,ID,0);
            UserList.Add(newUser);
        }
        public void DeleteUser()
        {
            Console.WriteLine("Enter user ID to delete: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            for(int i = 0; i < UserList.Count; i++)
            {
                if (ID == UserList[i].UserID)
                {
                    UserList.RemoveAt(i);
                    Console.WriteLine($"User {ID} has been removed");
                    break;
                }
            }
        }
        public void CreateTask()
        {
            Console.WriteLine("Enter Task ID: ");
            int taskID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter task details here: ");
            string taskDetails = Console.ReadLine();

            if(TaskList.ContainsKey(taskID))
            {
                Console.WriteLine("Task ID already exists! Please enter another ID.");
            }
            else
            {
                TaskList[taskID] = taskDetails;
            }
        }

        public void DeleteTask()
        {
            Console.WriteLine("Enter Task ID to delete: ");
            int taskID = Convert.ToInt32(Console.ReadLine());

            if (TaskList.ContainsKey(taskID))
            {
                foreach (User user in UserList)
                {
                    if (user.task == taskID)
                    {
                        Console.WriteLine($"The task {taskID} has been removed from User {user.UserID}");
                        user.task = default;
                    }
                }

                if (AssignedTask.ContainsKey(taskID))
                {
                    AssignedTask.Remove(taskID);
                }

                TaskList.Remove(taskID);
            }
        }

        public void PrintAllUsers()
        {
            foreach(User u in UserList)
            {
                Console.WriteLine($"User's Name: {u.UserName}");
                Console.WriteLine($"User's ID: {u.UserID}");
                if(u.task == 0)
                {
                    Console.WriteLine("No task assigned to this user");
                }
                else
                {
                    Console.WriteLine($"Task Assigned: TaskID {u.task}");
                }
            }
        }

        public void PrintAllTasks()
        {
            foreach(KeyValuePair<int,string> task in TaskList)
            {
                Console.WriteLine($"TaskID: {task.Key} \nTask Details: {task.Value}");
            }
        }
    }
}
