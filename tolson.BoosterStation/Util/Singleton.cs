using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tolson.BoosterStation.Util
{
    public abstract class Singleton<T> where T : class
    {
        private static readonly Lazy<T> instance = new Lazy<T>(CreateInstanceOfT);
        public static T Instance => instance.Value;

        protected Singleton() { }

        private static T CreateInstanceOfT()
        {
            // 通过反射创建实例
            return (T)Activator.CreateInstance(typeof(T), true);
        }
    }
}
