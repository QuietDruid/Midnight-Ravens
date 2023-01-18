namespace Midnight_Ravens;

public class Decisions
{
    //declared userInput to check what the user has inputted
    public static String userInput; 
    //declared String array to keep reference to which instance the game was in
    public static String[] instanceRef = { "Solar System", "Notifications", "Drone Config", "Ship Display", "Galaxy Map" };
    //Declared String array to reference Ships by an alphabetical ID
    public static char[] shipID = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
    //Declared Int array to give an id to each room to reference later
    public static int[] roomNum = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    //declared int array that could have been a bool array but checks if a room exists. 0 = false; 1 = True
    public static int[] roomExists = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    //declared char to store ShipID and to be used to be inserted to the Ship creation method
    public static char shipInput;
    //Declared int to keep track of the current instance to accurately 
    public static int currentInstance;
    //temp int to store cursor position to set back later
    public static int tempCursorX;
    public static int tempCursorY;

    //When decisions is first called set Current Instance to 0
    public Decisions()
    {
        currentInstance = 0;
    }

    //method that takes the input from the console and gives the respective output based on which screen the player is currently in.
    public static void Checker()
    {
        //set the color of the text to cyan
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Issue a Command:"); //Switching commenting method to make stuff easier. Wrote line to indicate playe
        userInput = Console.ReadLine(); //set user input to userInput
        if (Decisions.currentInstance == 0) //if the current instance is 0 then the following can occur:
        {
            if (userInput == "D" || userInput == "d")// Entering D will send the player to the Drone Menu
            {
                DroneMenu.ShowDrone(); //Calls the show drone method
            }
            else if (userInput == "N" || userInput == "n") //Entering N will send the Player to the Notification menu
            {
                Notifications.ShowNotifications(); //calls the Show notifications method
            }
            else if (userInput == "G" || userInput == "g") //Entering G will cause an error sending the player to the Galaxy as it doesn't exist
            {
                Console.WriteLine("Galaxy Map Incomplete. Cannot Procede"); //writing to console
                Decisions.Checker(); //calling the checker again to allow the user to input another command
            }
            else if (userInput[0] == 'T' || userInput[0] == 't') //Entering T will start the Travel process
            {
                userInput = userInput + "  "; //buffer added to userInput to lessen breaks in code
                if (userInput[2] == 'A' || userInput[2] == 'B' || userInput[2] == 'C' || userInput[2] == 'D' || userInput[2] == 'E' || userInput[2] == 'F' || userInput[2] == 'G' || userInput[2] == 'H') { //Traveling is called by "T [ShipID]". If checks if a valid ID was entered.
                    for (int i = 0; i < shipID.Length; i++)
                    {
                        if (shipID[i] == userInput[2]) //compares ShipID to the character entered and confirms it in the array 
                        {
                            shipInput = shipID[i]; //ship Input is made equal to the confirmed array value to ease issues from using UserInput[2] or shipId[at whatever]
                        }
                    }
                    if (Galaxy.CheckStatus(shipInput) == true) //checks the status of the ship to make sure one has not been there before. If it has, travel to the ship is denied
                    {
                        Console.WriteLine("Invalid Request: Have Already Visited");
                        Decisions.Checker(); //calls the checker method again
                    } else
                    {
                        Decisions.Travel(); //all passes then the Travel method is called
                    }
						
                }
                else // if the second part of the command is invalid. An error message is displayed
                {
                    Console.WriteLine("Invalid Request");
                    Decisions.Checker(); //calls the checker method again

                }
						
            }
            else if (userInput == "Ship Info" || userInput == "ship info" || userInput == "ship Info" || userInput == "Ship info") //Ship Info displays the shipID, Type, and Status
            {
                Console.WriteLine("ShipID : Ship Type : Additional Info");
                for (int i = 0; i < Galaxy.ShipNum(); i++) //Using a for loop to create a list of the available ships and their status
                {
                    Console.WriteLine(Galaxy.ShipID(i) + ": " + Galaxy.Ships(i) + " - " + Galaxy.ShipStatus(i));
                }
                Decisions.Checker();//Calling Checker Method as it only displays text in console rather than a new screen

            }
            else //unicheck is called for repeating checks (help and exit commands)
            {
                UniCheck();
            }
				
        }
        else if (Decisions.currentInstance == 1) //Decision Tree for notifications
        {
            if (userInput == "D" || userInput == "d") //Goes to Drone Menu
            {
                DroneMenu.ShowDrone();
            }
            else if (userInput == "N" || userInput == "n") //Notifies Player that they're already in Notifications
            {
                Console.WriteLine("Already in Notifications");
            }
            else if (userInput == "G" || userInput == "g") //Denies Player access to Galaxy Map
            {
                Console.WriteLine("Galaxy Map Incomplete. Cannot Procede");
                Decisions.Checker();
            }
            else if (userInput == "S" || userInput == "s")//Goes to Solar System
            {
                Galaxy.ShowSystem();
            }
            else //Universal Check
            {
                UniCheck();
            }
        }
        else if (Decisions.currentInstance == 2) //Decision Tree for Drones
        {
            if (userInput == "D" || userInput == "d") //Notifies Player they're already in Drone menu
            {
                Console.WriteLine("Already in Drone Configurations");
                Decisions.Checker();
            }
            else if (userInput == "N" || userInput == "n") //Goes to Notifications
            {
                Notifications.ShowNotifications();
            }
            else if (userInput == "G" || userInput == "g") //Denies Acces to Galaxy Map
            {
                Console.WriteLine("Galaxy Map Incomplete. Cannot Procede");
                Decisions.Checker();
            }
            else if (userInput == "S" || userInput == "s")// Goes to Solar System
            {
                Galaxy.ShowSystem();
            }
            else //Univeral Check
            {
                UniCheck();
            }
        }
        else if (Decisions.currentInstance == 3) //Decision Tree for Ships
        {
				
            if (LongCheck(userInput)) //following 3 if statements deny acess during Ship inspection
            {
                Console.WriteLine("Moving Drone");
                Decisions.Checker();

            }
            else if (userInput == "N" || userInput == "n")
            {
                Console.WriteLine("Cannot Access");
                Decisions.Checker();
            }
            else if (userInput == "G" || userInput == "g")
            {
                Console.WriteLine("Cannot Access");
                Decisions.Checker();
            }
            else if (userInput == "S" || userInput == "s") //goes back to solar system and makes sure that the user is sure of their actions
            {
                Console.WriteLine("Are You Sure? You Won't Be Able To Come Back. Y/N");
                userInput = Console.ReadLine();
                if (userInput == "Y" || userInput == "y") //if Y then back to solar system
                {
                    Galaxy.ShowSystem();
                }
                else if (userInput == "N" || userInput == "n") //if N then stay on current ship and calls the checker again
                {
                    Decisions.Checker();
                }
                else
                {
                    Console.WriteLine("Command Not Recognized"); //error recognition
                    Decisions.Checker();
                }
					
            }
            else if (userInput == "Print" || userInput == "print") //debugging command that prints active rooms in current ship
            {
                int[] tempIndex = new int[12];
                int tempCount = 0;
                for (int i = 0; i < Ships.ReturnArrayLength();i++)
                {
                    Console.Write(Ships.ReturnArray(i) + " ");
                }
                Console.WriteLine("");
                for (int i = 0; i < 11; i++) //checks available rooms and availability and inputs into an array
                {
                    if (Ships.ReturnArray(i) == 1)
                    {
                        tempIndex[tempCount] = i;
                        tempCount++;
                    }
                }
                roomNum = new int[tempCount + 1];
                for (int i = 0; i < roomNum.Length; i++)
                {
                    roomNum[i] = tempIndex[i];
                }
                for (int i = 0; i < roomNum.Length; i++)
                {
                    Console.Write(roomNum[i] + " ");
                }
                Console.WriteLine("");
                Decisions.Checker();

            }
            else //universal check
            {
                UniCheck();
            }
        }
    }
    public static int Instance() //accessor method for current instance
    {
        return currentInstance;
    }

    public static void ChangeInstance(int instance) //mutator method for current instance
    {
        currentInstance = instance;
    }

    public static void Help() //method that displays help information
    {
        Console.WriteLine("Usable Commands:");
        Console.WriteLine("\"D\" : Goes to Drone Config");
        Console.WriteLine("\"S\" : Goes to Solar System Map");
        Console.WriteLine("\"N\" : Checks Notifications");
        Console.WriteLine("\"G\" : Goes to Galaxy Map");
        Console.WriteLine("\"Ship Info\" : Shows Information about Ships");
        Console.WriteLine("\"T\" [Ship Number] : Travels to Assigned Ship");
        Console.WriteLine("\"Exit\" : Exits the Program");
        Decisions.Checker();
    }
    public static void RecognitionError() //method that displays an error and calls the Checker method again
    {
        Console.WriteLine("Command Not Recognized");
        Decisions.Checker();
    }
    public static void UniCheck() //method that repeats useful user inputs to cut back on lines
    {
        if (userInput == "H" || userInput == "Help" || userInput == "help" || userInput == "h") //if any of the statements are met calls help method
        {
            Decisions.Help();
        }
        else if (userInput == "exit" || userInput == "Exit") //calls the exit method if exit is typed
        {
            Decisions.Exit();
        }
        else
        {
            Decisions.RecognitionError(); //calls the recognition error method
        }
    }
    public static void Exit() //method that asks the player if they are sure about exiting
    {
        Console.WriteLine("Are You Sure? Y/N");
        userInput = Console.ReadLine();
        if (userInput == "Y" || userInput == "y")//if Y then exit the program
        {
            System.Environment.Exit(0);
        }
        else if (userInput == "N" || userInput == "n")//if N then stay on current ship and calls the checker again
        {
            Decisions.Checker();
        }
        else
        {
            Console.WriteLine("Command Not Recognized"); //error recognition
            Decisions.Checker();
        }
    }
    public static void Travel() //confirming travel method
    {
			
        Console.WriteLine("Confirm Travel to ShipID: " + userInput[2] + ". Y/N"); //displays shipID of target ship
        userInput = Console.ReadLine();
        if (userInput == "Y" || userInput == "y") //if Y:
        {
            Console.WriteLine("Confirming Flight Plan..."); //displays text
            Console.Clear(); //clears the console
            Ships.ResetRoomNum(); //clears the ship room numbers to confirm prior ship usage doesn't impact new usage
            Galaxy.ChangeStatus(shipInput); //changes the status of ship from active to disabled so that players are unable to return to the ship later on
            Ships.DisplayInternal(shipInput); //displays the layout of the ship with the letter of the shipID

        }
        else if (userInput == "N" || userInput == "n")// if N: Flight plan aborted and Checker is called
        {
            Console.WriteLine("Canceling Flight Plan...");
            Decisions.Checker();

        }
        else
        {
            Console.WriteLine("Please Enter a Valid Input."); //error recognition
            Decisions.Travel();
        }
    }
    public static bool LongCheck(String userInput) //method used to check which movement command was inputted by the user
    {
        if (userInput == "D1 R0" || userInput == "D1 R1" || userInput == "D1 R2" || userInput == "D1 R3" || userInput == "D1 R4" || userInput == "D1 R5" || userInput == "D1 R6" || userInput == "D1 R7" || userInput == "D1 R8" || userInput == "D1 R9" || userInput == "D1 R10" || userInput == "D1 R11" )
        {
				
            tempCursorX = Console.CursorLeft;
            tempCursorY = Console.CursorTop;
            char tempChar = userInput[4];
            int tempVal = (int)Char.GetNumericValue(tempChar);
            DroneControl.MoveDrone(1, tempVal);
            return true;
        }
        else if (userInput == "D2 R0" || userInput == "D2 R1" || userInput == "D2 R2" || userInput == "D2 R3" || userInput == "D2 R4" || userInput == "D2 R5" || userInput == "D2 R6" || userInput == "D2 R7" || userInput == "D2 R8" || userInput == "D2 R9" || userInput == "D2 R10" || userInput == "D2 R11")
        {
            char tempChar = userInput[4];
            int tempVal = (int)Char.GetNumericValue(tempChar);
            DroneControl.MoveDrone(2, tempVal);
            return true;
				
        }
        else if (userInput == "D3 R0" || userInput == "D3 R1" || userInput == "D3 R2" || userInput == "D3 R3" || userInput == "D3 R4" || userInput == "D3 R5" || userInput == "D3 R6" || userInput == "D3 R7" || userInput == "D3 R8" || userInput == "D3 R9" || userInput == "D3 R10" || userInput == "D3 R11")
        {
            char tempChar = userInput[4];
            int tempVal = (int)Char.GetNumericValue(tempChar);
            DroneControl.MoveDrone(3, tempVal);
				
            return true;
        } else
        {
            return false;
        }

    }
    public static int GetCursorX()
    {
        return tempCursorX;
    }
    public static int GetCursorY()
    {
        return tempCursorY;
    }

}