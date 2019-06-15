using System;
using CommandLine;

namespace TodotxtManager {
    class Program {
        static void Main(string[] args) {
            var tasks = new TaskListManager();
            tasks.Load();

            if (args.Length == 0) {
                tasks.Show();
            }
            else {
                Parser.Default.ParseArguments<ArgOptions, AddCommand, DoneCommand>(args)
                    .WithParsed<ArgOptions>(o => {
                    })
                    .WithParsed<AddCommand>(o => {
                        tasks.Add(new TaskContainer(o));
                        tasks.Save();
                        tasks.Show();
                    })
                    .WithParsed<DoneCommand>(o => {
                        tasks.Done(o.Index);
                        tasks.Save();
                        tasks.Show();
                    });
            }
        }
    }
}
