using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskTrackerCLI.Services
{
    public class CommandHandler
    {
        private readonly TaskService _taskService;
        private readonly Dictionary<string, Action<string[]>> commandHandlers;

        public CommandHandler()
        {
            _taskService = new TaskService();

            commandHandlers = new Dictionary<string, Action<string[]>>
            {
                {"add", _taskService.AddTask },
                {"update", _taskService.UpdateTask },
                {"delete", _taskService.DeleteTask },
                {"mark-in-progress", args => _taskService.UpdateStatus("in-progress",args) },
                {"mark-done", args => _taskService.UpdateStatus("done",args) },
                {"list", _taskService.GetTasks }
            };
        }

        public bool ExecuteCommand(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine(@"Unrecognized command, Enter ""\help"" for instructions.");
                return false;
            }

            var command = args[0];
            string[] commandArgs = args.Skip(1).ToArray();

            if (commandHandlers.TryGetValue(command, out Action<string[]> handler))
            {
                handler(commandArgs);
                return true;
            }
            else
            {
                Console.WriteLine(@"Unrecognized command, Enter ""\help"" for instructions.");
                return false;
            }
        }

    }
}
