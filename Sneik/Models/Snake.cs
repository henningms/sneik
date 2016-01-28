using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sneik.Enumerations;
using Sneik.Utils;

namespace Sneik.Models
{
    /// <summary>
    /// Snake
    /// 
    /// Class describing a snakes properties
    /// </summary>
    public class Snake
    {
        /// <summary>
        /// Gets or sets the current direction the Snake is heading
        /// </summary>
        private Direction Direction { get; set; }

        /// <summary>
        /// Returns all bodyparts
        /// </summary>
        public List<Coord> Body { get; private set; }

        /// <summary>
        /// Return the head of the snake
        /// </summary>
        public Coord Head
        {
            get { return Body.Last(); }
        }

        /// <summary>
        /// Return the tail of the snake
        /// </summary>
        public Coord Tail
        {
            get { return Body.First(); }
        }

        /// <summary>
        /// Return the size of our snake
        /// </summary>
        public int Size
        {
            get { return Body.Count; }
        }

        /// <summary>
        /// Returns all bodyparts except the head
        /// </summary>
        public IList<Coord> BodyWithoutHead
        {
            get { return Body.Take(Body.Count - 1).ToList();  }
        }

        /// <summary>
        /// Snake object
        /// </summary>
        /// <param name="initialDirection">The initial direction our snake is moving</param>
        /// <param name="initialPosition">Coordinate of start position</param>
        public Snake(Direction initialDirection, params Coord[] initialCoordinates)
        {
            if (initialCoordinates.Length <= 0)
                throw new ArgumentException("At least 1 point is mandatory for the snake", "initialCoordinates");

            Body = new List<Coord>();
            Direction = initialDirection;

            Body.AddRange(initialCoordinates);
        }

        /// <summary>
        /// Move our snake in its current direction
        /// </summary>
        public void Move()
        {
            Move(Direction);
        }

        /// <summary>
        /// Move our snake in a new direction
        /// </summary>
        /// <param name="newDirection">The new direction</param>
        public void Move(Direction newDirection)
        {
            Body.RemoveAt(0);

            Body.Add(NewCoordFromDirection(Head, newDirection));
        }

        /// <summary>
        /// Changes the direction of the snake if direction isn't the opposite of
        /// current direction
        /// </summary>
        /// <param name="newDirection">The new direction</param>
        public void ChangeDirection(Direction newDirection)
        {
            switch (newDirection)
            {
                case Direction.Left:
                    Direction = (Direction != Direction.Right) ? newDirection : Direction;
                    break;
                case Direction.Right:
                    Direction = (Direction != Direction.Left) ? newDirection : Direction;
                    break;
                case Direction.Up:
                    Direction = (Direction != Direction.Down) ? newDirection : Direction;
                    break;
                case Direction.Down:
                    Direction = (Direction != Direction.Up) ? newDirection : Direction;
                    break;
            }
        }
        /// <summary>
        /// Grow our snake by one part
        /// </summary>
        public void Grow()
        {
            Grow(1);
        }

        /// <summary>
        /// Grow our snake a specific number of times
        /// </summary>
        public void Grow(int times)
        {
            for (var i = 0; i < times; i++)
                Body.Add(NewCoordFromDirection(Head, Direction));
        }

        /// <summary>
        /// Generates a new coordinate based on given coordinate and
        /// direction
        /// </summary>
        /// <param name="last">Coordinate to base the next coordinate from</param>
        /// <param name="direction">The direction of the new coordinate</param>
        /// <returns></returns>
        private Coord NewCoordFromDirection(Coord last, Direction direction)
        {
            var newX = last.X;
            var newY = last.Y;

            switch (direction)
            {
                case Direction.Up:
                    newY -= (Direction != Direction.Down) ? 1 : 0;
                    break;
                case Direction.Down:
                    newY += (Direction != Direction.Up) ? 1 : 0;
                    break;
                case Direction.Left:
                    newX -= (Direction != Direction.Right) ? 1 : 0;
                    break;
                case Direction.Right:
                    newX += (Direction != Direction.Left) ? 1 : 0;
                    break;
            }

            return new Coord(newX, newY);
        }
    }
}
