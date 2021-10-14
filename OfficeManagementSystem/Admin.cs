using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementSystem
{
    class Admin
    {
        protected List<User> UserList = new List<User>();
        protected Dictionary<int, string> TaskList = new Dictionary<int, string>();
        protected Dictionary<int, bool> AssignedTask = new Dictionary<int, bool>();

        public static int AdminID = 101;

        public void AssignTask()
        {
            Console.WriteLine("Enter UserID to assign task to: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter TaskID to assign: ");
            int taskID = Convert.ToInt32(Console.ReadLine());

            if (TaskList.ContainsKey(taskID))
            {
                if (AssignedTask.ContainsKey(taskID))
                {
                    Console.WriteLine("Task already assigned to another user. Please assign a new task.");
                    Console.WriteLine();
                }
                else
                {
                    if (UserList != null)
                    {
                        foreach (User u in UserList)
                        {
                            if (u.UserID == userID)
                            {
                                if (u.task == 0)
                                {
                                    u.task = taskID;
                                    foreach(KeyValuePair<int,string> task in TaskList)
                                    {
                                        if(task.Key == taskID)
                                        {
                                            Console.WriteLine($"The following task has been assigned to UserID: {userID}");
                                            Console.WriteLine();
                                            Console.WriteLine($"TaskID : {taskID}");
                                            Console.WriteLine($"TaskDetails:\n{task.Value}");
                                            Console.WriteLine();

                                            AssignedTask[taskID] = true;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"The User ID {userID} already has a task assigned.");
                                    Console.WriteLine("Please assign this task to other Users.");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No such task found, please go through the super admin to know the task list");
                Console.WriteLine();
            }
        }

        public void ViewAvalaibleTask()
        {
            foreach(KeyValuePair<int,string> task in TaskList)
            {
                Console.WriteLine($"Task ID: {task.Key} \nTask Details: {task.Value}");
                Console.WriteLine();
            }
        }
    }
}
