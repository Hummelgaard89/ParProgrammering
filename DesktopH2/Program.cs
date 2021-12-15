using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using Microsoft.Win32;

namespace DesktopH2
{
    class Program
    {
        static void Main(string[] args)
        {
            GUI gUI = new GUI();
            gUI.StartMenu();
        }
    }
}