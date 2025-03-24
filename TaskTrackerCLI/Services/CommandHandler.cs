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
        private readonly Dictionary<string, Delegate> commandHandlers;

        public CommandHandler()
        {
            _taskService = new TaskService();

            commandHandlers = new Dictionary<string, Delegate>
            {
                {"add", _taskService.AddTask },
                {"update", _taskService.UpdateTask },
                {"delete", _taskService.DeleteTask },
                {"mark-in-progress", (Action<string[]>)(args => _taskService.UpdateStatus("in-progress",args)) },
                {"mark-done", (Action<string[]>)(args => _taskService.UpdateStatus("done",args)) },
                {"list", _taskService.GetTasks },
                {"/help", HelpCommands }
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

            if (commandHandlers.TryGetValue(command, out Delegate handler))
            {
                if (handler is Action<string[]> argHandler)
                {
                    argHandler(commandArgs);
                }
                else if (handler is Action noArgHandler)
                {
                    noArgHandler();
                }
                return true;
            }
            else
            {
                Console.WriteLine(@"Unrecognized command, Enter ""/help"" for instructions.");
                return false;
            }
        }


        public void HelpCommands()
        {
            Console.WriteLine($"# Adding a new task\r\ntasktrackercli add \"Buy groceries\"\r\n# Output: Task added successfully (ID: 1)\r\n\r\n# Updating and deleting tasks\r\ntasktrackercli update 1 \"Buy groceries and cook dinner\"\r\ntasktrackercli delete 1\r\n\r\n# Marking a task as in progress or done\r\ntasktrackercli mark-in-progress 1\r\ntasktrackercli mark-done 1\r\n\r\n# Listing all tasks\r\ntasktrackercli list\r\n\r\n# Listing tasks by status\r\ntasktrackercli list done\r\ntasktrackercli list todo\r\ntasktrackercli list in-progress");
        }

    }
}
