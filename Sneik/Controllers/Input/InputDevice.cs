namespace Sneik.Controllers.Input
{
    /// <summary>
    /// Abstract class describing an input device (such as keyboards, mice, gamepads
    /// etc..) and minimum methods for interoperability
    /// </summary>
    public abstract class InputDevice
    {
        public abstract bool InputAvailable();
        public abstract object GetInput();
    }
}
