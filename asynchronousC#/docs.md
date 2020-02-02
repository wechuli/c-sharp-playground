# Asynchronous Programming

If you have any I/O bound needs (such as requesting data from a network or accessing a database), you'll want to utilize asynchronous programming. You could also have a CPU-bound code, such as performing an expensive calculation, which is also a good scenario for writing `async` code.

C# has a language-level asynchronous programming model which allows for easily writing asynchronous code without having to juggle callbacks or conform to a library which supports asynchrony. It follows what is known as the Task-based Asynchronous Pattern (TAP).

## Basic Overview of the Asynchronous Model

The core of `async` programming is the `Task` and `Task<T>` objects, which model asynchronous operations. They are supported by the `async` and `await` keywords.

For I/O-bound code, you `await` an operation which returns a `Task` or `Task<T>` inside of an `async` method. For CPU-bound code, you `await` an operation which is started on a background thread with the `Task.Run` method.

The `await` keyword is where the magic happens. It yields control to the caller of the method that performed `await`, and it ultimately allows a UI to be responsive or a service to be elastic.

## Key Pieces to Understand

- Async code can be used for both I/O bound and CPU-bound code, but differently for each scenario
- Async code uses `Task<T>` and `Task`, which are constructs used to model work being done in the background
- The `async` keyword turns a method into an async method, which allows you to use the `await` keyword in its body
- When the `await` keyword is applied, it suspends the calling method and yields control back to its caller until the awaited task is complete
- `await` can only be used inside an async method.

## Recognize CPU-Bound and I/O-Bound Work

It's key that you can identify when a job you need to do is I/O-bound or CPU-bound, because it can greatly affect the performance of your code and could potentially lead to misusing certain constructs.

1. Will your code be 'waiting' for something, such as data from a database ? If yes, then your work is I/O-bound
2. Will your code be performing a very expensive computation ? If yes, then tour work is CPU-bound

If the work you have is I/O-bound, use async and await without Task.Run. You should not use the Task Parallel Library. The reason for this is outlined in the Async in Depth article.

If the work you have is CPU-bound and you care about responsiveness, use async and await but spawn the work off on another thread with Task.Run. If the work is appropriate for concurrency and parallelism, you should also consider using the Task Parallel Library.

Additionally, you should always measure the execution of your code. For example, you may find yourself in a situation where your CPU-bound work is not costly enough compared with the overhead of context switches when multithreading. Every choice has its tradeoff, and you should pick the correct tradeoff for your situation.

## Multiple Tasks

You may find yourself in a situation where you need to retrieve multiple pieces of data concurrently. The `Task` API contains two methods, `Task.WhenAll` and `Task.WhenAny` which allow you to write asynchronous code which performs a non-blocking wait on multiple background jobs.

```C#
public async Task<User> GetUserAsync(int userId)
{
    // Code omitted:
    //
    // Given a user Id {userId}, retrieves a User object corresponding
    // to the entry in the database with {userId} as its Id.
}

public static async Task<IEnumerable<User>> GetUsersAsync(IEnumerable<int> userIds)
{
    var getUserTasks = new List<Task<User>>();

    foreach (int userId in userIds)
    {
        getUserTasks.Add(GetUserAsync(userId));
    }

    return await Task.WhenAll(getUserTasks);
}
```

## Important Info and Advice

Although async programming is relatively straighforward, there are some details to keep in mind which can prevent unexpected behavior.

1. `async` methods need to have an `await` keyword in their body or they will never yield!
2. You should add `Async` as the suffix of every method name you write. This is the convention used in .NET to more-easily differentiate synchronous and asynchronous methods. Note that certain methods which aren’t explicitly called by your code (such as event handlers or web controller methods) don’t necessarily apply. Because these are not explicitly called by your code, being explicit about their naming isn’t as important.
3. `async void` should only be used for event handlers.

   - Exceptions thrown in an async void method can’t be caught outside of that method.

   - async void methods are very difficult to test.

   - async void methods can cause bad side effects if the caller isn’t expecting them to be async.

4. Tread carefully when using async lambdas in LINQ expressions- Lambda expressions in LINQ use deferred execution, meaning code could end up executing at a time when you’re not expecting it to. The introduction of blocking tasks into this can easily result in a deadlock if not written correctly. Additionally, the nesting of asynchronous code like this can also make it more difficult to reason about the execution of the code. Async and LINQ are powerful, but should be used together as carefully and clearly as possible.

5. Write code that awaits Tasks in a non-blocking manner
   Blocking the current thread as a means to wait for a Task to complete can result in deadlocks and blocked context threads, and can require significantly more complex error-handling. The following table provides guidance on how to deal with waiting for Tasks in a non-blocking way:

Use this... Instead of this... When wishing to do this
await Task.Wait or Task.Result Retrieving the result of a background task
await Task.WhenAny Task.WaitAny Waiting for any task to complete
await Task.WhenAll Task.WaitAll Waiting for all tasks to complete
await Task.Delay Thread.Sleep Waiting for a period of time

6. Write less stateful code
   Don’t depend on the state of global objects or the execution of certain methods. Instead, depend only on the return values of methods. Why?

- Code will be easier to reason about.
- Code will be easier to test.
- Mixing async and synchronous code is far simpler.
- Race conditions can typically be avoided altogether.
- Depending on return values makes coordinating async code simple.
- (Bonus) it works really well with dependency injection.
