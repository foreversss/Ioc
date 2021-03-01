using Ruanmou.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Service
{
    public class AndroidPhone : IPhone
    {
        public IMicrophone Microphone { get; set; }
        public IPower Power { get; set; }
        public IHeadphone Headphone { get; set; }

        public void Call()
        {
            Console.WriteLine($"{this.GetType().Name}打电话。。。");
        }

        public AndroidPhone()
        {

            Console.WriteLine($"{this.GetType().Name}构造函数。。。");

        }
    }
}
