using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT_DEVICE_CONTROL_CONSOLE_APPLICATION
{
    class CompositeCommand : ICommand
    {
        private List<ICommand> commands = new List<ICommand>();

        public CompositeCommand(params ICommand[] cmds)
        {
            commands.AddRange(cmds);
        }

        public void Execute()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }
    }

}
