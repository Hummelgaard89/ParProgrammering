using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopH2
{
    public class GUI
    {
        Logic logic = new Logic();
        //The starting menu of the program.
        public void StartMenu()
        {
            Console.WriteLine("Welcome to background changer");
            Console.WriteLine("First write your directory path");
            logic.ValidDirectory(Console.ReadLine());
            PickTimeInterval();
            Menu();
        }
        public void Menu()
        {
            logic.RunningProgram();
        }
        //Method to write error messages.
        public static void ErrorMessage(string input)
        {
            Console.WriteLine(input);
        }
        //Method to pick the given timeinterval in which you want the background to change.
        public void PickTimeInterval()
        {
            Console.WriteLine("Select Time Interval");
            Console.WriteLine("1. 2 Hours\n2. 1 Day\n3. 7 days");
            logic.SetInterval(Console.ReadLine());
        }
    }
}
