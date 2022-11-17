using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAi_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[]{  "Event-Assign", "Event-View", "Event-Assign", "Event-Acept",
            "Event-Delete", "Event-Assign", "Event-Acept", "Event-Delete", "Event-Delete",
            "Event-View", "Event-Assign", "Event-Acept", "Event-Delete", "Event-Assign"};

            
            int count = 0;
            for (int i = 0; i < arr.Length - 3; i++)
            {
                if (arr[i].Equals("Event-View") && arr[i + 1].Equals("Event-Assign") &&
                    arr[i + 2].Equals("Event-Acept") && arr[i + 3].Equals("Event-Delete"))
                {
                    count++;
                }
            }
            Console.WriteLine($"So luong giao dich: {count}");
            Console.ReadKey();
        }
    }
}

