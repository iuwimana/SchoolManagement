using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS
{
    /// <summary>
    /// Interface for storage methods used by StaticStorage
    /// </summary>
    public interface IStaticStorageStrategy
    {
        void Set(Type classType, string variablename, object value);

        object Get(Type classType, string variablename);
    }

    /// <summary>
    /// Static storage strategy that uses static (global) variable
    /// to store values.
    /// </summary>
    public class DefaultStaticStorage : IStaticStorageStrategy
    {
        private Dictionary<object, Dictionary<string, object>> storage = new Dictionary<object, Dictionary<string, object>>();

        public void Set(Type classType, string variablename, object value)
        {
            Dictionary<string, object> classDict;
            if (!storage.TryGetValue(classType, out classDict))
            {
                classDict = new Dictionary<string, object>();
                storage.Add(classType, classDict);
            }
            else
            {
                classDict.Remove(variablename);
            }
            classDict.Add(variablename, value);
        }

        public object Get(Type classType, string variablename)
        {
            object val = null;
            Dictionary<string, object> classDict;
            if (storage.TryGetValue(classType, out classDict))
            {
                classDict.TryGetValue(variablename, out val);
            }
            return val;
        }
    }

    /// <summary>
    /// Class for storing static (global) data that allows clients to plug in
    /// different storage implementations e.g. standard static variables for client/server
    /// app or per request storage for web app.
    /// 
    /// By default uses regular static variable to store values but can plug in
    /// a different strategy using SetStorageStrategy.
    /// </summary>
    public static class StaticStorage
    {
        private static IStaticStorageStrategy strategy = new DefaultStaticStorage();

        /// <summary>
        /// Set storage strategy to use
        /// </summary>
        /// <param name="strategy">storage strategy to set</param>
        public static void SetStorageStrategy(IStaticStorageStrategy strategy)
        {
            StaticStorage.strategy = strategy;
        }

        /// <summary>
        /// Set value in static storage
        /// example: Set(typeof(Foo), "bar", 42) is equivalent to Foo.bar=42
        /// </summary>
        /// <param name="classType">Type of class that static is associated with</param>
        /// <param name="variablename">Name of static variable </param>
        /// <param name="value">Value to set</param>
        public static void Set(Type classType, string variablename, object value)
        {
            strategy.Set(classType, variablename, value);
        }

        /// <summary>
        /// Get value from static storage
        /// example: i = (int) Get(typeof(Foo), "bar") is equivalent to i = Foo.bar
        /// </summary>
        /// <param name="classType">Type of class that static is associated with</param>
        /// <param name="variablename">Name of static variable</param>
        /// <returns>value that was previously set or null if no value was previously set</returns>
        public static object Get(Type classType, string variablename)
        {
            return strategy.Get(classType, variablename);
        }

    }
}
