using System;

namespace Sneik.Models.Screen
{
    /// <summary>
    /// Console Game Screen
    /// 
    /// Sets up the necessary display for use and gets/sets
    /// necessary information about the display
    /// </summary>
    public class ConsoleGameScreen : Screen.GameScreen
    {
        public ConsoleGameScreen()
        {
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;
        }
    }
}
