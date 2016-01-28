using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sneik.Controllers.Input;

namespace Sneik.Controllers
{
    /// <summary>
    /// InputManager
    /// 
    /// Keeps track of all input devices and provides easy methods
    /// to query input-devices for data
    /// </summary>
    public class InputManager
    {
        /// <summary>
        /// List of all devices currently tracking
        /// </summary>
        private IList<InputDevice> Devices { get; set; } 

        /// <summary>
        /// Initializes the input manager
        /// </summary>
        public InputManager()
        {
            Devices = new List<InputDevice>();
        }

        /// <summary>
        /// Adds a new input device
        /// </summary>
        /// <param name="device">An input device extending InputDevice</param>
        public void AddInputDevice(InputDevice device)
        {
            Devices.Add(device);
        }

        /// <summary>
        /// Checks to see if any device has any input available for
        /// grabbing
        /// </summary>
        /// <returns>True or false whether any device has input available</returns>
        public bool IsInputAvailable()
        {
            return Devices.Any(device => device.InputAvailable());
        }

        /// <summary>
        /// Checks to see if a device of given type has any input
        /// available for grabbing
        /// </summary>
        /// <typeparam name="T">Class repsrenting an input device. Has to inherit from InputDevice</typeparam>
        /// <returns></returns>
        public bool IsInputAvailable<T>() where T : InputDevice
        {
            return Devices.Any(device => device.InputAvailable() && device.GetType() == typeof (T));
        }

        /// <summary>
        /// Gets the input data from the first device that has input available
        /// </summary>
        /// <returns>The input data</returns>
        public object GetInput()
        {
            return Devices.First(device => device.InputAvailable()).GetInput();
        }

        /// <summary>
        /// Gets the input data from the first device of a given type
        /// that has any input available
        /// </summary>
        /// <typeparam name="T">Class representing an input device. Has to inherit from InputDevice</typeparam>
        /// <returns></returns>
        public object GetInput<T>() where T : InputDevice
        {
            return Devices.First(device => device.InputAvailable() && device.GetType() == typeof (T)).GetInput();
        }
    }
}
