using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_DEVICE_CONTROL_CONSOLE_APPLICATION.IoT_Devices
{
    internal class Thermostat
    {
        private int temperature = 20;

        public void IncreaseTemperature()
        {
            temperature++;
            Console.WriteLine($"Thermostat temperature increased to {temperature}");
        }

        public void DecreaseTemperature()
        {
            temperature--;
            Console.WriteLine($"Thermostat temperature decreased to {temperature}");
        }

        public string GetStatus()
        {
            return $"Thermostat temperature is {temperature}";
        }

    }

    // Concrete Command for increasing the thermostat temperature
    class ThermostatIncreaseCommand : ICommand
    {
        private Thermostat thermostat;

        public ThermostatIncreaseCommand(Thermostat thermostat)
        {
            this.thermostat = thermostat;
        }

        public void Execute()
        {
            thermostat.IncreaseTemperature();
        }
    }


    // Concrete Command for decreasing the thermostat temperature
    class ThermostatDecreaseCommand : ICommand
    {
        private Thermostat thermostat;

        public ThermostatDecreaseCommand(Thermostat thermostat)
        {
            this.thermostat = thermostat;
        }

        public void Execute()
        {
            thermostat.DecreaseTemperature();
        }
    }
    
}
