namespace Midnight_Ravens;

public class Notifications
{
    static string dash = string.Concat(Enumerable.Repeat("-", 149)); //String var for dash
    public static void ShowNotifications()//method to show notifications menu
    {
        Console.Clear(); //clears console and sets banner
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                    Drone Config [D] ║ Galaxy Map [G] ║ Travel [T] ║ Help [Help] ║ Solar System [S]                                 ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Decisions.ChangeInstance(1); //changes the instance to the notification instance
        Console.SetCursorPosition(71, 5); //sets cursor position
        Console.WriteLine("Messages");
        FormatNotifications(); //calls format notifications to display the rest of notifications
        Decisions.Checker(); //calls for the checker
			
    }
    static void FormatNotifications() //method that displays an inbox like menu for notifications that were sent.
    {
        Console.SetCursorPosition(2, 7);
        Console.WriteLine("Entry #");
        Console.SetCursorPosition(23, 7);
        Console.WriteLine("Sender");
        Console.SetCursorPosition(71, 7);
        Console.WriteLine("Subject");
        Console.SetCursorPosition(0, 8);
        Console.WriteLine(dash);
        for (int i = 0; i < 21; i++)
        {
            Console.SetCursorPosition(2, i + 9);
            Console.WriteLine(i);
            Console.SetCursorPosition(11, i + 9);
            Console.WriteLine("|");
            Console.SetCursorPosition(43, i + 9);
            Console.WriteLine("|");
        }
    }
    public static void UpdateNotifications()
    {

    }
}