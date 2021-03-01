using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Framework
{
    public class RegisterInfo
    {
        public Type Type { get; set; }
        public ILifetimeManager lifetimeManager { get; set; }

        public object obj { get; set; }

    }
}
