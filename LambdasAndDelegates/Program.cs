using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LambdasAndDelegates
{
    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        
        static void Main(string[] args)
        {
            var custs = new List<Customer>
            {
                new Customer{City="Hyderabad",FirstName="Poojitha",LastName="Pancheti",ID=1},
                new Customer { City = "Hyderabad", FirstName = "Srujana", LastName = "jami", ID = 2 },
                new Customer { City="Banglore",FirstName="Yamini",LastName="Pancheti",ID=3},
            };
            var hydCusts = custs
                .Where(c=>c.City == "Hyderabad" && c.ID<300)
                .OrderBy(c => c.FirstName);
            foreach (var cust in hydCusts)
            {
                Console.WriteLine(cust.FirstName);
            }

            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            var data = new ProcessData();
            // data.Process(2, 3, addDel);
            data.Process(3, 4, multiplyDel);
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultipleDel = (x, y) => x * y;
            //data.ProcessFunc(3, 2, funcAddDel);
            data.ProcessFunc(4, 5, funcMultipleDel);
           

            Action<int, int> myAction = (x, y) => Console.WriteLine(x+y);
            Action<int, int> myMultiplyAction=(x, y) => Console.WriteLine(x * y);
            data.ProcessAction(3, 4, myAction);

            var worker = new Worker();
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Worked: " + e.Hours + "hours doing:" + e.WorkType);
                Console.WriteLine("Some other value");
            };
            worker.WorkCompleted += (s, e) => Console.WriteLine("Work is complete!");
            worker.DoWork(8, WorkType.GenerateReports);
            Console.Read();
        }
       // static void Worker_WorkPerformed(object sender,WorkPerformedEventArgs e)
        //{
          //  Console.WriteLine("Worked:" + e.Hours + " hours doing:" + e.WorkType);
        //}
       // static void Worker_WorkCompleted(object sender,EventArgs e)
        //{
          //  Console.WriteLine("Work is completed");
        //}
    }
}
