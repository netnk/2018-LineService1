using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Timers;

namespace LineService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 60000; //执行间隔时间,单位为毫秒; 这里实际间隔为1分钟  
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(test);
           
        }
        private static void test(object source, ElapsedEventArgs e)
        {
            string path = @"C:\\temp\\";

            if (DateTime.Now.Hour == 14 && DateTime.Now.Minute == 07)  
            {
                using (FileStream fs = new FileStream(path + "timer_log.txt", FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine(DateTime.Now.ToString());  
                    }
                }
            }
                  

        }
        protected override void OnStop()
        {
        }
    }
}
