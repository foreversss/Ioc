using IDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Vivo: AbstractPhone
    {
        public override void Call()
        {
            Console.WriteLine("打电话");
        }

        public override void SendMessage()
        {
            Console.WriteLine("发短信");
        }
    }
}
