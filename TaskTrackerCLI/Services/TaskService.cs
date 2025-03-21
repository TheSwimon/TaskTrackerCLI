using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services
{
    public class TaskService
    {

        private readonly TaskRepository _taskRepository;

        public TaskService()
        {
            _taskRepository = new TaskRepository();
        }

        public void AddTask(string[] commandArgs)
        {

            if (commandArgs.Length != 1)
            {
                Console.WriteLine($"Invalid argument for \"add\" command\nCorrect usage: add \"example text\"");
                return;
            }


            MyTask newTask = new MyTask
            {
                TaskId = _taskRepository.HighestTaskId,
                Description = commandArgs[0],
                Status = "todo",
                createdAt = DateTime.Now,
                updatedAt = null
            };

            _taskRepository.Tasks.Add(newTask);
            _taskRepository.SerializeTasks(_taskRepository.Tasks);

            Console.WriteLine("task added successfully");
        }


        public void UpdateTask(string[] commandArgs)
        {
            if (commandArgs.Length != 2)
            {
                Console.WriteLine($"Invalid arguments for \"update\" command\nCorrect usage: update 2 \"example text\"");
                return;
            }

            if (!int.TryParse(commandArgs[0], out _)) 
            {
                Console.WriteLine($"Invalid id\nCorrect usage: update 2 \"example text\"");
                return;
            }

            MyTask? task = _taskRepository.Tasks.Find(task => task.TaskId == int.Parse(commandArgs[0]));

            if (task==null)
            {
                Console.WriteLine("Couldn't find task with specified id");
                return;
            }

            task.Description = commandArgs[1];
            task.updatedAt = DateTime.Now;
            _taskRepository.SerializeTasks(_taskRepository.Tasks);
            Console.WriteLine("task updated successfully");
        }


        public void UpdateStatus(string status, string[] commandArgs)
        {

            if (status != "done" && status != "in-progress")
            {
                Console.WriteLine("Invalid status");
                return;
            } 

            if (commandArgs.Length!=1)
            {
                Console.WriteLine("unrecognized command");
                return;
            }


            Boolean isInteger = int.TryParse(commandArgs[0], out int index);

            if (!isInteger)
            {
                Console.WriteLine(@"Invalid id\nCorrect usage: update 2 ""example text""");
                return;
            }

            MyTask? task = _taskRepository.Tasks.Find(task => task.TaskId == index);

            if (task == null)
            {
                Console.WriteLine("Couldn't find task with specified id");
                return;
            }

            task.Status = status;
            task.updatedAt = DateTime.Now;
            _taskRepository.SerializeTasks(_taskRepository.Tasks);
            Console.WriteLine("task updated successfully");
        }

        public void DeleteTask(string[] commandArgs)
        {
           if (commandArgs.Length!=1)
            {
                Console.WriteLine("Invalid argument for Delete command\nCorrect Usage: Delete 2");
            }

            Boolean isInteger = int.TryParse(commandArgs[0], out int index);

           if (!isInteger)
            {
                Console.WriteLine("Invalid id\nCorrect usage: Delete 2");
            }

            MyTask? task = _taskRepository.Tasks.Find(task => task.TaskId == index);
            if (task == null)
            {
                Console.WriteLine("couldn't find task with specified id");
                return;
            }

            _taskRepository.Tasks.Remove(task);
            _taskRepository.SerializeTasks(_taskRepository.Tasks);
            Console.WriteLine("task removed successfully");
        }

        public void GetTasks(string[] commandArgs)
        {
            List<string> statuses = new List<string> { "done", "todo", "in-progress" };
            List<MyTask> tasks = new();

            if (commandArgs.Length>1)
            {
                Console.WriteLine("Unrecognized command");
                return;
            }

            if (commandArgs.Length==1)
            {
                if (statuses.Contains(commandArgs[0]))
                {
                    tasks = _taskRepository.Tasks.Where(task => task.Status == commandArgs[0]).ToList();
                } else
                {
                    Console.WriteLine("Invalid status code");
                    return;
                }
            }

            if (commandArgs.Length==0)
            {
                tasks = _taskRepository.Tasks;
            }

            foreach(MyTask task in tasks)
            {
                Console.WriteLine(task);
            }
        }
    }
}
