using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tolson.BoosterStation.Util
{
    /// <summary>
    /// 单例类，所有继承此类的子类，通过subClass.Instance获取单例对象。
    /// 建议子类将构造函数定义为private。
    /// 已考虑多线程并发场景。
    /// 1）通过Lazy<T>类型保证线程安全。
    ///    Lazy<T> 类型的默认构造函数使用 LazyThreadSafetyMode.ExecutionAndPublication 模式，
    ///    这意味着 Lazy<T> 实例会确保在多线程环境中 Value 属性的初始化过程是安全的，
    ///    并且初始化的值会被所有线程看到。
    /// 2）通过(T)Activator.CreateInstance(typeof(T), true);创建实现类,
    ///    这样Singleton的子类可以将构造函数定义为private,
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
