namespace Midnight_Ravens;

public class Galaxy
{
    public static String[] ships; //String array to be set later on
    public static int[] shipsPosX; //int array to store the Xpos of the ships for display
    public static int[] shipsPosY;//int array to store the Ypos of the ships for display
    public static int indexAt; //int to store index of active true later
    public static char[] shipID = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' }; //ship ID array for list and display purposes
    public static int[] activeTrue = {0, 0, 0, 0, 0, 0, 0, 0, 0 , 0 }; //int that could've been a boolean array to store if a ship is active/available
    public static String isActive = "Active"; //string storing active
    public static String isDisabled = "Disabled"; //string storing disabled
    public static int shipNum; //stores number of ships that were created
    public static Boolean HasGenerated = false; //used to indicate if ships have been already created or not
		
    public Galaxy()
    {
        Console.Clear(); //clears console
			
    }
    public static void GenerateShips() //method to generate number of ships, their positions, and what type they are
    {
        Random rand = new Random();
        shipNum = rand.Next(6, 9); //random number of ships set to shipNum
        ships = new string[shipNum]; //ships array set with number of ships
        shipsPosX = new int[shipNum]; //ships Xpos array set with number of ships
        shipsPosY = new int[shipNum]; //ships Ypos array set with number of ships
        int shipType; //local var type created
        int tempPos; //temp var to hold xpos variable
        for (int i = 0; i < shipNum ; i++) //for loop that decides type of ship by calling a random number in 100; percentanges are drawn be sectioning out different values to skew results. Freight > Military > Personal
        {
            shipType = rand.Next(100);
            if (shipType >= 0 && shipType <= 45) { //if value falls between a certain point then the ship array is updated with its type
                ships[i] = "Freight";
            }
            if (shipType >= 46 && shipType <= 80)
            {
                ships[i] = "Military";
            }
            if (shipType >= 81 && shipType <= 99)
            {
                ships[i] = "Personal";
            }

        }
        for (int i = 0; i < shipNum; i++ ) //for loop to set x and y position for ship and set the position to their respective array
        {
            tempPos = rand.Next(3, 148);
            shipsPosX[i] = tempPos;
            tempPos = rand.Next(3, 30);
            shipsPosY[i] = tempPos;
        }
    }
    public static void SolarReference() //method that displays the position for the ships using its respective array and ShipID and calls the checker
    {
        for (int i = 0; i < shipNum; i++)
        {
            Console.SetCursorPosition(shipsPosX[i], shipsPosY[i]);
            Console.WriteLine("╔═╗");
            Console.SetCursorPosition(shipsPosX[i], shipsPosY[i]+1);
            Console.WriteLine("║" + shipID[i] + "║");
            Console.SetCursorPosition(shipsPosX[i], shipsPosY[i] + 2);
            Console.WriteLine("╚═╝");
        }
        Console.SetCursorPosition(0, 32);
        Decisions.Checker();
    }
    public static void ShowSystem() //shows the solar system
    {
        Console.Clear(); //clears the console
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗"); //sets the banner
        Console.WriteLine("║                                    Drone Config [D] ║ Galaxy Map [G] ║ Travel [T] ║ Help [Help] ║ Notifications[] [N]                              ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Decisions.ChangeInstance(0); //changes the instance to solar system
        if (HasGenerated == false) //checks if the ships have generated before. if they haven't then:
        {
            Galaxy.GenerateShips(); //generate new ships
            HasGenerated = true; //set state to true
        }
        Galaxy.SolarReference(); //call method to show positions of the ships
			
    }
    public static int ShipNum() //accessor for the ship num
    {
        return shipNum;
    }
    public static string Ships(int ArrPlace) //accessor for the ships array
    {
        return ships[ArrPlace];
    }
    public static char ShipID(int arrPlace) //accessor for the shipID
    {
        return shipID[arrPlace];
    }
    public static string ShipStatus(int check) //accessor is that checks the status of a ship at the same index and returns a message based on its state. 0 = active; 1 is disabled.
    {
        if (activeTrue[check] == 1 )
        {
            return isDisabled;
        }
        else
        {
            return isActive;
        }
    }
    public static bool CheckStatus(char check) //accessor that checks the status and returns a true or false
    {
        for (int i = 0; i < shipID.Length; i++)
        {
            if (shipID[i] == check)
            {
                indexAt = i;
            }
        }
        if (activeTrue[indexAt] == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void ChangeStatus(char shipChar)//mutator method that chances the status of a ship at a certain index
    {
        for (int i = 0; i < shipID.Length; i++)
        {
            if (shipID[i] == shipChar)
            {
                activeTrue[i] = 1;
            }
        }
    }
}