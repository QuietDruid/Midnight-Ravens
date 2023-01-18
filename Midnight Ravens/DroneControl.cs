namespace Midnight_Ravens;

public class DroneControl
{
    private static int[] droneHealth = new int[3];
    private static bool[] upMovement = new bool[12]; //boolean array to set if a drone can access a room using the cardinal directions and if the room exists
    private static bool[] downMovement = new bool[12];
    private static bool[] leftMovement = new bool[12];
    private static bool[] rightMovement = new bool[12];
    private static String[] droneName = { "Larry", "Moe", "Curly" }; //Static Drone Names due to Time
    private static int[] droneXPos = new int[3]; //int array to store drone positions
    private static int[] droneYPos = new int[3];
    private static int[] roomNum; //local variable to deal with room Numbers
    public static char stringChecker; //used to check strings to move drone




    public static void GenerateArray() //sets all of the arrays to false
    {
        for (int i = 0; i < upMovement.Length; i++)
        {
            upMovement[i] = false;
        }
        for (int i = 0; i < downMovement.Length; i++)
        {
            downMovement[i] = false;
        }
        for (int i = 0; i < leftMovement.Length; i++)
        {
            leftMovement[i] = false;
        }
        for (int i = 0; i < rightMovement.Length; i++)
        {
            rightMovement[i] = false;
        }

    }
    public static void MapCheck() //unused method to check if a drone could be moved
    {
        GenerateArray();
        for (int i = 0; i < Ships.ReturnArrayLength(); i++)//uses the length of the array to run roomcheck to set which rooms are accesible through the cardinal directions
        {
            RoomCheck(i);
        }
    }

    public static void RoomCheck(int roomNum) //method that uses the room exists array to set if movement in said direction is possible. RoomId is used to identify the room and if statments are used to check given the room number and the result if a room exists
    {
        if (roomNum == 0) //if room is 0(refer back to the reference block) then 
        {
            if (Ships.ReturnArray(1) == 1) // if the room to the right exists then 
            {
                rightMovement[0] = true; //movement to the right is available
            }
            if (Ships.ReturnArray(3) == 1) //if room to the bottom exists then 
            {
                downMovement[0] = true; //movement to the bottom is available

            }
        }
        else if (roomNum == 1) //rinse and repeat
        {
            if (Ships.ReturnArray(0) == 1)
            {
                leftMovement[1] = true;
            }
            if (Ships.ReturnArray(4) == 1)
            {
                downMovement[0] = true;

            }
        }
        else if (roomNum == 2)
        {
            if (Ships.ReturnArray(3) == 1)
            {
                rightMovement[2] = true;
            }
            if (Ships.ReturnArray(6) == 1)
            {
                downMovement[2] = true;

            }
        }
        else if (roomNum == 3)
        {
            if (Ships.ReturnArray(4) == 1)
            {
                rightMovement[3] = true;
            }
            if (Ships.ReturnArray(7) == 1)
            {
                downMovement[3] = true;

            }
            if (Ships.ReturnArray(2) == 1)
            {
                leftMovement[3] = true;

            }
            if (Ships.ReturnArray(0) == 1)
            {
                upMovement[3] = true;

            }
        }
        else if (roomNum == 4)
        {
            if (Ships.ReturnArray(5) == 1)
            {
                rightMovement[4] = true;

            }
            if (Ships.ReturnArray(8) == 1)
            {
                downMovement[4] = true;

            }
            if (Ships.ReturnArray(3) == 1)
            {
                leftMovement[4] = true;

            }
            if (Ships.ReturnArray(1) == 1)
            {
                upMovement[4] = true;

            }
        }
        else if (roomNum == 5)
        {
            if (Ships.ReturnArray(4) == 1)
            {
                leftMovement[5] = true;

            }
        }
        else if (roomNum == 6)
        {
            if (Ships.ReturnArray(7) == 1)
            {
                rightMovement[6] = true;

            }
            if (Ships.ReturnArray(2) == 1)
            {
                upMovement[6] = true;

            }
        }
        else if (roomNum == 7)
        {
            if (Ships.ReturnArray(8) == 1)
            {
                rightMovement[7] = true;

            }
            if (Ships.ReturnArray(10) == 1)
            {
                downMovement[7] = true;

            }
            if (Ships.ReturnArray(6) == 1)
            {
                leftMovement[7] = true;

            }
            if (Ships.ReturnArray(3) == 1)
            {
                upMovement[7] = true;

            }
        }
        else if (roomNum == 8)
        {
            if (Ships.ReturnArray(9) == 1)
            {
                rightMovement[8] = true;

            }
            if (Ships.ReturnArray(11) == 1)
            {
                downMovement[8] = true;

            }
            if (Ships.ReturnArray(7) == 1)
            {
                leftMovement[8] = true;

            }
            if (Ships.ReturnArray(4) == 1)
            {
                upMovement[8] = true;

            }
        }
        else if (roomNum == 9)
        {
            if (Ships.ReturnArray(8) == 1)
            {
                leftMovement[9] = true;

            }
        }
        else if (roomNum == 10)
        {
            if (Ships.ReturnArray(11) == 1)
            {
                rightMovement[10] = true;

            }
            if (Ships.ReturnArray(7) == 1)
            {
                upMovement[10] = true;

            }
        }
        else if (roomNum == 11)
        {
            if (Ships.ReturnArray(10) == 1)
            {
                leftMovement[11] = true;

            }
            if (Ships.ReturnArray(8) == 1)
            {
                upMovement[11] = true;

            }
        }
    }

    public static void DroneShipRep() //method that starts off the drone in the Docking Port/Station
    {
        int tempX = 90;
        int tempY = 24;
			
        for (int i = 1; i <= 3; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(tempX, tempY + i);
            Console.WriteLine("[D" + i + "]");
            droneXPos[i - 1] = tempX;
            droneYPos[i - 1] = tempY + i;
            Console.ForegroundColor = ConsoleColor.Cyan;

        }
			

    }
    public static void CanDroneMove()
    {
        int tempCount = 0;
        int tempCount2 = 0;
        int[] tempIndex = new int[12];
        int[] baseRoom = { 3, 4, 7, 8 }; //Main rooms are given first priority and need to be added to the array first
        for (int i = 0; i < 11; i++) //checks available rooms and availability and inputs into an array
        {
            if (Ships.ReturnArray(i) == 1)
            {
                tempIndex[tempCount] = i;
                tempCount++;
            }
        }
        roomNum = new int[tempCount + 1];

        for (int i = 0; i < 11; i++)
        {
            if (Ships.ReturnArray(i) == 1)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (i == baseRoom[j])
                    {
                        roomNum[tempCount2] = i;
                        tempCount2++;
                    }
                }
            }
        }
        if (Ships.ReturnArray(2) == 1)
        {
            roomNum[tempCount2] = 2;
            tempCount2++;
        }
        for (int i = 0; i < 2; i++) //checks available rooms and availability and inputs into an array
        {
            if (Ships.ReturnArray(i) == 1)
            {
                roomNum[tempCount2] = i;
                tempCount2++;
            }
        }
        for (int i = 5; i < 7; i++) //checks available rooms and availability and inputs into an array
        {
            if (Ships.ReturnArray(i) == 1)
            {
                roomNum[tempCount2] = i;
                tempCount2++;
            }
        }
        for (int i = 9; i < 11; i++) //checks available rooms and availability and inputs into an array
        {
            if (Ships.ReturnArray(i) == 1)
            {
                roomNum[tempCount2] = i;
                tempCount2++;
            }
        }
    }
    public static void DroneTable(int xPos, int yPos, int width, int height) //same base as createCub() but creates a drone menu with active drones and additional info
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string cubeDashTop = "╔" + String.Concat(Enumerable.Repeat("═", width)) + "╗";
        string cubeDashBot = "╚" + String.Concat(Enumerable.Repeat("═", width)) + "╝";
        int counter = 1; //int counter seperate from the i for loop for proper position and use in the index of drone health array

        GenerateDroneHealth();

        Console.SetCursorPosition(xPos, yPos);
        Console.WriteLine(cubeDashTop);

        for (int i = 1; i < height + 1; i++)
        {
            Console.SetCursorPosition(xPos, yPos + i);
            Console.WriteLine("║");
            Console.SetCursorPosition(xPos + width + 1, yPos + i);
            Console.WriteLine("║");
        }

        Console.SetCursorPosition(xPos + 6, yPos + 1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Active Drones");

        for (int i = 0; i < 15; i += 5) //for loop to generate internal elements
        {
            Console.SetCursorPosition(xPos + 1, yPos + 3 + i);
            Console.WriteLine("Drone " + counter + ":");

            Console.SetCursorPosition(xPos + 10, yPos + 3 + i);
            Console.WriteLine(droneName[counter - 1]);

            Console.SetCursorPosition(xPos + 3, yPos + 4 + i);
            Console.WriteLine("Health: ");

            Console.SetCursorPosition(xPos + 11, yPos + 4 + i);
            Console.WriteLine(droneHealth[counter - 1]);

            Console.SetCursorPosition(xPos + 3, yPos + 5 + i);
            Console.WriteLine("Ability: ");

            counter++;
        }
        Console.SetCursorPosition(xPos, yPos + height + 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(cubeDashBot);

        Console.ForegroundColor = ConsoleColor.Blue;
    }
    public static void GenerateDroneHealth()
    {
        for (int i = 0; i < droneHealth.Length; i++) //when DroneHealth is first called set drone health to 70;
        {
            droneHealth[i] = 70;
        }
    }
    public static void MoveDrone(int droneNum, int rmNum) //method to clear the drones previous location and move it towars an available site.
    {
        Console.SetCursorPosition(droneXPos[droneNum - 1], droneYPos[droneNum - 1]);
        Console.WriteLine("    ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(Ships.ReturnXPos(roomNum[rmNum]) + 8, Ships.ReturnYPos(roomNum[rmNum]) + 4 + droneNum);
        Console.WriteLine("[D" + droneNum + "]");
        droneXPos[droneNum - 1] = Ships.ReturnXPos(roomNum[rmNum]) + 8;
        droneYPos[droneNum - 1] = Ships.ReturnYPos(roomNum[rmNum]) + 4 + droneNum;
        Console.SetCursorPosition(Decisions.GetCursorX(), Decisions.GetCursorY());
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < roomNum.Length; i++)
        {
            Console.Write(roomNum[i] + " ");
        }
        Console.WriteLine("");

    }
	
}