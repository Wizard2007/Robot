using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Program
    {

        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            SimpleTracer simpleTracer = new SimpleTracer();
            RobotDecorator robotDecorator = new RobotDecorator(robot, simpleTracer);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
