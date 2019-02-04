using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Robot
{
    public interface IRobot
    {
        void Move(double distance);
        void Turn(double angle);
        void Beep();
    }

    public abstract class AbstractRobotDecorator : IRobot
    {
        private const string Move_Message_Template = "Move {0}";
        private const string Beep_Message_Template = "Beep";
        private const string Turn_Message_Template = "Turn {0}";

        public string moveMessageTemplate { get { return Move_Message_Template; } }
        public string beepMessageTemplate { get { return Beep_Message_Template; } }
        public string turnMessageTemplate { get { return Turn_Message_Template; } }
        private IRobot _robot;
        private ITraceWriter _traceWriter;
        public IRobot robot { get { return _robot; } }
        public ITraceWriter traceWriter { get { return _traceWriter; } }
        public AbstractRobotDecorator(IRobot robot, ITraceWriter traceWriter)
        {
            _robot = robot;
            _traceWriter = traceWriter;
        }
        public void Beep()
        {         
            _robot.Beep();
            _traceWriter.WriteTrace(beepMessageTemplate);
            return;
        }

        public void Move(double distance)
        { 
            //_robot.Move(distance);
            _traceWriter.WriteTrace(string.Format(moveMessageTemplate, distance));           
            return;
        }

        public void Turn(double angle)
        {
            _robot.Turn(angle);
            _traceWriter.WriteTrace(string.Format(turnMessageTemplate, angle));            
            return;
        }
    }

    public class RobotDecorator : AbstractRobotDecorator
    {
        public RobotDecorator(IRobot robot, ITraceWriter traceWriter)
            : base (robot, traceWriter) { }
    }

    [ExcludeFromCodeCoverage]
    public class Robot : IRobot
    {
        void IRobot.Move(double distance)
        {
            return;
        }
        
        void IRobot.Turn(double angle)
        {
            return;
        }

        void IRobot.Beep()
        {
            return;
        }
    }
}
