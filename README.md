# Todotext Manager
Todotext Manager is a system for management tasks. The base concept of todo list model is from todo.txt. Native todo.txt is very simple and useful, however, it can be complex if each task contain extra information (e.g. timestamp of add task, tags, memos and etc...). Such kind of information decrease readbility of the list.
Todotext Manager helps to write the todo list and manages the list with the task details. 

## Command
todolist \<command\> [\<args\>]

If you type "todolist" without any args or sub commands, tasks stored in list file will be displayed.

These are sub commands:  
| command | |
| :---: | :--- |
| add | Add tasks to a list |
| done | Change status of a task done |
| cancel | Change status of a task cancel. This command may be used in case the task no longer need to do |

## Task list file format
Tasks are stored in a text file named "todolist". The format of them is bellow.

[status] [task add time] [task finished time] [title] [tags]

e.g.  
x 2019-07-06-11:00 2019-07-06-17:32 buy milk @private  
&nbsp;&nbsp;2019-07-06-11:01 check web server log

| Label | Value | Detail |
|:--- |:---|:---|
| status | 'x', '-' or blank | status of a task. |
| task add time | timestamp (e.g. 2019-01-01-16:00) | timestamp that a task is add to list |
| task finished time | timestamp (e.g. 2019-01-01-16:00) | timestamp that a task was finished |
| title | string | title of task |
| tags | string | tags for classification of tasks |