# Task Tracker CLI
example implementation for the [task-tracker-cli](https://roadmap.sh/projects/task-tracker) challenge from [Roadmap.sh](roadmap.sh).

## Features
- **Add a task** - Add a new task to the json data storage.
- **Update a task description** - Update the description of an existing task.
- **Delete a task** - Delete an existing task.
- **Update a task status** - update the status of an existing task to one of the following statuses ("todo","in-progress","done").
- **List** - list all tasks or filter by status.


## Install
Clone the repository

```bash
git clone https://github.com/TheSwimon/TaskTrackerCLI.git
```

Navigate to the project directory and build
```bash
cd TaskTrackerCLI
dotnet build
```

Navigate to the output directory and run the project using task-tracker commands.
```bash
cd \bin\debug\net8.0
TaskTrackerCLI add "Example task" 
# Task has been added successfully.
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
