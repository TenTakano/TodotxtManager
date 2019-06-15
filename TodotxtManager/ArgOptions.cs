using CommandLine;

namespace TodotxtManager {
    public class ArgOptions {
    }

    [Verb("add", HelpText = "Add a new task")]
    public class AddCommand {
        [Value(0, MetaName  = "Task Name")]
        public string Name { get; set; }
    }
}
