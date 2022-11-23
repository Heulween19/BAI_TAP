using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_thu_cung
{
    public class Cat: Animals,ISpeak
    {
        public void Speak()
        {
            Console.WriteLine("MEo MEo");
        }
        public override void Output()
        {
            base.Output();
            Speak();
        }
    }
}
