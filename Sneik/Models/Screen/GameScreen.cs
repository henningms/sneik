using System;

namespace Sneik.Models.Screen
{
    /// <summary>
    /// Abstract class describing a display
    /// </summary>
    public abstract class GameScreen
    {
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
    }
}
