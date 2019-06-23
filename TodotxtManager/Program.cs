// Copyright(c) 2019 TenTakano
// All rights reserved.
// See License in the project root for license information.
//
// The commandline package is:
// Copyright(c) 2005 - 2015 Giacomo Stelluti Scala & Contributors
// Released under the MIT license
// see https://github.com/commandlineparser/commandline

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
                Parser.Default.ParseArguments<ArgOptions, AddCommand, DoneCommand, CancelCommand, ResetCommand>(args)
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
                    })
                    .WithParsed<CancelCommand>(o => {
                        tasks.Cancel(o.Index);
                        tasks.Save();
                        tasks.Show();
                    })
                    .WithParsed<ResetCommand>(o => {
                        tasks.Reset(o.Index);
                        tasks.Save();
                        tasks.Show();
                    });
            }
        }
    }
}
