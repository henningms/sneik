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
    /// SnakeView
    /// 
    /// Handles rendering of the Snake
    /// </summary>
    public class SnakeView : IGameView
    {
        /// <summary>
        /// Character representing the head of the snake
        /// </summary>
        private const string HeadChar = "@";

        /// <summary>
        /// Character representing the rest of the body
        /// </summary>
        private const string BodyChar = "O";

        /// <summary>
        /// Snake object used for rendering
        /// </summary>
        public Snake Snake { get; private set; }

        /// <summary>
        /// Remembers the last position of the tail
        /// so we can clear it out when rendering
        /// </summary>
        private Coord LastTail { get; set; }

        /// <summary>
        /// Color to use when rendering the snake
        /// </summary>
        private const ConsoleColor Color = ConsoleColor.Green;

        /// <summary>
        /// Initializes the view
        /// </summary>
        /// <param name="snake"></param>
        public SnakeView(Snake snake)
        {
            Snake = snake;
        }

        /// <summary>
        /// Draws all the parts of the snake
        /// </summary>
        public void Draw()
        {
            if (LastTail != null)
                Draw(LastTail, " ");

            for (var part = 0; part < Snake.Body.Count - 1; part++)
            {
                Draw(Snake.Body[part], BodyChar);
            }

            Draw(Snake.Head, HeadChar);

            LastTail = new Coord(Snake.Tail);
        }

        /// <summary>
        /// Draws a character at given position
        /// </summary>
        /// <param name="position">Coordinate where to draw the character</param>
        /// <param name="letter">Character to draw</param>
        private void Draw(Coord position, string letter)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = Color;
            Console.Write(letter);
        }
    }
}
