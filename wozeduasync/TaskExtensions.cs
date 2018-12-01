using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    public static class TaskExtensions 
    { 
        public static TaskAwaiter<T> GetAwaiter<T>(this Task<T> task) 
        { 
            return new TaskAwaiter<T>(task); 
        }

        public struct TaskAwaiter<T> 
        { 
            public bool IsCompleted => _task.IsCompleted;
            private readonly Task<T> _task;

            internal TaskAwaiter(Task<T> task) 
            { 
                _task = task;
            }

            public void OnCompleted(Action action) 
            { 
                var context = SynchronizationContext.Current; 
                var scheduler = context == null ? TaskScheduler.Current 
                    : TaskScheduler.FromCurrentSynchronizationContext(); 
                _task.ContinueWith(ignored => action(), scheduler); 
            }

            public T GetResult() 
            { 
                return _task.Result; 
            } 
        }
    }
}