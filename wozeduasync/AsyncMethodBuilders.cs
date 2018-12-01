using System.Threading.Tasks;

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
        public Task<T> Task => _source.Task;

        private readonly TaskCompletionSource<T> _source;

        private AsyncTaskMethodBuilder(TaskCompletionSource<T> source) 
        { 
            _source = source; 
        }

        public static AsyncTaskMethodBuilder<T> Create() 
        { 
            return new AsyncTaskMethodBuilder<T>(new TaskCompletionSource<T>()); 
        }

        public void SetException(Exception e) 
        { 
            _source.SetException(e); 
        }

        public void SetResult(T result) 
        { 
            _source.SetResult(result); 
        }

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
}
#pragma warning restore CS0436 // Type conflicts with imported type