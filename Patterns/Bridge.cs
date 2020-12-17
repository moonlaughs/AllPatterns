namespace Patterns
{
    //<--structural

    // The "abstraction" defines the interface for the "control"
    // part of the two class hierarchies. It maintains a reference
    // to an object of the "implementation" hierarchy and delegates
    // all of the real work to this object.
    public class RemoteControlAbstraction
    {
        protected IDevice _devide;

        public RemoteControlAbstraction(IDevice device)
        {
            _devide = device;
        }

        public void TogglePower()
        {
            if(_devide.IsEnabled())
            {
                _devide.Disable();
            }
            else
            {
                _devide.Enabled();
            }
        }

        public void VolumeUp()
        {
            _devide.SetVolume(_devide.GetVolume() + 10);
        }

        public void VolumeDown()
        {
            _devide.SetVolume(_devide.GetVolume() - 10);
        }
    }

    // You can extend classes from the abstraction hierarchy
    // independently from device classes.
    public class AdvancedRemoteControl : RemoteControlAbstraction
    {
        public AdvancedRemoteControl(IDevice device) : base(device)
        {
        }

        public void Mute()
        {
            _devide.SetVolume(0);
        }
    }

    // The "implementation" interface declares methods common to all
    // concrete implementation classes. It doesn't have to match the
    // abstraction's interface. In fact, the two interfaces can be
    // entirely different. Typically the implementation interface
    // provides only primitive operations, while the abstraction
    // defines higher-level operations based on those primitives.
    public interface IDevice
    {
        void Disable();
        void Enabled();
        int GetVolume();
        bool IsEnabled();
        void SetVolume(int volume);
    }

    class TV : IDevice
    {
        bool isEnabled;
        public void Disable()
        {
            System.Console.WriteLine("TV disabled");
            isEnabled = false;
        }

        public void Enabled()
        {
            System.Console.WriteLine("TV enabled");
            isEnabled = true;
        }

        public int GetVolume()
        {
            return 20;
        }

        public bool IsEnabled()
        {
            return isEnabled;
        }

        public void SetVolume(int volume)
        {
            System.Console.WriteLine("TV Volume on: " + volume);
        }
    }

    public class Radio : IDevice
    {
         bool isEnabled;
        public void Disable()
        {
            System.Console.WriteLine("Radio disabled");
            isEnabled = false;
        }

        public void Enabled()
        {
            System.Console.WriteLine("Radio enabled");
            isEnabled = true;
        }

        public int GetVolume()
        {
            return 20;
        }

        public bool IsEnabled()
        {
            return isEnabled;
        }

        public void SetVolume(int volume)
        {
            System.Console.WriteLine("Radio Volume on: " + volume);
        }
    }

    public static class RunBridgePattern
    {
        public static void Run()
        {
            TV tv = new TV();
            RemoteControlAbstraction remote = new RemoteControlAbstraction(tv);
            remote.TogglePower();

            Radio radio = new Radio();
            AdvancedRemoteControl advancedRemote = new AdvancedRemoteControl(radio);
            advancedRemote.TogglePower();
            advancedRemote.Mute();

        }
    }
}