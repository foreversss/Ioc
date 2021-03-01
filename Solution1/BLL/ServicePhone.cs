using IBLL;
using IDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicePhone : IServicePhone
    {
        public void PlayAbstract(AbstractPhone phone)
        {
            Console.WriteLine($"Use{phone.GetType().Name}");
            phone.Call();
            phone.SendMessage();
        }
    }
}
