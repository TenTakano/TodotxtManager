using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Reflection;

using TaskList = System.Collections.Generic.List<TodotxtManager.TaskContainer>;

namespace TodotxtManager {
    public class TaskListManager {
        private string filePath = Directory.GetParent(Assembly.GetExecutingAssembly().Location)
                                    + "/todolist.xml";
        private TaskList taskList = new TaskList();

        public void Add(TaskContainer task) => this.taskList.Add(task);

        public void Show() {
            if (this.taskList.Count == 0) {
                Console.WriteLine("There is no tasks");
            }
            else {
                foreach (var task in this.taskList) {
                    Console.WriteLine(task);
                }
            }
        }

        public void Save() {
            var serializer = new XmlSerializer(typeof(TaskList));
            using (var sw = new StreamWriter(this.filePath, false, Encoding.UTF8)) {
                serializer.Serialize(sw, this.taskList);
            }
        }

        public void Load() {
            if(File.Exists(this.filePath)) {
                var serializer = new XmlSerializer(typeof(TaskList));
                using (var sr = new StreamReader(filePath, Encoding.UTF8)) {
                    this.taskList = (TaskList)serializer.Deserialize(sr);
                }
            }
        }
    }
}
