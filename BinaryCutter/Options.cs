using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace BinaryCutter
{
    public class Options
    {
        [Option('s', "start", Required = true, HelpText = "Start bytes.")]
        public long Start { get; set; }

        [Option('e', "end", Required = true, HelpText = "End bytes.")]
        public long End { get; set; }

        [Option("source", Required = true, HelpText = "Source File.")]
        public string Source { get; set; }

        [Option("destination", Required = true, HelpText = "Destination File.")]
        public string Destination { get; set; }
    }
}
