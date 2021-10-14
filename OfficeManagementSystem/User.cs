using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManagementSystem
{
    class User : Admin
    {
        public string UserName;
        public int UserID;
        public int task;

        public User() { }
        public User(string UserName, int UserID,int task)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.task = task;
        }

        public void ViewTask(int ID)
        {
            foreach(KeyValuePair<int,string> task in TaskList)
            {
                if(task.Key == ID)
                {
                    Console.WriteLine($"Task assigned to {ID} is Task Number {task.Key}");
                    Console.WriteLine($"Task Details include: \n{task.Value}");
                    Console.WriteLine();
                }
            }
        }

        public void SubmitReport(int ID)
        {
            Console.WriteLine($"Reported submitted by {ID}");
            Console.WriteLine();
        }
    }
}
