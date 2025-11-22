using System;
using System.Collections.Generic;

public class TaskItem
{
    public string Description { get; set; }
    public bool IsDone { get; set; }

    public TaskItem(string description)
    {
        Description = description;
        IsDone = false;
    }
}

class Program
{
    static void Main()
    {
        List<TaskItem> tasks = new List<TaskItem>();

        while (true)
        {
            
            Console.WriteLine("\n/Выберите действие/:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1.|Добавить задачу|");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("2./Посмотреть задачи/");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("3. Отметить задачу как выполненную?");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("4. Выйти?");
            Console.WriteLine("-------------------------------------------");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask(tasks);
                    break;
                case "2":
                    ViewTasks(tasks);
                    break;
                case "3":
                    MarkTaskAsDone(tasks);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте ещё раз.");
                    break;
            }
        }
    }

    static void AddTask(List<TaskItem> tasks)
    {
        Console.Write("Введите описание задачи: ");
        string description = Console.ReadLine();
        tasks.Add(new TaskItem(description));
        Console.WriteLine($"Задача \"{description}\" добавлена!");
    }

    static void ViewTasks(List<TaskItem> tasks)
    {
        Console.WriteLine("\n--- Текущие задачи ---");
        for (int i = 0; i < tasks.Count; i++)
        {
            string marker = tasks[i].IsDone ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {marker} {tasks[i].Description}");
        }
    }

    static void MarkTaskAsDone(List<TaskItem> tasks)
    {
        ViewTasks(tasks);
        Console.Write("\nВведите номер задачи для выполнения: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].IsDone = true;
            Console.WriteLine($"Задача \"{tasks[taskNumber - 1].Description}\" отмечена как выполненная!");
        }
        else
        {
            Console.WriteLine("Неверный номер задачи. Попробуйте ещё раз.");
        }
    }
}
