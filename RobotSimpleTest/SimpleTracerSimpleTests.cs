using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot;

namespace RobotSimpleTest
{
    [TestClass]
    public class SimpleTracerSimpleTests
    {
        [TestMethod]
        public void ConstructorTestSimpleTracer()
        {
            SimpleTracer target = new SimpleTracer();
            Assert.IsNotNull(target.traceLog);
        }
        [TestMethod]
        public void WritWriteTraceTest()
        {
            SimpleTracer target = new SimpleTracer();
            string message = "test message";
            int traceCount = target.traceLog.Count;
            target.WriteTrace(message);
            Assert.AreEqual(traceCount + 1, target.traceLog.Count);
            Assert.AreEqual(message, target.traceLog[target.traceLog.Count - 1]);
        }
    }
}
