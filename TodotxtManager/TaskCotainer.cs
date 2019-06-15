using System;
using System.Collections.Generic;
using System.Text;

namespace TodotxtManager {

    /// <summary>
    /// Class for containing a task and its properties
    /// </summary>
    public class TaskContainer {
        public TaskState State { get; set; }

        public string Name { get; set; }

        public DateTime Add { get; set; }

        public DateTime Finished { get; set; }

        public string Tags { get; set; }

        public string Detail { get; set; }

        public TaskContainer() { }

        public TaskContainer(AddCommand arg) {
            this.State = TaskState.Todo;
            this.Name = arg.Name;
            this.Add = DateTime.Now;
        }

        override public string ToString() {
            return $"{this.State}, {this.Name}, {this.Add}, {this.Finished}";
        }
    }

    /// <summary>
    /// Enum for describing state of a task
    /// </summary>
    public enum TaskState {
        Todo,
        Done,
        Canceled
    }
}
