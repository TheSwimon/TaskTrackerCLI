using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerCLI.Models;

public class TaskContainer
{
    public List<MyTask> Tasks { get; set; } = new();
}
