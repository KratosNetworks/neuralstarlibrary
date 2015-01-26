using System;
using System.Collections.Generic;
using System.Text;

using AiMetrix.BusinessObject.Security;

namespace Inventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Login();

            InventoryExample example = new InventoryExample();
            //example.AddInventory_Basic();
            //example.AddInventory_CreateWithClassification();
            //example.EditInventory();
            //example.DeleteInventory();

            //example.CreateClassificationType();
            //example.DeleteClassificationType();

            //example.CreateCustomObject();
            //example.CreateCustomAttribute();

            //example.SearchNSObjectGet();
            //example.Search_InventoryListVueItems();

            //example.GetNetworkVitals();
            //example.SetAvailability();

            example.SetObjectToGroup();

            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }

        public static void Login()
        {
            User.SessionStatus status = User.Login("a", "a");

            if (status == User.SessionStatus.Valid) {
                Console.WriteLine("Login Successful");
                //User.Logout();
            } else {
                Console.WriteLine("Was not able to login");
            }
        }
    }
}