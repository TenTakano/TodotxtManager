using System;
using CommandLine;

namespace TodotxtManager {
    class Program {
        static void Main(string[] args) {
            Parser.Default.ParseArguments<ArgOptions>(args).WithParsed<ArgOptions>(o => {

            });
        }
    }
}
