using System;

namespace TaskManagementSystem
{
    class Program
    {
        static List<Task> pendingTasks = new List<Task>();
        static List<Task> completedTasks = new List<Task>();
        static void Main(string[] args)
        {
            string? input;
            int choice = 0;

            Console.WriteLine("Welcome to the Task Management System.");

            while (true)
            {
                Console.WriteLine("Please select from the options below:");
                Console.WriteLine("1: View Pending Tasks \n2: View Completed Tasks \n3: Add Task \n4: Mark Task as Completed \n5: Exit");

                Console.Write("Enter your option: ");
                input = Console.ReadLine();

                if (!int.TryParse(input, out choice) || choice < 1 || choice > 5) Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                else if (choice == 5) { Console.WriteLine("Thank you for using the Task Management System. Goodbye!"); break; }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            ViewPendingTasks();
                            break;
                        case 2:
                            ViewCompletedTasks();
                            break;
                        case 3:
                            AddTask();
                            break;
                        case 4:
                            MarkAsCompleted();
                            break;
                    }
                }
            }
        }
        
        static void ViewPendingTasks()
        {
            if (pendingTasks == null ||pendingTasks.Count < 1) { Console.WriteLine("No tasks available."); }
            else
            {
                Console.WriteLine("Tasks:");
                for (int i = 0; i < pendingTasks.Count; i++) Console.WriteLine($"{i + 1}. {pendingTasks[i].Title}, Priotity {pendingTasks[i].Priority}");
                string? input;
                while (true)
                {
                    Console.Write("More info? (y/n): ");
                    input = Console.ReadLine();
                    if (input == null || input.Length < 1) Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    else if (input != null && input.ToLower() != "y" && input.ToLower() != "n") Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    else { input = input.ToLower(); break; }
                }

                Task? selectedTask;
                if (input == "n") return;
                else
                {
                    int choice = 0;
                    while (true)
                    {
                        Console.Write("Enter the number of the task you want more info on: ");
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out choice) || choice < 1 || choice > pendingTasks.Count) Console.WriteLine("Invalid input. Please enter a valid task number.");
                        else break;
                    }
                    selectedTask = pendingTasks[choice - 1];
                    selectedTask.Info();
                }
                while (true)
                {
                    Console.Write("Would you like to edit this task? (y/n): ");
                    input = Console.ReadLine();
                    if (input == null || input.Length < 1) Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    else if (input != null && input.ToLower() != "y" && input.ToLower() != "n") Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    else { input = input.ToLower(); break; }
                }

                if (input == "n") return;
                else
                {
                    while (true)
                    {
                        Console.Write("Would you like to delete this task? (y/n): ");
                        input = Console.ReadLine();
                        if (input == null || input.Length < 1) Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                        else if (input != null && input.ToLower() != "y" && input.ToLower() != "n") Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                        else { input = input.ToLower(); break; }
                    }

                    if (input == "y")
                    {
                        pendingTasks.Remove(selectedTask);
                        Console.WriteLine("Task successfully deleted!");
                        return;
                    }
                    else { Console.WriteLine("Enter new details for the task (leave fields blank to keep current value):"); }

                    Console.Write("Enter new title: ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input)) selectedTask.Title = input;

                    Console.Write("Enter new description: ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input)) selectedTask.Description = input;

                    while (true)
                    {
                        Console.Write("Enter new expected duration in hours: ");
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input)) break;
                        int newDuration;
                        if (!int.TryParse(input, out newDuration) || newDuration < 1) Console.WriteLine("Please enter a valid number greater than 0");
                        else { selectedTask.ExpectedDuration = newDuration; break; }
                    }

                    while (true)
                    {
                        Console.Write("Enter new priority (1-5, with 1 being highest): ");
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input)) break;
                        int newPriority;
                        if (!int.TryParse(input, out newPriority) || newPriority < 1 || newPriority > 5) Console.WriteLine("Please enter a valid number between 1 and 5");
                        else { selectedTask.Priority = newPriority; break; }
                    }
                    Console.WriteLine("Task updated successfully!");
                }
            }
        }

        static void ViewCompletedTasks()
        {
            if (completedTasks == null || completedTasks.Count < 1) { Console.WriteLine("No completed tasks available."); return; }
            else
            {
                Console.WriteLine("Completed Tasks:");
                for (int i = 0; i < completedTasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {completedTasks[i].Title}, Priotity {completedTasks[i].Priority}, Expected Duration: {completedTasks[i].ExpectedDuration} hours, Actual Duration: {completedTasks[i].ActualDuration} hours");
                    return;
                }
            }

            string? input;
            while (true)
            {
                Console.Write("More info? (y/n): ");
                input = Console.ReadLine();
                if (input == null || input.Length < 1) Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                else if (input != null && input.ToLower() != "y" && input.ToLower() != "n") Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                else { input = input.ToLower(); break; }
            }

            Task? selectedTask;
            if (input == "n") return;
            else
            {
                int choice = 0;
                while (true)
                {
                    Console.Write("Enter the number of the task you want more info on: ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out choice) || choice < 1 || choice > completedTasks.Count) Console.WriteLine("Invalid input. Please enter a valid task number.");
                    else break;
                }
                selectedTask = completedTasks[choice - 1];
                selectedTask.Info();
                Console.WriteLine($"Actual Duration: {selectedTask.ActualDuration} hours");
            }

            while (true)
            {
                Console.Write("Would you like to unmark as completed? (y/n): ");
                input = Console.ReadLine();
                if (input == null || input.Length < 1) Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                else if (input != null && input.ToLower() != "y" && input.ToLower() != "n") Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                else { input = input.ToLower(); break; }
            }

            if (input == "n") return;
            else
            {
                selectedTask.IsCompleted = false;
                selectedTask.ActualDuration = 0;
                pendingTasks.Add(selectedTask);
                completedTasks.Remove(selectedTask);
                Console.WriteLine("Task successfully marked as pending!");
            }
        }

        static void AddTask()
        {
            string title = "";
            string description = "";
            int expectedDuration = 0;
            int priority = 0;
            string? input;

            while (true)
            {
                Console.Write("Enter the task's title: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || input.Length < 1) Console.WriteLine("Please enter a title");
                else { title = input; break; }
            }

            while (true)
            {
                Console.Write("Enter the task's description: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || input.Length < 1) Console.WriteLine("Please enter a description");
                else { description = input; break; }
            }

            while (true)
            {
                Console.Write("Enter the task's expected duration (in hours): ");
                input = Console.ReadLine();
                if (!int.TryParse(input, out expectedDuration) || expectedDuration < 1) Console.WriteLine("Please enter a valid number greater than 0");
                else break;
            }

            while (true)
            {
                Console.Write("Enter the task's priority (1-5, with 1 being highest): ");
                input = Console.ReadLine();
                if (!int.TryParse(input, out priority) || priority < 1 || priority > 5) Console.WriteLine("Please enter a valid number between 1 and 5");
                else break;
            }

            Task newTask = new Task(title, description, expectedDuration, priority);
            pendingTasks.Add(newTask);
            Console.WriteLine("Successfully added the task!");
        }

        static void MarkAsCompleted()
        {
            if (pendingTasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            else
            {
                if (pendingTasks.Count == 0) { Console.WriteLine("No tasks available."); return; }
                else 
                {
                    Console.WriteLine("Pending Tasks:");
                    for (int i = 0; i < pendingTasks.Count; i++) Console.WriteLine($"{i + 1}. {pendingTasks[i].Title}, Priotity {pendingTasks[i].Priority}");
                }
                int choice = 0;
                string? input;

                while (true)
                {
                    Console.Write("Enter the number of the task you want to mark as completed: ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out choice) || choice < 1 || choice > pendingTasks.Count) Console.WriteLine("Invalid input. Please enter a valid task number.");
                    else break;
                }

                Task taskToComplete = pendingTasks[choice - 1];
                int actualDuration = 0;

                while (true)
                {
                    Console.Write("Enter the actual duration taken to complete the task (in hours): ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out actualDuration) || actualDuration < 1) Console.WriteLine("Please enter a valid number greater than 0");
                    else break;
                }

                taskToComplete.IsCompleted = true;
                taskToComplete.ActualDuration = actualDuration;
                completedTasks.Add(taskToComplete);
                pendingTasks.RemoveAt(choice - 1);
                Console.WriteLine("Task marked as completed!");
            }
        }
    }
}