using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDLL
{

    /// <summary>
    /// 抽象类
    /// </summary>
    public abstract class AbstractPhone
    {

        /// <summary>
        /// 发短信
        /// </summary>
        public abstract void SendMessage();

        /// <summary>
        /// 打电话
        /// </summary>
        public abstract void Call();

    }
}
