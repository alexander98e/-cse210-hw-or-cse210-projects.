using System;

class Entry
{
    public DateTime Occurs { get; set; }
    public string Text { get; set; }

    public Entry (DateTime occurs, string text)
    {
        Occurs = occurs;
        Text = text;
    }

    public override string ToString()
    {
        return Occurs + " " + Text;
    }
}
class Database
{
    private List<Entry> entries;

    public Database()
    {
        entries = new List<Entry>();
    }

}
private List<Entry> entries = new List<Entry>();

public void AddEntry(DateTime occurs, string text)
{
    entries.Add(new Entry(occurs, text));
}

public List<Entry> FindEntries(DateTime date, bool byTime)
{
    List<Entry> found = new List<Entry>();
    foreach (Entry entry in entries)
    {
        if (((byTime) && (entry.Occurs == date)) 
        ||
        ((!byTime) && (entry.Occurs.Date == date.Date))) 
            found.Add(entry);
    }
    return found;
}
public void DeleteEntries(DateTime date)
{
    List<Entry> found = FindEntries(date, true);
    foreach (Entry entry in found)
        entries.Remove(entry);
}


class Diary
{

    private Database database;

    public Diary()
    {
        database = new Database();
    }

}

private DateTime ReadDateTime()
{
    Console.WriteLine("Enter date and time as e.g. [01/13/2016 14:00]:");
    DateTime dateTime;
    while (! DateTime.TryParse(Console.ReadLine(), out dateTime))
        Console.WriteLine("Error. Please try again: ");
    return dateTime;
}

public void PrintEntries(DateTime day)
{
    List<Entry> entries = database.FindEntries(day, false);
    foreach (Entry entry in entries)
        Console.WriteLine(entry);
}

public void AddEntry()
{
    DateTime dateTime = ReadDateTime();
    Console.WriteLine("Enter the entry text:");
    string text = Console.ReadLine();
    database.AddEntry(dateTime, text);
}
public void SearchEntries()
{
    
    DateTime dateTime = ReadDateTime();
    
    List<Entry> entries = database.FindEntries(dateTime, false);
    
    if (entries.Count() > 0)
    {
        Console.WriteLine("Entries found: ");
        foreach (Entry entry in entries)
            Console.WriteLine(entry);
    }
    else
        
        Console.WriteLine("No entries were found.");
}
public void DeleteEntries()
{
    Console.WriteLine("Entries with the same exact date and time will be deleted");
    DateTime dateTime = ReadDateTime();
    database.DeleteEntries(dateTime);
}

public void PrintHomeScreen()
{
    Console.Clear();
    Console.WriteLine("Welcome!");
    Console.WriteLine("Today is: {0}", DateTime.Now);
    Console.WriteLine();
  

    Console.WriteLine("Today:\n------");
    PrintEntries(DateTime.Today);
    Console.WriteLine();
    Console.WriteLine("Tomorrow:\n---------");
    PrintEntries(DateTime.Now.AddDays(1));
    Console.WriteLine();
}

static void Main(string[] args)
{
   
    Diary diary = new Diary();
    char choice = '0';
    

    while (choice != '4')
    {
        diary.PrintHomeScreen();
        Console.WriteLine();
        Console.WriteLine("Choose an action:");
        Console.WriteLine("1 .- Write");
        Console.WriteLine("2 .- Display or search");
        Console.WriteLine("3 .- Delete entries");
        Console.WriteLine("4 - Exit");
        choice = Console.ReadKey().KeyChar;
        Console.WriteLine();
      
      
        switch (choice)
        {
            case '1':
                diary.AddEntry();
                break;
            case '2':
                diary.SearchEntries();
                break;
            case '3':
                diary.DeleteEntries();
                break;
            case '4':
                Console.WriteLine("Press any key to quit the program...");
                break;
            default:
                Console.WriteLine("Error. Press any key to choose another action.");
                break;
        }
        Console.ReadKey();
    }
}

