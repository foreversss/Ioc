

using Factory;
using IBLL;
using IDLL;
using Microsoft.Practices.Unity.Configuration;
using Ruanmou.Framework;
using Ruanmou.Interface;
using Ruanmou.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace DIP
{
    /// <summary>
    /// Ioc 控制反转
    /// </summary>
    class Program
    {
       
        static void Main(string[] args)
        {




            //IServicePhone service = new ServicePhone();

            //Mi mi = new Mi();

            //service.PlayAbstract(mi);

            //Vivo vivo = new Vivo();

            //service.PlayAbstract(vivo);





            try
            {
                //IServicePhone servicePhone = SimpleFactory.CreateService();

                //AbstractPhone abstractPhone = SimpleFactory.CreateAbstractPhone();

                //servicePhone.PlayAbstract(abstractPhone);

                //构建AndroidPhone
                //{
                //    IUnityContainer container = new UnityContainer();
                //    container.RegisterType<IPhone, AndroidPhone>();

                //    IPhone phone = container.Resolve<IPhone>();
                //}

                ////构建
                //{

                //    IUnityContainer container = new UnityContainer();
                //    container.RegisterType<IPhone, ApplePhone>();
                //    container.RegisterType<IHeadphone, Headphone>();
                //    container.RegisterType<IPower, Power>();
                //    container.RegisterType<IMicrophone, Microphone>();


                //    IPhone phone = container.Resolve<IPhone>();
                //}

                //{
                //    //IOC使用时，全局只需要一个容器就够了  -------全局静态
                //    //一个抽象 多个实例 使用别名
                //    IUnityContainer container = new UnityContainer();
                //    container.RegisterType<IPhone, ApplePhone>("applephone");
                //    container.RegisterType<IPhone, AndroidPhone>("androidphone");
                //    container.RegisterType<IHeadphone, Headphone>();
                //    container.RegisterType<IPower, Power>();
                //    container.RegisterType<IMicrophone, Microphone>();

                //    IPhone phone1 = container.Resolve<IPhone>("applephone");
                //    IPhone phone2 = container.Resolve<IPhone>("androidphone");
                //}

                //使用配置文件注册
                {
                    //IUnityContainer container = new UnityContainer();

                    ////读取配置文件
                    //ExeConfigurationFileMap filemap = new ExeConfigurationFileMap();

                    //filemap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Unity.config.xml");//找的配置文件路径

                    //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(filemap, ConfigurationUserLevel.None);

                    //UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                    //section.Configure(container, "testContainer");

                    //IPhone phone1 = container.Resolve<IPhone>("applephone");

                }

                //自定义IOC容器
                //{
                //    IContainer container = new Container();

                //    container.RegisterType<IPhone, ApplePhone>();
                //    container.RegisterType<IMicrophone, Microphone>();
                //    container.RegisterType<IPower, Power>();
                //    container.RegisterType<IHeadphone, Headphone>();

                //    IHeadphone phone = container.Resolve<IHeadphone>();
                //    IPhone phone1 = container.Resolve<IPhone>();
                //}

                //Ioc容器构造对象的生命周期  
                //生命周期类型:瞬时生命周期-----即时创建的  ------------默认就是瞬时的
                //单例生命周期: -----整个进程只有一个实例叫单例----
                //线程单例生命周期:-------每个线程是一个不同的实例，同一个线程的实例是相同的
                //{
                    //IUnityContainer container = new UnityContainer();

                    //1.TransientLifetimeManager  瞬时生命周期     默认就是瞬时的
                    //container.RegisterType<IMicrophone, Microphone>(new TransientLifetimeManager());

                //    //2.SingletonLifetimeManager 单例生命周期     -----整个进程只有一个实例叫单例----
                //    //container.RegisterType<IMicrophone, Microphone>(new SingletonLifetimeManager());

                //    //3.PerThreadLifetimeManager 线程单例生命周期    每个线程是一个不同的实例，同一个线程的实例是相同的
                //    container.RegisterType<IMicrophone, Microphone>(new PerThreadLifetimeManager());

                //    IMicrophone microphone1 = null;
                //    IMicrophone microphone2 = null;
                //    IMicrophone microphone3 = null;
                //    IMicrophone microphone4 = null;
                //    IMicrophone microphone5 = null;
                //    IMicrophone microphone6 = null;


                //    microphone1 = container.Resolve<IMicrophone>();
                //    microphone2= container.Resolve<IMicrophone>();
                //    //主线程
                //    Console.WriteLine($"microphone1&2------{Thread.CurrentThread.ManagedThreadId}");

                //    //重新开启一个子线程
                //    new Action(() =>
                //    {
                //        Console.WriteLine($"microphone3----------{Thread.CurrentThread.ManagedThreadId}");
                //        microphone3 = container.Resolve<IMicrophone>();

                //    }).BeginInvoke(null,null);


                //    //重新开启一个子线程
                //    new Action(() =>
                //    {
                //        Console.WriteLine($"microphone4--------{Thread.CurrentThread.ManagedThreadId}");
                //        microphone4 = container.Resolve<IMicrophone>();

                //    }).BeginInvoke(ar=> {

                //        Console.WriteLine($"microphone5----------{Thread.CurrentThread.ManagedThreadId}");
                //        microphone5 = container.Resolve<IMicrophone>();
                //    }, null);

                //    Task.Run(() =>
                //    {
                //        Console.WriteLine($"microphone6----------{Thread.CurrentThread.ManagedThreadId}");
                //        microphone6 = container.Resolve<IMicrophone>();
                //    });

                //    Thread.Sleep(5000);

                //    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone2)}");
                //    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone3)}");
                //    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone4)}");
                //    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone5)}");
                //    Console.WriteLine($"{object.ReferenceEquals(microphone3, microphone4)}");
                //    Console.WriteLine($"{object.ReferenceEquals(microphone3, microphone5)}");
                //    Console.WriteLine($"{object.ReferenceEquals(microphone4, microphone5)}");
                //    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone6)}");

                //}


                //升级自己的IOC容器(变成有对象生命周期)
                {
                    IContainer container = new Container();

                    container.RegisterType<IMicrophone, Microphone>(new BOBOPerThreadLifetimeManager());

                    //IMicrophone phone1 = container.Resolve<IMicrophone>();
                    //IMicrophone phone2 = container.Resolve<IMicrophone>();


                    //Console.WriteLine($"{object.ReferenceEquals(phone1, phone2)}");



                    IMicrophone microphone1 = null;
                    IMicrophone microphone2 = null;
                    IMicrophone microphone3 = null;
                    IMicrophone microphone4 = null;
                    IMicrophone microphone5 = null;
                    IMicrophone microphone6 = null;


                    microphone1 = container.Resolve<IMicrophone>();
                    microphone2 = container.Resolve<IMicrophone>();
                    //主线程
                    Console.WriteLine($"microphone1&2------{Thread.CurrentThread.ManagedThreadId}");

                    //重新开启一个子线程
                    new Action(() =>
                    {
                        Console.WriteLine($"microphone3----------{Thread.CurrentThread.ManagedThreadId}");
                        microphone3 = container.Resolve<IMicrophone>();

                    }).BeginInvoke(null, null);


                    //重新开启一个子线程
                    new Action(() =>
                    {
                        Console.WriteLine($"microphone4--------{Thread.CurrentThread.ManagedThreadId}");
                        microphone4 = container.Resolve<IMicrophone>();

                    }).BeginInvoke(ar =>
                    {

                        Console.WriteLine($"microphone5----------{Thread.CurrentThread.ManagedThreadId}");
                        microphone5 = container.Resolve<IMicrophone>();
                    }, null);

                    Task.Run(() =>
                    {
                        Console.WriteLine($"microphone6----------{Thread.CurrentThread.ManagedThreadId}");
                        microphone6 = container.Resolve<IMicrophone>();
                    });

                    Thread.Sleep(5000);

                    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone2)}");
                    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone3)}");
                    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone4)}");
                    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone5)}");
                    Console.WriteLine($"{object.ReferenceEquals(microphone3, microphone4)}");
                    Console.WriteLine($"{object.ReferenceEquals(microphone3, microphone5)}");
                    Console.WriteLine($"{object.ReferenceEquals(microphone4, microphone5)}");
                    Console.WriteLine($"{object.ReferenceEquals(microphone1, microphone6)}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
