using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Interface
{
    public interface IPhone
    {
        void Call();

        IMicrophone Microphone { get; set; }
        IPower Power { get; set; }
        IHeadphone Headphone { get; set; }



    }
}
