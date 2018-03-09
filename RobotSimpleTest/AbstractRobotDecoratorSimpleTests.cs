using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Sequences;
using Robot;

namespace RobotSimpleTest
{
    [TestClass]
    public class AbstractRobotDecoratorSimpleTests
    {
        [TestMethod]
        public void ConstructorTestRobotDecorator()
        {
            Mock<IRobot> robot = new Mock<IRobot>();
            Mock<ITraceWriter> traceWriter = new Mock<ITraceWriter>();
            RobotDecorator robotDecorator = new RobotDecorator(robot.Object, traceWriter.Object);
            Assert.IsNotNull(robotDecorator.robot);
            Assert.IsNotNull(robotDecorator.traceWriter);
        }
        [TestMethod]
        public void BeepTest()
        {
            RobotDecorator robotDecorator;
            Mock<IRobot> robot = new Mock<IRobot>();
            Mock<ITraceWriter> traceWriter = new Mock<ITraceWriter>();
            MockSequence seq = new MockSequence();
            robotDecorator = new RobotDecorator(robot.Object, traceWriter.Object);
            using (Sequence.Create())
            {
                robot.Setup(r => r.Beep()).InSequence();
                traceWriter.Setup(t => t.WriteTrace(robotDecorator.beepMessageTemplate)).InSequence();
                robotDecorator.Beep();
            }
        }
        [TestMethod]
        public void MoveTest()
        {
            RobotDecorator robotDecorator;
            Mock<IRobot> robot = new Mock<IRobot>();
            Mock<ITraceWriter> traceWriter = new Mock<ITraceWriter>();
            MockSequence seq = new MockSequence();
            double distance = 10;
            robotDecorator = new RobotDecorator(robot.Object, traceWriter.Object);
            using (Sequence.Create())
            {
                robot.Setup(r => r.Move(distance)).InSequence();
                traceWriter.Setup(t => t.WriteTrace(string.Format(robotDecorator.moveMessageTemplate, distance))).InSequence();               
                robotDecorator.Move(distance);
            }
        }
        [TestMethod]
        public void TurnTest()
        {
            RobotDecorator robotDecorator;
            Mock<IRobot> robot = new Mock<IRobot>();
            Mock<ITraceWriter> traceWriter = new Mock<ITraceWriter>();
            MockSequence seq = new MockSequence();
            double angle = 10;
            robotDecorator = new RobotDecorator(robot.Object, traceWriter.Object);
            using (Sequence.Create())
            {
                robot.Setup(r => r.Turn(angle)).InSequence();
                traceWriter.Setup(t => t.WriteTrace(string.Format(robotDecorator.turnMessageTemplate, angle))).InSequence();
                robotDecorator.Turn(angle);
            }
        }
    }
}
