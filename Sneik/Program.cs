using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Sneik.Controllers;
using Sneik.Enumerations;
using Sneik.Models;
using Sneik.Utils;

namespace Sneik
{
    class Program
    {
        static void Main(string[] args)
        {
            // Makes a new instance of our game engine
            var gameEngine = new GameEngine();

            // Starts the game
            gameEngine.StartGame();
        }
    }
}
