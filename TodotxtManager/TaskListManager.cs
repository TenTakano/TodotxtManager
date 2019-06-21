using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

using TaskList = System.Collections.Generic.List<TodotxtManager.TaskContainer>;

namespace TodotxtManager {
    public class TaskListManager {
        private string filePath = $"{Environment.CurrentDirectory}/todolist.xml";
        private TaskList taskList = new TaskList();

        /// <summary>
        /// Add a new task to the list
        /// </summary>
        /// <param name="task"></param>
        public void Add(TaskContainer task) => this.taskList.Add(task);

        /// <summary>
        /// Show the tasks stored in the list
        /// </summary>
        public void Show() {
            if (this.taskList.Count == 0) {
                Console.WriteLine("There is no tasks");
            }
            else {
                for(int i = 0; i < this.taskList.Count; i++) {
                    Console.WriteLine($"{i + 1}:{this.taskList[i]}");
                }
            }
        }

        /// <summary>
        /// Change status of a task done
        /// </summary>
        /// <param name="index">Index of a task which want to change status done</param>
        public void Done(int index) => this.ChangeTaskStatus(index, TaskState.Done);

        /// <summary>
        /// Change status of a task cancel
        /// </summary>
        /// <param name="index">Index of a task which want to change status cancel</param>
        public void Cancel(int index) => this.ChangeTaskStatus(index, TaskState.Canceled);

        /// <summary>
        /// Reset status of a task
        /// </summary>
        /// <param name="index">Index of a task wich want to reset status</param>
        public void Reset(int index) => this.ChangeTaskStatus(index, TaskState.Todo);

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
            if(File.Exists(this.filePath)) {
                var serializer = new XmlSerializer(typeof(TaskList));
                using (var sr = new StreamReader(filePath, Encoding.UTF8)) {
                    this.taskList = (TaskList)serializer.Deserialize(sr);
                }
            }
        }

        private void ChangeTaskStatus(int index, TaskState state) {
            // Adjust different between internal count and display number
            index--;

            if (index < 0 || index > this.taskList.Count - 1) {
                Console.WriteLine($"Task index should be given 1 to {this.taskList.Count}");
                return;
            }

            // check state of the task
            if (this.taskList[index].State != TaskState.Todo) {
                Console.WriteLine("Specified task is already finished");
                return;
            }

            this.taskList[index].State = state;
        }
    }
}
