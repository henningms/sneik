using System;

namespace Sneik.Controllers.Input.Devices
{
    /// <summary>
    /// KeyboardInputDevice inherits from InputDevice and provides
    /// the necessary function to check and get input from a regular
    /// keyboard
    /// </summary>
    public class KeyboardInputDevice : InputDevice
    {
        /// <summary>
        /// Checks if the input device has available data
        /// </summary>
        /// <returns>True or false given data available</returns>
        public override bool InputAvailable()
        {
            return Console.KeyAvailable;
        }

        /// <summary>
        /// Collects and returns the input data
        /// </summary>
        /// <returns>An object of type ConsoleKeyInfo describing the key and state</returns>
        public override object GetInput()
        {
            return InputAvailable() ? (object) Console.ReadKey(true) : null;
        }
    }
}
