using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so : ");
            string day = Console.ReadLine();
            switch (day)
            {
                case "2":
                    Console.WriteLine("Thu hai");
                    break;
                case "3":
                    Console.WriteLine("Thu ba");
                    break;
                case "4":
                    Console.WriteLine("Thu tu");
                    break;
                case "5":
                    Console.WriteLine("Thu nam");
                    break;
                case "6":
                    Console.WriteLine("Thu sau");
                    break;
                case "7":
                    Console.WriteLine("Thu bay");
                    break;
                case "cn":
                    Console.WriteLine("Chu nhat");
                    break;
                default:
                    Console.WriteLine("Sai dinh dang ngay ");
                    break;

            }  
            
        }
    }
}
