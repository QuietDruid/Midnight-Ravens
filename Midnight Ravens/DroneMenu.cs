namespace Midnight_Ravens;

public class DroneMenu
{
    public static void ShowDrone() //shows the drone menu
    {
        Console.Clear(); //clears console and sets banner
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                    Solar System [S] ║ Galaxy Map [G] ║ Travel [T] ║ Help [Help] ║ Notifications[] [N]                              ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Decisions.ChangeInstance(2); //changes instance to drone menu
        Console.SetCursorPosition(66, 5); //writes and formats drone menu
        Console.WriteLine("Drone Configuration");
        Console.SetCursorPosition(69, 6);
        Console.WriteLine("Active Drones");
        FormatDrone(8); //calls format drone method with a y parameter to continue writing out the drone menu for active drones
        Console.SetCursorPosition(67, 14 );
        Console.WriteLine("Deactivated Drones");
        FormatDrone(16); //calls format drone method with a y parameter to continue writing out the drone menu for inactive drones
        Decisions.Checker();

    }
    static void FormatDrone(int yVal) //method that creates a layout for drones to be inserted and information to be written about them given a y parameter
    {
        Console.SetCursorPosition(2, yVal);
        Console.WriteLine("Drone #");
        Console.SetCursorPosition(23, yVal);
        Console.WriteLine("Drone Name");
        Console.SetCursorPosition(45, yVal);
        Console.WriteLine("Ability 1");
        Console.SetCursorPosition(56, yVal);
        Console.WriteLine("Ability 2");
        Console.SetCursorPosition(68, yVal);
        Console.WriteLine("Health");
        Console.SetCursorPosition(0, yVal + 1);
        for (int i = 1; i < 4; i++)
        {
            Console.SetCursorPosition(2, i + yVal + 1);
            Console.WriteLine(i);
            Console.SetCursorPosition(11, i + yVal + 1);
            Console.WriteLine("-");
            Console.SetCursorPosition(43, i + yVal + 1);
            Console.WriteLine("-");
            Console.SetCursorPosition(54, i + yVal + 1);
            Console.WriteLine("-");
            Console.SetCursorPosition(66, i + yVal + 1);
            Console.WriteLine("-");
        }
    }
}