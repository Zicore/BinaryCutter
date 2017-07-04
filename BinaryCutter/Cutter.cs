using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryCutter
{
    public class Cutter
    {
        Options options = new Options();

        public void Initialize(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments(args,options);
        }

        public void Cut()
        {
            using (var fr = File.OpenRead(options.Source))
            {
                fr.Seek(options.Start, SeekOrigin.Begin);

                var size = options.End - options.Start;
                int bufferSize = 1024;

                long parts = size / 1024;
                int remainder = (int)size%1024;
                
                using (var fw = File.OpenWrite(options.Destination))
                {
                    for (int i = 0; i < parts; i++)
                    {
                        TransferBytes(fr, fw, bufferSize);
                    }

                    if (remainder > 0)
                    {
                        TransferBytes(fr, fw, remainder);
                    }
                }
            }
        }

        private void TransferBytes(FileStream fr,FileStream fw,int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            fr.Read(buffer, 0, bufferSize);
            fw.Write(buffer, 0 , bufferSize);
        }
    }
}
