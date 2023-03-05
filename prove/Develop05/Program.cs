using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool Completed { get; set; }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
        Completed = false;
    }

    public void Complete()
    {
        Completed = true;
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
        Completed = false;
    }

    public void Record()
    {
        Completed = false;
    }
}

class ChecklistGoal : Goal
{
    public int Count { get; set; }
    public int Total { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, int value, int total, int bonus)
    {
        Name = name;
        Value = value;
        Total = total;
        Bonus = bonus;
        Count = 0;
        Completed = false;
    }

    public void Record()
    {
        Count++;
        if (Count == Total)
        {
            Completed = true;
        }
    }
}

class EternalQuest
{
    List<Goal> Goals = new List<Goal>();
    int Score { get; set; }

    public void CreateGoal(string type, string name, int value, int total = 0, int bonus = 0)
    {
        switch (type)
        {
            case "Simple":
                Goals.Add(new SimpleGoal(name, value));
                break;
            case "Eternal":
                Goals.Add(new EternalGoal(name, value));
                break;
            case "Checklist":
                Goals.Add(new ChecklistGoal(name, value, total, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordGoal(string name)
    {
        var goal = Goals.FirstOrDefault(g => g.Name == name);
        if (goal == null)
        {
            Console.WriteLine("Goal not found.");
        }
        else
        {
            goal.Record();
            if (goal is ChecklistGoal)
            {
                Score += ((ChecklistGoal)goal).Count * goal.Value;
                if (((ChecklistGoal)goal).Count == ((ChecklistGoal)goal).Total)
                {
                    Score += ((ChecklistGoal)goal).Bonus;
                }
            }
            else
            {
                Score += goal.Value;
            }
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in Goals)
        {
            if (goal is ChecklistGoal)
            {
                Console.WriteLine($"{goal.Name} ({((ChecklistGoal)
