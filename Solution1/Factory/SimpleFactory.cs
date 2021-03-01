using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IDLL;

namespace Factory
{
    public class SimpleFactory
    {
        private static string IServicePhone = ConfigurationManager.AppSettings["IServicePhone"];


        public static IServicePhone CreateService()
        {
            Assembly assembly = Assembly.Load(IServicePhone.Split(',')[0]);

            Type type = assembly.GetType(IServicePhone.Split(',')[1]);

            return (IServicePhone)Activator.CreateInstance(type);
        }


        private static string AbstractPhone = ConfigurationManager.AppSettings["AbstractPhone"];


        public static AbstractPhone CreateAbstractPhone()
        {
            Assembly assembly = Assembly.Load(AbstractPhone.Split(',')[0]);

            Type type = assembly.GetType(AbstractPhone.Split(',')[1]);

            return (AbstractPhone)Activator.CreateInstance(type);
        }
    }
}
