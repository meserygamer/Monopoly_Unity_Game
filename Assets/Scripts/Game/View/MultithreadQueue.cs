using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game.View
{
    public class MultiThreadQueue : MonoBehaviour
    {
        private static readonly Queue<Action> _multithreadQueue = new Queue<Action>();
        private static object _lock = new object();


        private void Update()
        {
            while (_multithreadQueue.Count > 0)
            {
                Action action = _multithreadQueue.Dequeue();
                action.Invoke();
            }
        }


        public static void AddInMultithreadQueue(Action action)
        {
            lock (_lock)
            {
                _multithreadQueue.Enqueue(action);
            }
        }
    }
}