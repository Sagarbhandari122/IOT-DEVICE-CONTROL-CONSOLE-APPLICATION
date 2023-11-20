using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_DEVICE_CONTROL_CONSOLE_APPLICATION.IoT_Devices
{
    // Receiver class for Light
    class Light
    {
        private bool isOn;

        public void TurnOn()
        {
            isOn = true;
            Console.WriteLine("Light is ON");
        }

        public void TurnOff()
        {
            isOn = false;
            Console.WriteLine("Light is OFF");
        }
        public string GetStatus()
        {
            return $"Light is {(isOn ? "ON" : "OFF")}";
        }


    }
    // Concrete Command for turning on the light
    class LightOnCommand : ICommand
    {
        private Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }
    }

    // Concrete Command for turning off the light
    class LightOffCommand : ICommand
    {
        private Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOff();
        }
    }
   
}
