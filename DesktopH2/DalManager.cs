using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DesktopH2
{
    class DalManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
           UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 20;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;
        private static Random rnd = new Random(Guid.NewGuid().GetHashCode());
        //String to save once the directory if validated, to use over and over again.
        private static string DirectoryExist = "";

        //Checks if the user input is a valid path, if not an error message is shown.
        public bool CheckDirectory(string userDirectory)
        {
            if (Directory.Exists(userDirectory))
            {
                DirectoryExist = userDirectory;
                return true;
                //Method to go trough files.
            }
            else
            {
                return false;
            }
        }

        //Makes an array of strings of the file paths in the given directory.
        public void GetFilesFromDirectory()
        {
            string[] files = Directory.GetFiles(DirectoryExist);
            PickBackground(files);
        }

        //Method that picks a random files from the directory picked by the user.
        public void PickBackground(string[] files)
        {
            string pickedBackground = files[rnd.Next(0, files.Length)];
            SetWallpaper(pickedBackground);
        }

        //Sets the wallpaper to the random given file, chosen by the method "PickBackground
        public void SetWallpaper(String path)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            key.SetValue(@"WallpaperStyle", 0.ToString()); // 2 is stretched
            key.SetValue(@"TileWallpaper", 0.ToString());
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}
