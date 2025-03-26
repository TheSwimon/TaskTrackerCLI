using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerCLI.Models;

public class MyTask
{
    // TaskId should be immutable after initialization, make setter private.
    public required int TaskId { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }


    public override string ToString()
    {
        return $"TaskId: {TaskId}\nDescription: {Description}\nStatus: {Status}\nCreatedAt: {CreatedAt}\nUpdatedAt: {UpdatedAt}\n";
}
}
