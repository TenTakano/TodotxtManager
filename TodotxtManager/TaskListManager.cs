// Copyright(c) 2019 TenTakano
// All rights reserved.
// See License in the project root for license information.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

using TaskList = System.Collections.Generic.List<TodotxtManager.TaskContainer>;

namespace TodotxtManager {
    public class TaskListManager {
        private string filePath = $"{Environment.CurrentDirectory}/todolist.xml";
        private TaskList taskList = new TaskList();

        /// <summary>
        /// Get todo list
        /// </summary>
        public IEnumerable<TaskContainer> TodoList {
            get {
                return this.taskList.Where(n => n.State == TaskState.Todo)
                        .OrderBy(n => n.Add);
            }
        }

        /// <summary>
        /// Get task list which have already finished by done or cancel method
        /// </summary>
        public IEnumerable<TaskContainer> FinishedList {
            get {
                return this.taskList.Where(n => n.State != TaskState.Todo)
                        .OrderBy(n => n.Add);
            }
        }

        /// <summary>
        /// Add a new task to the list
        /// </summary>
        /// <param name="task"></param>
        public void Add(TaskContainer task) => this.taskList.Add(task);

        /// <summary>
        /// Show the tasks stored in the list
        /// </summary>
        public void Show() {
            // show todo list
            if (this.TodoList.Count() == 0) {
                Console.WriteLine("There is no tasks to do");
            }
            else {
                Console.WriteLine("Todo");
                Console.WriteLine("------------------------------");
                for (int i = 0; i < this.TodoList.Count(); i++) {
                    Console.WriteLine($"{i + 1}:{this.TodoList.ElementAt(i)}");
                }
            }

            // show finished task list
            if (this.FinishedList.Count() > 0) {
                Console.WriteLine(Environment.NewLine + "Finished task");
                Console.WriteLine("------------------------------");
                for (int i = 0; i < this.FinishedList.Count(); i++) {
                    Console.WriteLine($"{i + 1}:{this.FinishedList.ElementAt(i)}");
                }
            }
        }

        /// <summary>
        /// Change status of a task done
        /// </summary>
        /// <param name="index">Index of a task which want to change status done</param>
        public void Done(int index) {
            // index range check
            index--;
            if (index < 0 || index > this.TodoList.Count() - 1) {
                Console.WriteLine($"Invalid task number");
                return;
            }

            // check state of the task
            if (this.TodoList.ElementAt(index).State != TaskState.Todo) {
                Console.WriteLine("Specified task is already finished");
                return;
            }

            this.TodoList.ElementAt(index).Finished = DateTime.Now;
            this.TodoList.ElementAt(index).State = TaskState.Done;
        }

        /// <summary>
        /// Change status of a task cancel
        /// </summary>
        /// <param name="index">Index of a task which want to change status cancel</param>
        public void Cancel(int index) {
            // index range check
            index--;
            if (index < 0 || index > this.TodoList.Count() - 1) {
                Console.WriteLine($"Invalid task number");
                return;
            }

            // check state of the task
            if (this.TodoList.ElementAt(index).State != TaskState.Todo) {
                Console.WriteLine("Specified task is already finished");
                return;
            }

            this.TodoList.ElementAt(index).State = TaskState.Canceled;
        }

        /// <summary>
        /// Reset status of a task
        /// </summary>
        /// <param name="index">Index of a task wich want to reset status</param>
        public void Reset(int index) {
            // index range check
            index--;
            if (index < 0 || index > this.FinishedList.Count() - 1) {
                Console.WriteLine($"Invalid task number");
                return;
            }

            // check state of the task
            if (this.FinishedList.ElementAt(index).State == TaskState.Todo) {
                Console.WriteLine("Specified task is not finished");
                return;
            }

            this.FinishedList.ElementAt(index).State = TaskState.Todo;
        }

        /// <summary>
        /// Write tasks to a save file
        /// </summary>
        public void Save() {
            var serializer = new XmlSerializer(typeof(TaskList));
            using (var sw = new StreamWriter(this.filePath, false, Encoding.UTF8)) {
                serializer.Serialize(sw, this.taskList);
            }
        }

        /// <summary>
        /// Read tasks from a save file
        /// </summary>
        public void Load() {
            if (File.Exists(this.filePath)) {
                var serializer = new XmlSerializer(typeof(TaskList));
                using (var sr = new StreamReader(filePath, Encoding.UTF8)) {
                    this.taskList = (TaskList)serializer.Deserialize(sr);
                }
            }
        }
    }
}
