using System;
using System.Collections.Generic;
using System.Text;

namespace StateTypesExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StateTypesExample example = new StateTypesExample();
            //example.CreateStateTypes();
            example.SetStateTypes();

            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }
    }
}