using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sneik.Models;
using Sneik.Utils;
using Sneik.Views.Interfaces;

namespace Sneik.Views
{
    /// <summary>
    /// AppleView
    /// 
    /// Handles rendering of an Apple object
    /// </summary>
    public class AppleView : IGameView
    {
        /// <summary>
        /// Character representing the Apple
        /// </summary>
        private const string AppleChar = "$";

        /// <summary>
        /// Apple object used for rendering
        /// </summary>
        public Apple Apple { get; private set; }

        /// <summary>
        /// Color to render the character with
        /// </summary>
        private const ConsoleColor Color = ConsoleColor.Red;

        /// <summary>
        /// The coordinate of the last apple so we can clear it out in case
        /// the apple object changes
        /// </summary>
        private Coord LastApple { get; set; }

        /// <summary>
        /// Initializes the view
        /// </summary>
        /// <param name="apple"></param>
        public AppleView(Apple apple)
        {
            Apple = apple;
        }

        /// <summary>
        /// Updates the view with a new apple object
        /// </summary>
        /// <param name="apple"></param>
        public void UpdateView(Apple apple)
        {
            Apple = apple;
        }

        /// <summary>
        /// Draws the apple on screen
        /// </summary>
        public void Draw()
        {
            if (LastApple != null)
            {
                Console.SetCursorPosition(LastApple.X, LastApple.Y);
                Console.Write(" ");
            }

            Console.SetCursorPosition(Apple.Position.X, Apple.Position.Y);
            Console.ForegroundColor = Color;
            Console.Write(AppleChar);

            LastApple = Apple.Position;
        }
    }
}
