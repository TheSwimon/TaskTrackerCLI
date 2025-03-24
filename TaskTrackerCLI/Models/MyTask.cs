using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerCLI.Models
{
    public class MyTask
    {
        // TaskId should be immutable after initialization, make setter private.
        public int TaskId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public override string ToString()
        {
            return $"TaskId: {TaskId}\nDescription: {Description}\nStatus: {Status}\nCreatedAt: {CreatedAt}\nUpdatedAt: {UpdatedAt}\n";
    }
    }
}
