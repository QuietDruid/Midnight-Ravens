namespace Midnight_Ravens;

public class Ships
{
    public static int mainRoom; //declared int for the number of main rooms
    public static int subRoomOne; //declare int for the number of upper left sub rooms
    public static int subRoomTwo; //declare int for the number of upper right sub rooms
    public static int subRoomThree;//declare int for the number of lower left sub rooms
    public static int subRoomFour;//declare int for the number of lower right sub rooms
    public static int roomChance; //declared int to store the chance of either room appearing when only one room is called.
    public static int roomNum; //declared int to use in the number of rooms on the ship
    public static String cubeDashTop; //String to hold dash to art purposes
    public static String cubeDashBot; //ditto
    public static bool topLeftExist; //boolean that checks if the top left room exists to allow subrooms to be generated
    public static bool botLeftExist; ////boolean that checks if the bottom left room exists to allow subrooms to be generated
    public static int[] roomID = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }; //roomID reference
    public static int[] roomExists = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //int array that couldve been a boolean array that keeps track if a room exists. 0 = false; 1 = true
    public static int[] cubeXPos = { 45, 66, 28, 43, 64, 85, 28, 43, 64, 85, 46, 67 }; //X and Y pos arrays to be accessed later
    public static int[] cubeYPos = { 3, 3, 10, 9, 9, 10, 21, 20, 20, 31, 31, 31 };

    public static void GenerateInternal() //method generates unique interval variables to be used for the layout of the ship and resets booleans to false
    {
        Random rand = new Random(); //new random is called and variables are stored
        mainRoom = rand.Next(3,5); //only variables 3 and 4 are accepted to make things a little easier for drone manipulation and time constraints. 3 rooms or 4 rooms
        subRoomOne = rand.Next(3); //0 = no subrooms, 1 = 1 subrroom, 2 = 2 subrooms
        subRoomTwo = rand.Next(3);
        subRoomThree = rand.Next(3);
        subRoomFour = rand.Next(2); //two options are called because only 1 subrroom is available
        roomChance = rand.Next(2); //room chance is used in scenarios when 1 room is called but 2 options are available and decides which option is chosen
        topLeftExist = false; //booleans set to false
        botLeftExist = false;

    }
    public static void DisplayInternal(char ShipId) //displays the ship layout menus
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗"); //upper banner with shipID
        Console.WriteLine("║                                                              Ship " + ShipId  + " Layout                                                                         ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Decisions.ChangeInstance(3); //changes the check to the ship instance
        ResetArray(); //calls reset method to reset existing room array
        GenerateInternal(); //calls the generate variables method
        if (mainRoom == 3) //if room is 3 then the one room can appear in the either bottom left or top left
        {
            if (roomChance == 0) //if room chance is 0 then bottom left room is created
            {
                CreateCube(64, 9, 18, 9); //top right -Creat Cube Method creates customizable cubes based on cursor position of X and Y and Width and Height of desire cube
                CreateCube(43, 20, 18, 9); //bot left
                CreateCube(64, 20, 18, 9);
                botLeftExist = true; //bottom left boolean is set to true
                roomExists[4] = 1; //updates array to set roomExists array to true(1)
                roomExists[7] = 1;
                roomExists[8] = 1;
            }
            else if (roomChance == 1)//if room chance is 1 then top left room is created
            {
                CreateCube(43, 9, 18, 9); //top left
                CreateCube(64, 9, 18, 9); //top right
                CreateCube(64, 20, 18, 9);
                topLeftExist = true;// top left boolean is set to true
                roomExists[3] = 1;
                roomExists[4] = 1;
                roomExists[8] = 1;
            }
            //Reference for Cubes and their Respecive Static Room ID
            //CreateCube(45, 3, 14, 4); //top left top - 0
            //CreateCube(66, 3, 14, 4); //top right top - 1
            //CreateCube(28, 10, 12, 6); // sub top left left - 2
            //CreateCube(43, 9, 18, 9); //top left - 3
            //CreateCube(64, 9, 18, 9); //top right - 4
            //CreateCube(85, 10, 12, 6); //top right right - 5
            //CreateCube(28, 21, 12, 6); // sub bot left left - 6
            //CreateCube(43, 20, 18, 9); //bot left - 7
            //CreateCube(64, 20, 18, 9); //bot right - 8
            //CreateDock(85, 31, 12, 6); //bottom right right - 9
            //CreateCube(46, 31, 12, 6); // sub bot left bot - 10
            //CreateCube(67, 31, 12, 6); //sub bot right bot - 11
        }
        else if (mainRoom == 4) //if room is 4 then all cubes are created and set to true
        {
            CreateCube(43, 9, 18, 9); //top left
            CreateCube(64, 9, 18, 9); //top right
            CreateCube(43, 20, 18, 9); //bot left
            CreateCube(64, 20, 18, 9);
            topLeftExist = true;
            botLeftExist = true;
            roomExists[3] = 1;
            roomExists[4] = 1;
            roomExists[7] = 1;
            roomExists[8] = 1;
        }
        DroneControl.DroneTable(110, 10, 25, 18); //calling drone table method to create a drone table with info
        DroneControl.DroneShipRep(); //creates the drones rep in the docking station
        CreateSubRooms(); //create sub room method is called
        DroneControl.CanDroneMove(); //method that checks if room can be moved to.
        Console.SetCursorPosition(0, 40); //set cursor to below map layout to continue checker
        Decisions.Checker(); //checker called
    } 
    public static void CreateCube(int xPos, int yPos, int width, int height) //method that creates a cube based on Xpos, YPos, width, and height
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        cubeDashTop = "╔" + String.Concat(Enumerable.Repeat("═", width)) + "╗"; //top part of cube
        cubeDashBot = "╚" + String.Concat(Enumerable.Repeat("═", width)) + "╝"; //bottom part of cube
        Console.SetCursorPosition(xPos, yPos); //cursor set to top left of cube
			
        Console.WriteLine(cubeDashTop); //writes top part
        for(int i = 1; i < height + 1; i++) //for loop to create sides of cube
        {
            Console.SetCursorPosition(xPos, yPos + i);
            Console.WriteLine("║");
            Console.SetCursorPosition(xPos + width + 1, yPos + i);
            Console.WriteLine("║");
        }
        Console.SetCursorPosition(xPos + (width/2), yPos + (height/2)); //set cursor position to inside the cube to write room num
        Console.WriteLine(RoomNum()); //writes roomNum
        ChangeRoomNum(); //changes room num. Increases it by 1. Room Num is different from RoomID as it is respective to the number of rooms that currently exists rather than its direct identifier
        Console.SetCursorPosition(xPos, yPos + height + 1); //sets cursor to bottom of cube
        Console.WriteLine(cubeDashBot); //writes bottom part
    }
    public static void CreateDock(int xPos, int yPos, int width, int height) //exact same instance of createcube but only difference is cololr and internal text
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        cubeDashTop = "╔" + String.Concat(Enumerable.Repeat("═", width)) + "╗";
        cubeDashBot = "╚" + String.Concat(Enumerable.Repeat("═", width)) + "╝";
        Console.SetCursorPosition(xPos, yPos);

        Console.WriteLine(cubeDashTop);
        for (int i = 1; i < height + 1; i++)
        {
            Console.SetCursorPosition(xPos, yPos + i);
            Console.WriteLine("║");
            Console.SetCursorPosition(xPos + width + 1, yPos + i);
            Console.WriteLine("║");
        }
        Console.SetCursorPosition(xPos + 1, yPos + (height / 2));
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Docking Port");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(xPos, yPos + height + 1);
        Console.WriteLine(cubeDashBot);
    }
    public static void CreateSubRooms() //method to create sub rooms. process is as goes. Checks if section exists > if it does then how many rooms were created by the rand > create rooms based on different odds
    {
        if (topLeftExist == true) //if top left exists then
        {
            if (subRoomOne == 1) //if subroom is 1, it checks room chance to see which subroom is created. 2 options are possible
            {
                if (roomChance == 0) //if room chance is 0 then
                {
                    CreateCube(28, 10, 12, 6); //create cube is called
                    roomExists[2] = 1; //and subroom is set to exist
                }
                else if (roomChance == 1)
                {
                    CreateCube(45, 3, 14, 4);
                    roomExists[0] = 1;
                }
            }
            else if (subRoomOne == 2) // if both rooms are called then both rooms are created
            {
                CreateCube(28, 10, 12, 6);
                CreateCube(45, 3, 14, 4);
                roomExists[2] = 1;
                roomExists[0] = 1;
            }
        }
        if (botLeftExist == true) //if bottom left exists then >(repeat process as above)
        {
            if (subRoomThree == 1)
            {
                if (roomChance == 0)
                {
                    CreateCube(28, 21, 12, 6);
                    roomExists[6] = 1;
                }
                else if (roomChance == 1)
                {
                    CreateCube(46, 31, 12, 6);
                    roomExists[10] = 1;
                }
            }
            else if (subRoomThree == 2)
            {
                CreateCube(28, 21, 12, 6); // sub bot left left
                CreateCube(46, 31, 12, 6);
                roomExists[6] = 1;
                roomExists[10] = 1;
            }
        }
        if (subRoomTwo == 1) //since Top Right always exists only room chance is considered when sub room is 1
        {
            if (roomChance == 0)
            {
                CreateCube(66, 3, 14, 4);
                roomExists[1] = 1;
            }
            else if (roomChance == 1)
            {
                CreateCube(85, 10, 12, 6);
                roomExists[5] = 1;
            }
        }
        if (subRoomTwo == 2) //when subroom two is 2 then both are called
        {
            CreateCube(66, 3, 14, 4); //top right top
            CreateCube(85, 10, 12, 6);
            roomExists[1] = 1;
            roomExists[5] = 1;
        }
        if (subRoomFour == 1) //only one option exists for subroom 4
        {
            CreateCube(67, 31, 12, 6);
            roomExists[11] = 1;
        }
        CreateDock(85, 21, 12, 6); //dock is called and array is set to 1
        roomExists[9] = 1;

    }
    public static string RoomNum() //accessor string for current room num
    {
        Console.ForegroundColor = ConsoleColor.White;
        return "R" + roomNum;

    }
    public static void ChangeRoomNum() //mutator string for roomNum
    {
        roomNum++;
        Console.ForegroundColor = ConsoleColor.Blue;

    }
    public static void ResetRoomNum() //reset method from roomNum
    {
        roomNum = 0;
			

    }
    public static void ResetArray() //resets roomExists array for next ship using a for loop
    {
        for (int i = 0; i < roomExists.Length; i++)
        {
            roomExists[i] = 0;
        }
    }
    public static int ReturnArray(int index) //accessor method for roomExists
    {
        return roomExists[index];
    }
    public static int ReturnArrayLength() //accessor method for the length of roomExists
    {
        return roomExists.Length;
    }
    public static int ReturnXPos(int index) //accessor method for CubeXPos
    {
        return cubeXPos[index];
    }
    public static int ReturnYPos(int index) //accessor method for CubeYPos
    {
        return cubeYPos[index];
    }
}