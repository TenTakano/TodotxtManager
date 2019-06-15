using CommandLine;

namespace TodotxtManager {
    public class ArgOptions {
    }

    [Verb("add", HelpText = "Add a new task")]
    public class AddCommand {
        [Value(0, MetaName  = "Task Name")]
        public string Name { get; set; }
    }

    [Verb("done", HelpText = "Change status of a task done")]
    public class DoneCommand {
        [Value(0, MetaName = "Index of task which want to change status to done")]
        public int Index { get; set; }
    }
}