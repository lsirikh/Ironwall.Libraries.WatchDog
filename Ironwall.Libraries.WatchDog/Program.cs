using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ironwall.Libraries.WatchDog
{
    class Program
    {
        public static void Main(string[] args)
        {
            Thread checker = new Thread(RunTask);
            
            //ProcessControl.Instance.setTarget($"{Properties.Settings.Default.Process_Name}");
            ProcessControl.Instance.setTarget("Ironwall.Monitoring.UI");
            checker.Start();
        }

        private static void RunTask()
        {
            while (true)
            {
                if (!ProcessControl.Instance.IsProcessRun())
                {
                    Debug.WriteLine("Ironwll.Monitoring was stopped...");
                    ProcessControl.Instance.StartProcess();
                }
                else
                {
                    Debug.WriteLine("Ironwll.Monitoring is running...");
                }
                Thread.Sleep(5000);
            }
        }

        
    }
}
