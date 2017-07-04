using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryCutter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cutter cutter = new Cutter();
            try
            {
                cutter.Initialize(args);
                cutter.Cut();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
