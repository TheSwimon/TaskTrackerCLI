﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services
{
    public class TaskRepository
    {
        public int HighestTaskId { get; set; }
        public List<MyTask> Tasks { get; set; }

        public TaskRepository()
        {
            Tasks = DeserializeJson();
            HighestTaskId = Tasks.MaxBy(task => task.TaskId)?.TaskId + 1 ?? 0;
        }

        public void SerializeTasks(List<MyTask> tasks)
        {
            TaskContainer taskContainer = new TaskContainer
            {
                Tasks = tasks
            };
            Tasks = tasks;

            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonFile = JsonSerializer.Serialize(taskContainer, options);
            File.WriteAllText(GetPath(), jsonFile);
        }

        public List<MyTask> DeserializeJson()
        {
            var tasksFilePath = GetPath();

            var jsonTasks = File.ReadAllText(tasksFilePath);
            TaskContainer? deserializedJson = JsonSerializer.Deserialize<TaskContainer>(jsonTasks);
            if (deserializedJson == null)
            {
                throw new InvalidOperationException("Coudln't deserialize json to specified type");
            }

            List<MyTask> tasks = deserializedJson.Tasks;

            if (tasks.Count > 0)
            {
                MyTask? task = tasks.MaxBy(task => task.TaskId);
                
                if (task != null)
                {
                    HighestTaskId = task.TaskId;
                } 
            }

            Tasks = tasks;

            return tasks;
        }

        private string GetPath()
        {
            string baseDirectory = Directory.GetCurrentDirectory();

            string? rootPath = Directory.GetParent(baseDirectory)?.Parent?.Parent?.FullName;
            var jsonFilePath = Path.Combine(rootPath!, "Data", "Tasks.json");
            if (!File.Exists(jsonFilePath))
            {
                File.WriteAllText(jsonFilePath, @"{""Tasks"": []}");
            }
            return jsonFilePath;
        }
    }
}
