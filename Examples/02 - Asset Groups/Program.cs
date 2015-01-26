using System;
using System.Collections.Generic;
using System.Text;

namespace AssetGroupExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AssetGroupExample example = new AssetGroupExample();

            //example.AddGroup();
            example.AddNSObjectsToGroup();
            //example.AddNSObjectsToExistingGroup();
            //example.DeleteGroup();

            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }
    }
}