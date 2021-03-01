using Ruanmou.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Ruanmou.Service
{
    public class ApplePhone : IPhone
    {
        //属性注入
        [Dependency]
        public IMicrophone Microphone { get; set; }
        public IPower Power { get; set; }
        public IHeadphone Headphone { get; set; }


        public ApplePhone()
        {
            Console.WriteLine($"{this.GetType().Name}构造函数");

        }

        [InjectionConstructor]//构造函数注入:可以不用调用，默认调用最多的
        public ApplePhone(IHeadphone headphone)
        {
            this.Headphone = headphone;
            Console.WriteLine($"{this.GetType().Name}带参数的构造函数。。。");
        }

        public void Call()
        {
            Console.WriteLine($"{this.GetType().Name}打电话。。。。");
        }

        [InjectionMethod]//方法注入
        public void Init(IPower power)
        {
            this.Power = power;

        }
    }
}
