using System;
using System.Collections.Generic;

//base for all goals
public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
}

// Define eahc class for goal
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) {}

    public override void RecordEvent()
    {
        Console.WriteLine($"Completed goal: {Name} (+{Points} points)");
    }

    public override string GetStatus()
    {
        return "[ ] " + Name;
    }
}

public class EternalGoal : Goal
{
    private int _count = 0;

    public EternalGoal(string name, int points) : base(name, points) {}

    public override void RecordEvent()
    {
        _count++;
        Console.WriteLine($"Recorded progress on goal: {Name} (+{Points} points)");
    }

    public override string GetStatus()
    {
        return $"{_count}x {Name}";
    }
}

public class ChecklistGoal : Goal
{
    private int _count = 0;
    private int _targetCount;

    public ChecklistGoal(string name, int points, int targetCount) : base(name, points)
    {
        _targetCount = targetCount;
    }

    public override void RecordEvent()
    {
        _count++;
        Console.WriteLine($"Recorded progress on goal: {Name} (+{Points} points)");

        if (_count == _targetCount)
        {
            Points += 500;
            Console.WriteLine($"Completed goal: {Name} (+500 bonus points)");
        }
    }

    public override string GetStatus()
    {
        return $"Completed {_count}/{_targetCount} times: {Name}";
    }
}

// mai eternal quest
public class EternalQuest
{
    private List<Goal> _goals = new List<Goal>();

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
        Console.WriteLine($"Added goal: {goal.Name}");
    }

    public void RecordEvent(string name)
    {
        foreach (Goal goal in _goals)
        {
            if (goal.Name == name)
            {
                goal.RecordEvent();
                return;
            }
        }

        Console.WriteLine($"Goal not found: {name}");
    }

    public void DisplayStatus()
    {
        int totalPoints = 0;

        Console.WriteLine("Current Goals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetStatus());
            totalPoints += goal.Points;
        }

        Console.WriteLine($"Total Points: {totalPoints}");
    }
}


public static void Main()
{
    EternalQuest quest = new EternalQuest();

    
    quest.AddGoal(new SimpleGoal("Run a Marathon", 1000));
    quest.AddGoal(new EternalGoal("Read Scriptures", 100));
    quest.AddGoal(new ChecklistGoal("Attend Temple", 50, 10));

    
    quest.RecordEvent("Read Scriptures");
    quest.RecordEvent("Read Scriptures");
    quest.RecordEvent("Attend Temple");
    quest.RecordEvent("Attend Temple");
    quest.RecordEvent("Attend Temple");
    quest.RecordEvent("Attend Temple");
    quest.RecordEvent("Attend Temple");
    quest.RecordEvent("Attend Temple");
    
    quest.DisplayStatus();
}

