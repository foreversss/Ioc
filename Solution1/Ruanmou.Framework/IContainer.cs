using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Framework
{
    public interface IContainer
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;

        void RegisterType<TFrom, TTo>(ILifetimeManager lifetimeManager) where TTo : TFrom;

        T Resolve<T>();
    }
}
