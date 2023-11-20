using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_DEVICE_CONTROL_CONSOLE_APPLICATION
{
    internal class RemoteController
    {
        private List<ICommand> commands = new List<ICommand>();

        public void SetCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void PressButton()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }

            commands.Clear();
        }
    }
}
