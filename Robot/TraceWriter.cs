using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public interface ITraceWriter
    {
        void WriteTrace(string message);
    }
    public class SimpleTracer : ITraceWriter
    {
        private List<string> _traceLog;
        public List<string> traceLog {get{ return _traceLog; }}
        public SimpleTracer()
        {
            _traceLog = new List<string>();
        }
        public void WriteTrace(string message)
        {
            _traceLog.Add(message);
        }
    }
}
