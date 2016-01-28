using System.Collections.Generic;
using System.Linq;
using Sneik.Models.Screen;
using Sneik.Utils;

namespace Sneik.Models
{
    /// <summary>
    /// Apple
    /// 
    /// Class describing an Apple for the Snake to eat
    /// </summary>
    public class Apple
    {
        /// <summary>
        /// Defines how many instances to create
        /// before reusing them
        /// </summary>
        private const int ApplesCached = 5;

        /// <summary>
        /// Tracker of what element to reuse next
        /// </summary>
        private static int _appleToUse;

        /// <summary>
        /// Factory pool
        /// </summary>
        private static IList<Apple> _apples = new List<Apple>(ApplesCached);

        /// <summary>
        /// Position of the Apple
        /// </summary>
        public Coord Position { get; set; }

        /// <summary>
        /// Generates a new apple based on X and Y values
        /// </summary>
        /// <param name="x">X position of new apple</param>
        /// <param name="y">Y position of new apple</param>
        private Apple(int x, int y) : this(new Coord(x, y))
        {
            
        }

        /// <summary>
        /// Generates a new apple based on a Coord-object
        /// </summary>
        /// <param name="position">Coord-object representing the position</param>
        private Apple(Coord position)
        {
            Position = position;
        }

        /// <summary>
        /// Creates a new apple or reuses an old apple-object
        /// if the cache-pool is full
        /// </summary>
        /// <param name="position">Coord-object representing the coordinate of the new Apple</param>
        /// <returns>New or reused Apple-object</returns>
        public static Apple Create(Coord position)
        {
            if (_apples.Count < ApplesCached)
            {
                _apples.Add(new Apple(position));
                return _apples.Last();
            }
            else
            {
                if (_appleToUse >= ApplesCached)
                    _appleToUse = 0;

                var apple = _apples[_appleToUse++];
                apple.Position = position;

                return apple;
            }
        }
    }
}
