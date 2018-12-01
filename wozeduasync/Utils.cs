using System;
using System.Threading;

namespace wozeduasync
{
    class Utils
    {
        private static readonly DateTime StartTime = DateTime.UtcNow;

        public static void Log(string text) 
        { 
            Console.WriteLine("Thread={0}. Time={1}ms. Message={2}", 
                Thread.CurrentThread.ManagedThreadId, 
                (DateTime.UtcNow - StartTime).TotalMilliseconds,
                text);
        }
    }
}
