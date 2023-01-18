namespace Midnight_Ravens;

public class Animations
{
    int counter; //simple int counter to keep track of moving dots

    //Following animation Code was Adapted:
    //Author: João Lebre
    //Site: https://gist.github.com/jplebre/fc2979cf2d1f23f93c89
    public Animations()
    {
        counter = 0; //sets counter to 0
        Console.SetWindowSize(150, 50); //sets console size
        Console.ForegroundColor = ConsoleColor.Cyan; //sets console font color

    }
    public void Counter() //mutator method that increases count
    {
        counter++;
    }
    public int GetCounter() //accessor method that gives counter back
    {
        return counter;
    }
    public void LoadingBar(string loadingTest, int row, int column) //method that mimics a loading bar but was changed to display dots
    {
        Console.SetCursorPosition(column, row); //set cursor to parameters
        string loadingText = loadingTest; //set text to paramets
        Console.Write(loadingText); //write text

        for (int i = 0; i < counter % 12; i++)
        {
            if (counter == 0) //if counter is 0 write loading text at set positions. 
            {
                Console.SetCursorPosition(column, row);
                Console.Write(loadingText);
            }

            Console.SetCursorPosition(loadingText.Length + i, row);//change cursor position and increase each loop
            Console.Write("."); //write in a period(.)
        }
    }
    public static void StartScreen()//method to start off the game
    {
        Animations spin = new Animations();//calling a new animation
        string[] loadingText = { "Initializing Software", "Seeking Connection", "Securing Connection", "Finalizing" }; //string array to ease the use of using multiple animations
        string userInput; //userInput storage variable
        Console.CursorVisible = false; //set cursor to false for prettier animation
			
        for (int i = 0; i < 4; i++) //for loop that runs through the initial animation through the array and increases the y each time to seperate the lines
        {
            for (int j = 0; j < 12; j++) {
                spin.LoadingBar(loadingText[i], i, 0);
                spin.Counter();
                System.Threading.Thread.Sleep(100);
            }
        }
        Console.WriteLine(""); //title displayed with options
        Console.WriteLine("");
        Console.WriteLine("		███╗   ███╗██╗██████╗ ███╗   ██╗██╗ ██████╗ ██╗  ██╗████████╗    ██████╗  █████╗ ██╗   ██╗███████╗███╗   ██╗███████╗");
        Console.WriteLine("		████╗ ████║██║██╔══██╗████╗  ██║██║██╔════╝ ██║  ██║╚══██╔══╝    ██╔══██╗██╔══██╗██║   ██║██╔════╝████╗  ██║██╔════╝");
        Console.WriteLine("		██╔████╔██║██║██║  ██║██╔██╗ ██║██║██║  ███╗███████║   ██║       ██████╔╝███████║██║   ██║█████╗  ██╔██╗ ██║███████╗");
        Console.WriteLine("		██║╚██╔╝██║██║██║  ██║██║╚██╗██║██║██║   ██║██╔══██║   ██║       ██╔══██╗██╔══██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║╚════██║");
        Console.WriteLine("		██║ ╚═╝ ██║██║██████╔╝██║ ╚████║██║╚██████╔╝██║  ██║   ██║       ██║  ██║██║  ██║ ╚████╔╝ ███████╗██║ ╚████║███████║");
        Console.WriteLine("		╚═╝     ╚═╝╚═╝╚═════╝ ╚═╝  ╚═══╝╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝       ╚═╝  ╚═╝╚═╝  ╚═╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝╚══════╝");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Select an Option. Type The Number And Press Enter:");
        Console.WriteLine("1.) Initiate Drone Program");
        Console.WriteLine("2.) Tutorial");
        Console.WriteLine("3.) Program Credits");
        Console.CursorVisible = true;
        userInput = Console.ReadLine(); //sets user Input to userInput
        if (userInput == "1") //if user inputs a 1 then continue on to show system
        {
            Galaxy.ShowSystem();

        }
        else if(userInput == "3") //if user inputs a 3 then displays my name and info
        {
            Console.WriteLine("Made by G.Rodriguez. C. 2020.");
            System.Threading.Thread.Sleep(50000);
            Console.WriteLine("Restarting");
            System.Threading.Thread.Sleep(5000);
            Console.Clear(); //clears screen and starts the screen again
            Animations.StartScreen();
        }
        else if (userInput == "2")//if user inputs a 3 then displays a rather rude help message for the next menu
        {
            Console.WriteLine("You Should Have Learned This In Training. Restarting.");
            System.Threading.Thread.Sleep(10000);
            Console.Clear();
            Animations.StartScreen();
        }
        else //if a command is not recognized then input is denied and scene is restarted.
        {
            Console.WriteLine("Input Denied. Restarting");
            System.Threading.Thread.Sleep(500);
            Console.Clear();
            Animations.StartScreen();
        }
    }
}