using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Cache;
class Program
{
    static string StudentRecord = @"C:\StudentRecordSystem\students.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Simple Student Record System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.\n");
                continue;
            }
            if (choice == 3)
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    ViewAllStudents();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Enter number between 1 - 3.\n");
                    break;
            }
        }
    }
    static void AddStudent()
    {
        Console.Write("Enter the Student Name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Error: Name cannot be empty.\n");
            return;
        }
        Console.Write("Enter the Student Age: ");
        string ageInput = Console.ReadLine();

        if (string.IsNullOrEmpty(ageInput))
        {
            Console.WriteLine("Error: Age cannot be empty.\n");
            return;
        }
        else if (!int.TryParse(ageInput, out int age) || age <= 0)
        {
            Console.WriteLine("Error: Invalid age. Please enter a valid positive number.\n");
            return;
        }
        Directory.CreateDirectory(Path.GetDirectoryName(StudentRecord));
        using (StreamWriter sw = new StreamWriter(StudentRecord, append: true))
        {
            sw.WriteLine($"{name}, {ageInput}");
        }
        Console.WriteLine("Student added successfully!\n");
    }
    static void ViewAllStudents()
    {
        if (!File.Exists(StudentRecord))
        {
            Console.WriteLine("No student records found.\n");
            return;
        }
        string[] lines = File.ReadAllLines(StudentRecord);
        if (lines.Length == 0)
        {
            Console.WriteLine("No student records found.\n");
            return;
        }
        Console.WriteLine("View All Students Record: ");
        foreach (string line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
                Console.WriteLine($"Name: {parts[0]} , Age:  {parts[1]}");
        }
        Console.WriteLine();
    }
}