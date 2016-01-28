using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sneik.Utils
{
    /// <summary>
    /// Coordinate
    /// </summary>
    public class Coord
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        /// <summary>
        /// Create a new Coord object with the set coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Coord(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Create a new Coord object by copying values from an existing one
        /// </summary>
        /// <param name="other">The Coord object to copy from</param>
        public Coord(Coord other)
        {
            X = other.X;
            Y = other.Y;
        }

        /// <summary>
        /// Test whether two Coord objects are equal by comparing their coordinates
        /// </summary>
        /// <param name="obj">The other Coord object to compare it to</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Coord)obj);
        }

        /// <summary>
        /// Tests whether two Coord-objects are equal by comparing their coordinates
        /// </summary>
        /// <param name="other">The other Coord object to compare it to</param>
        /// <returns></returns>
        protected bool Equals(Coord other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// Automatically added by VS2012 in use of comparing checksums
        /// </summary>
        /// <returns>Hashcode/Checksum of object</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        /// <summary>
        /// Static method for generating a random coordinate in a given
        /// cooridinate-system
        /// </summary>
        /// <param name="width">Width of boundary</param>
        /// <param name="height">Height of boundary</param>
        /// <returns></returns>
        public static Coord GenerateRandomCoord(int width, int height)
        {
            var randomGenerator = new Random();

            return new Coord(randomGenerator.Next(width), randomGenerator.Next(height));
        }
    }
}
