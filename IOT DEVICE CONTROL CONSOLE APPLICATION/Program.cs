using IOT_DEVICE_CONTROL_CONSOLE_APPLICATION.IoT_Devices;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_DEVICE_CONTROL_CONSOLE_APPLICATION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initiating the light object and Thermostat object.
            Light light = new Light();
            Thermostat thermostat = new Thermostat();

            // All of the Commands.
            LightOnCommand lightOn = new LightOnCommand(light);
            LightOffCommand lightOff = new LightOffCommand(light);
            ThermostatIncreaseCommand increaseTemp = new ThermostatIncreaseCommand(thermostat);
            ThermostatDecreaseCommand decreaseTemp = new ThermostatDecreaseCommand(thermostat);

            // Displaying the default status of the light and thermostat in the console.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Default Status of Light and thermostat:");
            Console.WriteLine(light.GetStatus() + "\n" + thermostat.GetStatus() + "\n");
            Console.ResetColor();
            RemoteController remote = new RemoteController();

            Dictionary<int, ICommand> remoteKeysMap = new Dictionary<int, ICommand>
            {
                {1, lightOn },
                {2, lightOff },
                {3, increaseTemp },
                {4, decreaseTemp },
            };
            Console.WriteLine("Button's are as follow:" + "\n1: Turns Light On" + "\n2: Turns Light Off"
                + "\n3: Increase Temperature of Thermostat" + "\n4: Decrease Temperature of Thermostat \n<Enter> or Esc to exit program\n");

            while (true)
            {
                Console.Write("Press button (1-4): ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape || keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (int.TryParse(keyInfo.KeyChar.ToString(), out int key))
                {
                    if (remoteKeysMap.TryGetValue(key, out var command))
                    {
                        remote.SetCommand(command);
                        Console.WriteLine("\nYou pressed button {0}.", key);
                        remote.PressButton();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("CURRENT STATUS:\n" + light.GetStatus() + "\n" + thermostat.GetStatus() + "\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("\nThe key doesn't exist in the remote. Please input a valid key.");
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease input a valid integer.");
                }
            }
        }
    }

}
