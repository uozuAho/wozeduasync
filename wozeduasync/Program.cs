using System.Threading.Tasks;

namespace wozeduasync
{
    class Program
    {
        static void Main(string[] args)
        { 
            DoNothingAsync(); 
        }

// Warning CS1998 is about a method with no awaits in… exactly what we’re trying to 
// achieve! 
#pragma warning disable 1998
        // Return type of void, Task or Task<int> 
        private static async void DoNothingAsync()
        {
            // await Task.Run(() => Task.Delay(10));
        } 
#pragma warning restore 1998 
    }
}

#pragma warning disable CS0436 // Type conflicts with imported type
// note that we're overriding the default async stuff that comes with c# (language?)
namespace System.Runtime.CompilerServices 
{ 
    public struct AsyncVoidMethodBuilder 
    {
        public static AsyncVoidMethodBuilder Create()
        { 
            return new AsyncVoidMethodBuilder(); 
        }

        public void SetException(Exception e) {} 
        public void SetResult() {}

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
        }

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
        {
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
        }
    }

    public struct AsyncTaskMethodBuilder 
    { 
        public static AsyncTaskMethodBuilder Create() 
        { 
            return new AsyncTaskMethodBuilder(); 
        }

        public void SetException(Exception e) {} 
        public void SetResult() {} 
        public Task Task { get { return null; } } 
    }

    public struct AsyncTaskMethodBuilder<T> 
    { 
        public static AsyncTaskMethodBuilder<T> Create() 
        { 
            return new AsyncTaskMethodBuilder<T>(); 
        }

        public void SetException(Exception e) {} 
        public void SetResult(T result) {} 
        public Task<T> Task { get { return null; } } 
    } 
}
#pragma warning restore CS0436 // Type conflicts with imported type