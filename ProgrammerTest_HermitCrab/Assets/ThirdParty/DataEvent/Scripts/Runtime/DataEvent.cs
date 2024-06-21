using System;
using System.Collections.Generic;

namespace DataEvent
{
    public class DataEvent
    {
        /// <summary>
        /// Dictionary of the observers
        /// The key (int) is the hash of the event and the list of objects represents the methods registered in that event
        /// </summary>
        private static Dictionary<int, List<object>> _observers;

        static DataEvent()
        {
            _observers = new Dictionary<int, List<object>>();
        }

        /// <summary>
        /// Registers a method to the event
        /// </summary>
        /// <param name="observer">Method that will be called when the event T is fired.</param>
        /// <typeparam name="T">Type of the event.</typeparam>
        public static void Register<T>(Action<T> observer) where T : struct
        {
            var hash = GetGenericHash<T>();

            if (!_observers.TryGetValue(hash, out List<object> list))
            {
                list = new List<object>();
            }

            list.Add(observer);

            _observers[hash] = list;
        }

        /// <summary>
        /// Unregisters a method from the event.
        /// </summary>
        /// <param name="observer">Method to be unregistered from the event.</param>
        /// <typeparam name="T">Type of the event.</typeparam>
        public static void Unregister<T>(Action<T> observer) where T : struct
        {
            var hash = GetGenericHash<T>();

            if (!_observers.ContainsKey(hash)) return;
            if (!_observers.TryGetValue(hash, out List<object> list)) return;
            
            list.Remove(observer);
            
            if (list.Count == 0)
            {
                _observers.Remove(hash);
            }
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="value">Struct of the event.</param>
        /// <typeparam name="T">Type of the event.</typeparam>
        public static void Notify<T>(T value) where T : struct
        {
            if (!_observers.TryGetValue(GetGenericHash<T>(), out List<object> list))
            {
                list = new List<object>();
            }

            for (int i = 0; i < list.Count; i++)
            {
                ((Action<T>)list[i])?.Invoke(value);
            }
        }

        /// <summary>
        /// Returns the HashCode from the event.
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <returns>HashCode (int).</returns>
        private static int GetGenericHash<T>()
        {   
            return typeof(T).GetHashCode();
        }
    }
}