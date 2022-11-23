using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_thu_cung
{
    public class Dog : Animals,ISpeak
    {
        public Dog(string id, string name, float height, float weight, string color) : base(id, name, height, weight, color)
        {
        }

        public void Speak()
        {
            Console.WriteLine("Go go");
        }
        public override void Output()
        {
            base.Output( );
            Speak();
        }
    }
}
