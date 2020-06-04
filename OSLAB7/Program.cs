using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//Lab 9 working.
namespace OSLAB7
{
    //FCFPS
    class Program
    {
        //ReadyQueue 
        static Process ReadyQueueHead = null;
        static Process ReadyQueueCurrent = null;

        static int numbersofprocesses = 10;

        static Random rand = new Random();

        //ExecuteQueue 
        static Process ExecuteQueueHead = null;
        static Process ExecuteQueueCurrent = null;
        static List<Process> SortedProcesses = new List<Process>();
        //static Process ExecuteQueuePrevious = null;

        static int TotalTime = 0;

        static void Main(string[] args)
        {
            //Insertion of Random Processes in Ready Queue
            for (int i = 0; i < numbersofprocesses; i++)
            {
                //inserting  anew process into the ready queue
                InsertIntoReadyQueue(i);
            }

            ViewReadyQueue();

            //is method se sjf implement hota hai

            sort(ReadyQueueHead);
            ReadyQueueHead = SecondSort(ReadyQueueHead);
            /*
            for (int i = 0; i < 1; i++)
            {
                InsertIntoExecuteQueue();
            }
            */
            InsertIntoExecuteQueue(numbersofprocesses=4);
            ViewReadyQueue();
            ViewExecuteQueue();
            Console.ReadKey();
            //return;
        }
        static void InsertIntoReadyQueue(int i)
        {
            /*
            int[] a = { 8, 3, 2, 1 };
            bool[] b = { false, true, false, true };
            Process objProcess = new Process();
            objProcess.PID = i;
            objProcess.Name = "Process " + i;
            objProcess.ArrivalTime = rand.Next(1, 10);
            objProcess.CPUBurst = rand.Next(1, 10);
            objProcess.IOBurst = rand.Next(1, 10);
            objProcess.IsSystemProcess = b[i];// RandomProcess();
            objProcess.priority = a[i];// rand.Next(0, 10);
            */
            
            Process objProcess = new Process();
            objProcess.PID = i;
            objProcess.Name = "Process " + i;
            objProcess.ArrivalTime = rand.Next(1, 10);
            objProcess.CPUBurst = rand.Next(1, 10);
            objProcess.IOBurst = rand.Next(1, 10);
            objProcess.IsSystemProcess = RandomProcess();
            objProcess.priority = rand.Next(0, 10);
            
            /*
            //first method
            if(objProcess.IsSystemProcess==true)//it is a system process
            {
                objProcess.priority = rand.Next(11, 20);
            }
            else
            {
                objProcess.priority = rand.Next(0, 10);
            }
            */


            //for the first time starting
            if (ReadyQueueHead == null)
            {
                ReadyQueueHead = objProcess;
                ReadyQueueCurrent = objProcess;
            }
            else
            {
                //now the head has it's value and we also want previous node
                ReadyQueueCurrent.next = objProcess;
                objProcess.previous = ReadyQueueCurrent;
                ReadyQueueCurrent = objProcess;
                ;
            }
        }
        private static bool RandomProcess()
        {
            int a = rand.Next(0, 10);
            if (a % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //use this method when you want all of the processes
        static void InsertIntoExecuteQueue()
        {
            if (ReadyQueueHead == null)
                return;

            Process objProcess = new Process();
            objProcess = ReadyQueueHead;

            if (ExecuteQueueHead == null)
            {
                objProcess.WaitingTime = 0;
                ExecuteQueueHead = objProcess;
                ExecuteQueueCurrent = objProcess;
            }
            else
            {
                objProcess.WaitingTime = TotalTime - objProcess.ArrivalTime;
                ExecuteQueueCurrent.next = objProcess;
                ExecuteQueueCurrent = objProcess;
            }

            TotalTime = TotalTime + (objProcess.CPUBurst + objProcess.IOBurst);

            ReadyQueueHead = ReadyQueueHead.next;
            Console.WriteLine("Process Moved to Execute Queue for Execution");
        }
        //use this when you want specific processes in the excecute que
        static void InsertIntoExecuteQueue(int NumberOfProcesses)
        {
            //this is the condition we will use to restrict the moving of processes
            while (NumberOfProcesses > 0)
            {
                if (ReadyQueueHead == null)
                    return;

                Process objProcess = new Process();
                objProcess.PID = ReadyQueueHead.PID;
                objProcess.Name = ReadyQueueHead.Name;
                objProcess.ArrivalTime = ReadyQueueHead.ArrivalTime;
                objProcess.CPUBurst = ReadyQueueHead.CPUBurst;
                objProcess.IOBurst = ReadyQueueHead.IOBurst;
                objProcess.IsSystemProcess = ReadyQueueHead.IsSystemProcess;
                objProcess.priority = ReadyQueueHead.priority;


                if (ExecuteQueueHead == null)
                {
                    objProcess.WaitingTime = 0;
                    ExecuteQueueHead = objProcess;
                    ExecuteQueueCurrent = objProcess;
                }
                else
                {
                    objProcess.WaitingTime = TotalTime - objProcess.ArrivalTime;
                    ExecuteQueueCurrent.next = objProcess;
                    ExecuteQueueCurrent = objProcess;
                }

                TotalTime = TotalTime + (objProcess.CPUBurst + objProcess.IOBurst);

                ReadyQueueHead = ReadyQueueHead.next;
                Console.WriteLine("Process Moved to Execute Queue for Execution");
                NumberOfProcesses--;
            }
        }
        static void ViewReadyQueue()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("READY QUEUE");
            Console.WriteLine("***************************************");

            Process objStartProcess = ReadyQueueHead;
            Console.Write("ID \t");
            Console.Write("Name \t \t");
            Console.Write("ArrivalTime \t \t");
            Console.Write("CPU Burst \t");
            Console.Write("IO Burst \t");
            Console.Write("Is a System Process?: \t");
            Console.Write("Priority \t");


            Console.WriteLine("");

            while (objStartProcess != null)
            {
                Console.Write(objStartProcess.PID);
                Console.Write("\t" + objStartProcess.Name);
                Console.Write("\t \t" + objStartProcess.ArrivalTime);
                Console.Write("\t \t " + objStartProcess.CPUBurst);
                Console.Write("\t \t" + objStartProcess.IOBurst);
                Console.Write("\t \t" + objStartProcess.IsSystemProcess);
                Console.Write("\t \t" + objStartProcess.priority);

                Console.WriteLine("");

                Console.WriteLine("");

                objStartProcess = objStartProcess.next;
            }
        }
        static void ViewExecuteQueue()
        {
            Console.WriteLine("");
            Console.WriteLine("***************************************");
            Console.WriteLine("EXECUTE QUEUE");
            Console.WriteLine("***************************************");

            Process objStartProcess = ExecuteQueueHead;
            Console.Write("ID \t");
            Console.Write("Name \t \t");
            Console.Write("ArrivalTime \t \t");
            Console.Write("CPU Burst \t");
            Console.Write("IO Burst \t");
            Console.Write("Total Time \t");
            Console.Write("Waiting Time \t");
            Console.Write("Is a System Process?: \t");
            Console.Write("Priority \t");


            Console.WriteLine("");
            var totalTime = 0;

            while (objStartProcess != null)
            {
                totalTime = totalTime + (objStartProcess.CPUBurst + objStartProcess.IOBurst);
                Console.Write(objStartProcess.PID);
                Console.Write("\t" + objStartProcess.Name);
                Console.Write("\t \t" + objStartProcess.ArrivalTime);
                Console.Write("\t \t " + objStartProcess.CPUBurst);
                Console.Write("\t \t" + objStartProcess.IOBurst);
                Console.Write("\t \t" + totalTime);
                Console.Write("\t \t" + objStartProcess.WaitingTime);
                Console.Write("\t \t" + objStartProcess.IsSystemProcess);
                Console.Write("\t \t \t" + objStartProcess.priority);

                Console.WriteLine("");
                Console.WriteLine("CPU Burst:" + objStartProcess.CPUBurst);
                Console.WriteLine("********************");
                objStartProcess = objStartProcess.next;
            }
        }
        public static void sort(Process head)
        {z
            Console.WriteLine("Sorting with priority in ascending order");
            Process current = null, index = null;
            Process temp = new Process();
            //Check whether list is empty  
            if (head != null)
            {
                //Current will point to head  
                for (current = head; current.next != null; current = current.next)
                {
                    //Index will point to node next to current  
                    for (index = current.next; index != null; index = index.next)
                    {
                        //If current's data is greater than index's data, swap the data of current and index  
                        if (current.priority < index.priority)
                        {

                            //itne saare is liye use karne par rahe hain kyunke object value type nahi 
                            //balke reference type hoti hai
                            //ye basic bubble fort hai jo cpu burst se ascending order me sort kar deta hai 
                            //jo humari sjf ki requirement hai
                            temp.CPUBurst = current.CPUBurst;
                            temp.IOBurst = current.IOBurst;
                            temp.ArrivalTime = current.ArrivalTime;
                            temp.Name = current.Name;
                            temp.PID = current.PID;
                            temp.WaitingTime = current.WaitingTime;
                            temp.IsSystemProcess = current.IsSystemProcess;
                            temp.priority = current.priority;

                            current.CPUBurst = index.CPUBurst;
                            current.IOBurst = index.IOBurst;
                            current.ArrivalTime = index.ArrivalTime;
                            current.Name = index.Name;
                            current.PID = index.PID;
                            current.WaitingTime = index.WaitingTime;
                            current.IsSystemProcess = index.IsSystemProcess;
                            current.priority = index.priority;

                            index.CPUBurst = temp.CPUBurst;
                            index.IOBurst = temp.IOBurst;
                            index.ArrivalTime = temp.ArrivalTime;
                            index.Name = temp.Name;
                            index.PID = temp.PID;
                            index.WaitingTime = temp.WaitingTime;
                            index.IsSystemProcess = temp.IsSystemProcess;
                            index.priority = temp.priority;
                        }

                    }
                }
            }
            else
            {

                return;
            }
        }
        public static Process SecondSort(Process head)
        {
            Console.WriteLine("Sorting with System/User priority");
            Process system = new Process();
            Process user = new Process();
            int i = 0, j = 0;

            Process[] list = new Process[numbersofprocesses+1];
            Process[] temp = new Process[numbersofprocesses+1];
            //for system
            while (head != null)
            {
                if (head.IsSystemProcess == true)
                {
                    list[i]=(head);
                    i++;
                }
                else
                {
                    temp[j] = (head);
                    j++;
                }
                head = head.next;

            }
            j = 0;
            for ( ; i < numbersofprocesses; i++)
            {
                list[i] = temp[j];
                j++;
            }
            list[0].previous = null;
            for ( i = 0; i < numbersofprocesses; i++)
            {
                list[i].next = list[i+1];
                if(list[i].next!=null)
                list[i].next.previous = list[i];
            }
            return list[0];
        }
    }
}

//static void InsertIntoReadyQueue()
//{
//    Process objProcess = new Process();
//    Console.WriteLine("Enter ID: ");
//    objProcess.PID = Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine("Enter Name: ");
//    objProcess.Name = Console.ReadLine();
//    Console.WriteLine("Enter Arrival Time: ");
//    objProcess.ArrivalTime = Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine("Enter CPU Burst Time: ");
//    objProcess.CPUBurst = Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine("Enter I/O Burst Time: ");
//    objProcess.IOBurst = Convert.ToInt32(Console.ReadLine());

//    if (ReadyQueueHead == null)
//    {
//        ReadyQueueHead = objProcess;
//        ReadyQueueCurrent = objProcess;
//    }
//    else
//    {
//        ReadyQueueCurrent.next = objProcess;
//        ReadyQueueCurrent = objProcess;
//    }
//}
