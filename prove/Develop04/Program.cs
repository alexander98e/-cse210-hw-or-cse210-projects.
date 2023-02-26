
public abstract class Activity
{
    // The name of the activity
    public string Name { get; set; }

    // The description of the activity
    public string Description { get; set; }

    // The duration of the activity in seconds
    public int Duration { get; set; }

    // The method to run the activity
    public abstract void RunActivity();
}

// BreathingActivity.cs
// The class for the breathing activity
public class BreathingActivity : Activity
{
    // Override the RunActivity method from the base class
    public override void RunActivity()
    {
        // Show the starting message
        Console.WriteLine($"Starting {Name} which will last for {Duration} seconds.");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine("Prepare to begin...");

        // Pause for a few seconds
        System.Threading.Thread.Sleep(3000);

        // Start the activity
        Console.WriteLine("Breathe in...");
        System.Threading.Thread.Sleep(Duration * 1000);
        Console.WriteLine("Breathe out...");
        System.Threading.Thread.Sleep(Duration * 1000);

        // Show the ending message
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Console.WriteLine("Thank you for participating.");
    }
}

// ReflectionActivity.cs
// The class for the reflection activity
public class ReflectionActivity : Activity
{
    // The list of prompts
    public List<string> Prompts { get; set; }

    // The list of questions
    public List<string> Questions { get; set; }

    // Override the RunActivity method from the base class
    public override void RunActivity()
    {
        // Show the starting message
        Console.WriteLine($"Starting {Name} which will last for {Duration} seconds.");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine("Prepare to begin...");

        // Pause for a few seconds
        System.Threading.Thread.Sleep(3000);

        // Get a random prompt
        Random random = new Random();
        int promptIndex = random.Next(0, Prompts.Count - 1);
        Console.WriteLine(Prompts[promptIndex]);

        // Ask the questions
        for (int i = 0; i < Questions.Count; i++)
        {
            Console.WriteLine(Questions[i]);
            System.Threading.Thread.Sleep(Duration * 1000);

            // Show a spinner while the program is paused
            Console.CursorLeft = 0;
            Console.Write("|");
            System.Threading.Thread.Sleep(1000);
            Console.CursorLeft = 0;
            Console.Write("/");
            System.Threading.Thread.Sleep(1000);
            Console.CursorLeft = 0;
            Console.Write("-");
            System.Threading.Thread.Sleep(1000);
            Console.CursorLeft = 0;
            Console.Write("\\");
            System.Threading.Thread.Sleep(1000);
        }

        // Show the ending message
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Console.WriteLine("Thank you for participating.");
    }
}

// ListingActivity.cs
// The class for the listing activity
public class ListingActivity : Activity
{
    // The list of prompts
    public List<string> Prompts { get; set; }

    // Override the RunActivity method from the base class
    public override void RunActivity()
    {
        // Show the starting message
        Console.WriteLine($"Starting {Name} which will last for {Duration} seconds.");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine("Prepare to begin...");

        // Pause for a few seconds
        System.Threading.Thread.Sleep(3000);

        // Get a random prompt
        Random random = new Random();
        int promptIndex = random.Next(0, Prompts.Count - 1);
        Console.WriteLine(Prompts[promptIndex]);

        // Give them a few seconds to think
        System.Threading.Thread.Sleep(Duration * 1000);

        // Ask them to start listing
        Console.WriteLine("Start listing...");
        int itemCount = 0;
        while (Duration > 0)
        {
            string input = Console.ReadLine();
            itemCount++;
            Duration--;
        }

        // Show the ending message
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds and listed {itemCount} items.");
        Console.WriteLine("Thank you for participating.");
    }
}

public static void Main();
{
   
    ListingActivity listingActivity = new ListingActivity
    {
        Name = "Listing Activity",
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
        Duration = 10,
        Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        }
    };

    ReflectionActivity reflectionActivity = new ReflectionActivity
    {
        Name = "Reflection Activity",
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
        Duration = 7,
        Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        },
        Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        }
    };

    BreathingActivity breathingActivity = new BreathingActivity
    {
        Name = "Breathing Activity",
        Description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
        Duration = 5
    };

    // Show the menu and let the user choose an activity
    Console.WriteLine("Choose an activity:");
    Console.WriteLine("1. Breathing Activity");
    Console.WriteLine("2. Reflection Activity");
    Console.WriteLine("3. Listing Activity");

    // Get the user's choice
    int choice = int.Parse(Console.ReadLine());

    // Run the chosen activity
    if (choice == 1)
        breathingActivity.RunActivity();
    else if (choice == 2)
        reflectionActivity.RunActivity();
    else if (choice == 3)
        listingActivity.RunActivity();
    else
        Console.WriteLine("Invalid choice!");
}