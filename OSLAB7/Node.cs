using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLAB7
{
    class Process
    {
        public int PID;
        public string Name;
        public int ArrivalTime;
        public int CPUBurst;
        public int IOBurst;
        public int WaitingTime;
        public int priority;
        public bool IsSystemProcess;
        public Process next;
        public Process previous;

        public Process()
        {
            this.PID = 0;
            this.Name = "N/A";
            this.ArrivalTime = 0;
            this.CPUBurst = 0;
            this.IOBurst = 0;
            this.WaitingTime = 0;
            this.IsSystemProcess = false;
            this.priority = 0;
            this.next = null;
            this.previous = null;
        }
    }
}
