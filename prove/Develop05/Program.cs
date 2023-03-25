using System.Security.Cryptography.X509Certificates;
public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }
X500DistinguishedName
    public virtual void MarkCompleted()
    {
        IsCompleted = true;
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value, int points)
    {
        Name = name;
        Value = value;
        Points = points;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int value, int points)
    {
        Name = name;
        Value = value;
        Points = points;
    }

    public override void MarkCompleted()
    {
        Points += Value;
    }
}

public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int Count { get; set; }

    public ChecklistGoal(string name, int value, int points, int target)
    {
        Name = name;
        Value = value;
        Points = points;
        Target = target;
    }

    public override void MarkCompleted()
    {
        Count++;
        if (Count >= Target)
        {
            Points += Value;
            IsCompleted = true;
        }
    }
}

public class GoalTracker
{
    private List<Goal> goals = new List<Goal>();

    public void CreateSimpleGoal(string name, int value, int points)
    {
        goals.Add(new SimpleGoal(name, value, points));
    }

    public void CreateEternalGoal(string name, int value, int points)
    {
        goals.Add(new EternalGoal(name, value, points));
    }

    public void CreateChecklistGoal(string name, int value, int points, int target)
    {
        goals.Add(new ChecklistGoal(name, value, points, target));
    }

    public void RecordEvent(string name)
    {
        Goal goal = goals.Find(g => g.Name == name);
        if (goal != null)
        {
            goal.MarkCompleted();
        }
    }

    public int GetScore()
    {
        int score = 0;
        foreach (Goal goal in goals)
        {
            if (goal.IsCompleted)
            {
                score += goal.Points;
            }
        }
        return score;
    }

    public List<string> GetGoalList()
    {
        List<string> goalList = new List<string>();
        foreach (Goal goal in goals)
        {
            string status = goal.IsCompleted ? "[X]" : "[ ]";
            if (goal is ChecklistGoal)
            {
                status += $" Completed {((ChecklistGoal)goal).Count}/{((ChecklistGoal)goal).Target} times";
            }
            goalList.Add($"{status} {goal.Name} ({goal.Points
