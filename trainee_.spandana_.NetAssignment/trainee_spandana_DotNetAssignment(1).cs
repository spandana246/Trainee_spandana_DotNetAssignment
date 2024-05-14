using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace projects
{
    class Program
    {
        static string[] tasks = new string[100];
        static int C = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nTask List Application\n");
                Console.WriteLine("1. Create a task");
                Console.WriteLine("2. Read tasks");
                Console.WriteLine("3. Update a task");
                Console.WriteLine("4. Delete a task");
                Console.WriteLine("5. Exit\n");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateTask();
                        break;
                    case "2":
                        ReadTasks();
                        break;
                    case "3":
                        UpdateTask();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
        static void CreateTask()
        {
            Console.Write("Enter task description: ");
            string d = Console.ReadLine();
            tasks[C++] = d;
            Console.WriteLine("Task created successfully.");
        }
        static void ReadTasks()
        {
            if (C == 0)
                Console.WriteLine("No tasks found.");
            else
            {
                Console.WriteLine("Task List:");
                for (int i = 0; i < C; i++)
                {
                    Console.WriteLine("Task " + (i + 1) + " : " + tasks[i]);
                }
            }
        }
        static void UpdateTask()
        {
            if (C == 0)
            {
                Console.WriteLine("No tasks found to update.");
            }
            Console.Write("Enter the index of the task to update: ");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index > 0 && index <= C)
            {
                Console.Write("Enter new task description: ");
                string n = Console.ReadLine();
                tasks[index - 1] = n;
                Console.WriteLine("Task updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
        static void DeleteTask()
        {
            if (C == 0)
            {
                Console.WriteLine("No tasks found to delete.");
                return;
            }
            Console.Write("Enter the index of the task to delete: ");
            int del = Convert.ToInt32(Console.ReadLine());
            if (del > 0 && del <= C)
            {
                for (int i = del - 1; i < C - 1; i++)
                {
                    tasks[i] = tasks[i + 1];
                }
                C--;
                Console.WriteLine("Task deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
    }
}