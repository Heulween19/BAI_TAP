using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class Program
    {
        static void ShowMin(ref int minn, int[] arr)
            {
            minn = arr[0];
            for(int i=1; i<arr.Length; i++)
            {
                if(arr[i] < minn)
                {
                    minn=arr[i];
                } 
                
            } 
            Console.WriteLine(minn);
            }
        static void Main(string[] args)
        {
            int[] arr1 = { 2, 3, 1, 5, 4, 6, 8, 20, 14 };
            
            int minn = 0;
            
            Console.WriteLine("So nho nhat trong mang: " ) ;
            ShowMin(ref minn, arr1);
            Console.ReadKey();

        }
    }
}
