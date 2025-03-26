# Task Tracker CLI
Task Tracker CLI is a command line tool, that helps with managing tasks effiiently, using JSON file storage. Clients can Add, Update, Delete and List the tasks from the CLI, utilizing commands.

Example implementation for the [task-tracker-cli](https://roadmap.sh/projects/task-tracker) challenge from [Roadmap.sh](roadmap.sh).

## Features
- **Add a task** - Add a new task to the json data storage.
- **Update a task description** - Update the description of an existing task.
- **Delete a task** - Delete an existing task.
- **Update a task status** - Update the status of an existing task, e.g. "in-progress","done".
- **List** - List all tasks or filter by status.


## Install
Clone the repository & Navigate to the project directory

```bash
git clone https://github.com/TheSwimon/TaskTrackerCLI.git
cd TaskTrackerCLI
```

Run the CLI tool using dotnet run
```bash
dotnet run -- add "example task"
# Task added successfully (ID 0)
```

## Command Examples
```cli
# Adding a new task
TaskTrackerCLI add "Buy groceries"
# Output: Task added successfully

# Updating and deleting tasks
TaskTrackerCLI update 1 "Buy groceries and cook dinner"
TaskTrackerCLI delete 1

# Marking a task as in progress or done
TaskTrackerCLI mark-in-progress 1
TaskTrackerCLI mark-done 1

# Listing all tasks
TaskTrackerCLI list

# Listing tasks by status
TaskTrackerCLI list done
TaskTrackerCLI list todo
TaskTrackerCLI list in-progress
```
