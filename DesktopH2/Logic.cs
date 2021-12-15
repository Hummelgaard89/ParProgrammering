using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesktopH2
{
    class Logic
    {
        public static DateTime CurrentDateTime = DateTime.Now;
        public static DateTime EndDateTime = new DateTime();
        public static int HourIntervalPicked = 0;

        DalManager manager = new DalManager();
        //The running method, check if the time is up, if not it waits 5 min, t
        public void RunningProgram()
        {
            bool dateCheck = false;
            while (true)
            {
                while (dateCheck == false)
                {
                    if (CurrentDateTime <= EndDateTime)
                    {
                        manager.GetFilesFromDirectory();
                        dateCheck = true;
                    }
                    else
                    {
                        Thread.Sleep(300000);
                    }
                }
                EndDateTime = DateTime.Now.AddHours(HourIntervalPicked);
                dateCheck = false;
            }
        }
        public bool ValidDirectory(string input)
        {
            //Checks to see if the userinput directory is valid path, returns true
            if (manager.CheckDirectory(input))
            {
                return true;
            }
            //Otherwise return false and sends error message
            else
            {
                GUI.ErrorMessage($"{input} is not a valid file or directory.");
                return false;
            }
        }
        public void SetInterval(string userinput)
        {
            //Gets userinput and sets the HourInterval and endtime
            switch (userinput)
            {
                case "1":
                    HourIntervalPicked = 2;
                    EndDateTime = DateTime.Now.AddHours(HourIntervalPicked);
                    break;
                case "2":
                    HourIntervalPicked = 24;
                    EndDateTime = DateTime.Now.AddHours(HourIntervalPicked);
                    break;
                case "3":
                    HourIntervalPicked = 168;
                    EndDateTime = DateTime.Now.AddDays(HourIntervalPicked);
                    break;
            }
        }
    }
}
