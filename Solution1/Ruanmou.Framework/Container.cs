using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Framework
{
    /// <summary>
    /// IoC容器
    /// </summary>
    public class Container : IContainer
    {

        private Dictionary<string, RegisterInfo> ContainerDic = new Dictionary<string, RegisterInfo>();

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            this.RegisterType<TFrom, TTo>(new BOBOTransientLifetimeManager());
        }

        public void RegisterType<TFrom, TTo>(ILifetimeManager lifetimeManager) where TTo : TFrom
        {
            this.ContainerDic.Add(typeof(TFrom).FullName, new RegisterInfo()
            {
                lifetimeManager = lifetimeManager,
                Type = typeof(TTo)
            });
        }

        /// <summary>
        /// 创建对象实例化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            //选择构造函数规则:  一. 优先带标记特性的构造函数  二.构造函数参数最多的。

            var registerInfo = this.ContainerDic[typeof(T).FullName];

            return (T)this.Resolve(registerInfo);
        }


        private object Resolve(RegisterInfo registerInfo)
        {
            //如果等于单例模式
            if (registerInfo.lifetimeManager is BOBOSingletonLifetimeManager)
            {
                //判断第一次进来是否已经实例化   如果不等于空  那么直接返回
                if (registerInfo.obj != null)
                {
                    return registerInfo.obj;
                }
            }
            else if (registerInfo.lifetimeManager is BOBOPerThreadLifetimeManager)
            {
                string key = $"Current_{registerInfo.Type.FullName}";
                //拿到每个线程的数据
                object oValue = CallContext.GetData(key);

                //如果不等于null 就直接返回
                if (oValue != null)
                {
                    return oValue;
                }
            }
            

            #region 选择构造函数规则

            var type = registerInfo.Type;

            //获取所有构造函数
            var ctros = type.GetConstructors();

            //查找构造函数上面有没有带特性标记的   如果等等于null 那么就是没有
            var ctor = ctros.FirstOrDefault(x => x.IsDefined(typeof(BOBOInjectionConstructor), true));

            if (ctor == null)
            {
                ctor = ctros.OrderByDescending(x => x.GetParameters().Length).First();
            }
            #endregion


            //所有参数的实例
            List<object> list = new List<object>();

            foreach (var para in ctor.GetParameters())
            {
                //获取参数类型
                var paraType = para.ParameterType;//获取的接口----

                var paraTargetType = this.ContainerDic[paraType.FullName];//获取的具体类型-----

                var target = this.Resolve(paraTargetType);

                list.Add(target);
            }

            var obj = Activator.CreateInstance(type, list.ToArray());

            if (registerInfo.lifetimeManager is BOBOSingletonLifetimeManager)
            {
                registerInfo.obj = obj;
            }
            else if (registerInfo.lifetimeManager is BOBOPerThreadLifetimeManager)
            {
                string key = $"Current_{registerInfo.Type.FullName}";

                CallContext.SetData(key, obj);
            }
       
            return obj;
        }
    }
}
