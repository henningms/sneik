using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sneik.Models.Screen;

namespace Sneik.Utils
{
    /// <summary>
    /// 
    /// CollisionDetector
    /// 
    /// Generic helper method for detecting collisions between coordinates,
    /// coordinates and lists of coordinates and boundaries
    /// 
    /// </summary>
    public class CollisionDetector
    {
        /// <summary>
        /// Checks to see if two coordinates are the same
        /// </summary>
        /// <param name="objA">Coordinate of object a</param>
        /// <param name="objB">Coordinate of object b</param>
        /// <returns></returns>
        public static Boolean Detect(Coord objA, Coord objB)
        {
            return objA.Equals(objB);
        }

        /// <summary>
        /// Checks to see if a list of coordinates collides
        /// with coordinate objB
        /// </summary>
        /// <param name="objs">List of coordinates</param>
        /// <param name="objB">Coordinate to compare with</param>
        /// <returns></returns>
        public static Boolean Detect(IList<Coord> objs, Coord objB )
        {
            return objs.Any(x => x.Equals(objB));
        }

        /// <summary>
        /// Checks to see if a list of coordinates intersects
        /// with another list of objects
        /// </summary>
        /// <param name="objA">List of coordinates</param>
        /// <param name="objB">List of coordinates to compare with</param>
        /// <returns></returns>
        public static Boolean Detect(IList<Coord> objA, IList<Coord> objB)
        {
            return objA.Intersect(objB).Any();
        }

        /// <summary>
        /// Checks to see if a coordinate is colliding with the bounds of
        /// a game screen
        /// </summary>
        /// <param name="obj">Coordinate of object</param>
        /// <param name="screen">Display to compare with</param>
        /// <returns></returns>
        public static Boolean DetectBoundaries(Coord obj, GameScreen screen)
        {
            if (obj.X < 0 || obj.X >= screen.Width) return true;
            if (obj.Y < 0 || obj.Y >= screen.Height) return true;

            return false;
        }

        /// <summary>
        /// Checks to see if any coordinate in a list collides with the screen
        /// </summary>
        /// <param name="obj">List of coordinates</param>
        /// <param name="screen">Display to compare with</param>
        /// <returns></returns>
        public static Boolean DetectBoundaries(IList<Coord> obj, GameScreen screen)
        {
            return obj.Any(x => DetectBoundaries(x, screen));
        }
    }
}
