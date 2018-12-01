# eduasync

Written following Jon Skeet's blog: https://codeblog.jonskeet.uk/2011/05/13/eduasync-part-3-the-shape-of-the-async-method-awaitable-boundary/

Written using dotnet core 2.1, so things have changed a bit since Jon wrote the above.

To see the generated code with dotPeek, open the build dll with dotPeek,
right-click on wozeduasync->Program and select Decompiled Sources.

# questions to answer

- what is async/await? is it just running stuff on background threads?
- what runs the callback when an awaitable completes?
- what happens when you don't await an async method?
- why is async void bad?
- why is task.result / task.wait bad?
- how do deadlocks occur?
- why did TOS crash due to an async void?
- how does javascript's async/await compare to .net?

# notes from channel9 reference. TODO: integrate these into nice flowing readme

- not threading. point of async is to free up threads.
	- note that Task.Run executes stuff on a background thread, but
	  is a separate concept to async/await
	- async ends up waiting for something that is usually happening somewhere
	  other than the cpu: HDD, network etc. Thus it is actually happening in
	  parallel, but not on a thread. See https://stackoverflow.com/questions/37419572/if-async-await-doesnt-create-any-additional-threads-then-how-does-it-make-appl
- avoid async void, since no task to put execution info on, thus
	- can't await
	- can't get result/exception
	- can't get anything
	- return either Task or Task<T>
	- async void exists solely for event handlers
- don't block async methods, can cause deadlock
	- eg. avoid Task.Wait(), Task.Result
	- Hard to explain without an example, but I'll try: An async method and it's
	  caller can execute in the same thread, so if the caller does a blocking
	  wait on the async method, it blocks execution of the thread, thus the async
	  method never completes. Simple!
- when changing a method from sync to async, change the entire call chain to async
  to avoid deadlock issues. If you can't, you're probably doing it wrong:
	- constructors can not & should not be async
	- properties should not be async - make them methods

	questions
- what happens when you don't await an async method?
	- result is ignored, including exceptions. However we've seen these exceptions
	  crashing TOS before, why? Don't quite get this part.

# references

- https://channel9.msdn.com/Events/MVP-Virtual-Conference/MVP-Virtual-Conference-Americas-2015/Dev2-Surviving-in-an-Async-First-Development-World
- https://codeblog.jonskeet.uk/2011/05/08/eduasync-part-1-introduction/