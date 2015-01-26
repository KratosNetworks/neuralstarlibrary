using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmsExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AlarmsExample example = new AlarmsExample();

            //example.CreateAlarm();
            //example.AcknowledgeAlarm();
            //example.ClearAlarm();
            example.ProminantAlarm();

            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
