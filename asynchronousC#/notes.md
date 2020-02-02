# Asynchronous Programming in C# and .NET Core

When a computer is running a program, the operating system or the application allocates a group of resources; known as a thread; to run the application code.

In synchronous programming, all the code from on application is running on a single thread. Therefore, code has to execute synchronously which means code is executed in a one action at a time. One operation has to finish before the processor moves on to execute the next operation. That means if one operation is taking a long time, the program will freeze and stop waiting for it to finish before it moves to the next operation.

An asynchronous operation is an operation that runs on a separate thread that gets initiated from another thread. The thread that initiates an asynchronous operation does not need to wait for that operation to complete before it can continue. In that sense, resources can be allocated to other tasks that can be executed in the meantime.

## Why Use Asynchronous Programming

Asynchronous programming makes the best and most efficient utilization of the machine resources when it comes to having long running operations in an application. For a UI application, Asynchronous programming makes the application responsive because the UI thread is not blocked by a CPU or I/O heavy operation which makes it more interactive and user friendly. Asynchronous programming also takes advantage of parallel computing which is supported in most of today's machines. This helps programmers write parallel processing applications easily without having to write complicated code that is hard to maintain.

## When to use Asynchronous Programming

Asynchronous code is best used for long running operations. Those operations can be CPU bound or I/O bound operations. Examples of long running operations are:

- I/O operations that include Network requests for data retrieval
- CPU heavy operations like scientific calculations using huge data sets
- I/O operations like disk access operations including reading and writing to disks

If you have any I/O-bound needs (such as requesting data from a network or accessing a database), you'll want to utilize asynchronous programming so that your program UI does not freeze waiting for this operation to finish.

## What applications are best candidates for asynchronous programming ?

- **Desktop User Interface Applications** - a desktop UI application is an application that is expected to be interactive, users should be able to interact and communicate with the various pieces of the application UI mostly at all times. Nothing is worse for an UI application than a frozen control that the user is unable to interact with because of a long running network operation like a web service call. The time spent waiting for information to travel across the network is blocking the UI resources and thus the application appears to be frozen or dead.
  Desktop / UI modern frameworks give special precedence to the thread that uses the UI. Async code is very important for these technologies to build better UI applications. Examples of UI technologies that use asynchronous programming are:

Windows Forms (WinForms)
Windows Presentation Foundation (WPF)
Universal Windows Platform (UWP)

- **Web Server Applications** - a web server application does not deal with UI but often times, it needs to run remote database queries or run some calculations on large amounts of data to generate a data analysis report. Using Asynchronous programming for these tasks allows the server code to do the task efficiently specially that web servers are usually handling multiple requests from multiple clients at the same time. Asynchronous programming helps avoid situations where threads are simply waiting to do something while the rest of the application is getting overwhelmed by clients requests resulting in less than ideal performance as well as delayed responsiveness to clients requests.

## When not to use Asynchronous Programming

There are problems that asynchronous code does not solve. There are also problems that Asynchronous code can cause. For example:

1. Asynchronous code does not automatically improve performance. If a network task takes a certain amount of time, asynchronous code is not going to change that. In fact, there is some amount of (small) overhead for the framework managing the process. Rather, asynchronous code helps manage resources more efficiently.
2. Using Asynchronous code imposes an overhead on the system. When threads are used, the system needs a way to manage them like thread saving, scheduling, listening, locking, resuming, ...etc. There are two types of overhead that exist when using threads, memory overhead which every thread reserves from a machine's virtual memory when initiated, and a scheduler overhead which is the way the operating system uses to manage choosing which thread should be executed on which CPU and when. These overheads can slow down the entire system if threads are excessively used.
3. If you don't have a desktop / UI application, or your code is not network- or I/O-bound, you won't see much benefit.
4. If your application is CPU-bound (it is slowing down because of heavy compute processes), multi-threading / task-based asynchrony is a better solution.

Asynchronous operations are closely related to tasks. The .NET Framework support for `async` programming makes it easier to perform asynchronous operations by transparently creating new tasks and coordinating their actions on your behalf. In particular, the built-in `async` and await keywords are the heart of `async` programming in C#. They enable you to invoke an asynchronous operation and wait for the result within a single method, without blocking the thread.
Asynchronous methods that you define by using `async` and await are referred to as `async` methods.

```C#
// Three things to note in the signature:
//  - The method has an async modifier.
//  - The return type is Task or Task<T>.
//  Here, it is Task<int> because the return statement returns an integer.
//  - The method name ends in "Async."
async Task<int> AccessTheWebAsync()
{
	// You need to add a reference to System.Net.Http to declare client.
	HttpClient client = new HttpClient();
	// GetStringAsync returns a Task<string>. That means that when you await the task you'll get a string (urlContents).

	Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
	// You can do work here that doesn't rely on the string from GetStringAsync.
	DoIndependentWork();
	// The await operator suspends AccessTheWebAsync.
	//  - AccessTheWebAsync can't continue until getStringTask is complete.
	//  - Meanwhile, control returns to the caller of AccessTheWebAsync.
	//  - Control resumes here when getStringTask is complete.
	//  - The await operator then retrieves the string result from getStringTask.
	string urlContents = await getStringTask;
	// The return statement specifies an integer result.
	// Any methods that are awaiting AccessTheWebAsync retrieve the length value.
	return urlContents.Length;
}

```

## What Makes an async method ?

- The method signature includes an `async` modifier
- The name of an async method, by convention ends with an "Async" suffix
- The return type is one of the following types
  - `Task<TResult>`
  - `Task`
  - `void`
- The method includes at least one await expression

which marks a point where the method can't continue until the awaited asynchronous operation is complete. In the meantime, the method is suspended, and control returns to the method's caller.

As mentioned, the core of asynchronous programming are the Task and Task<T> objects, which model asynchronous operations. They are supported by the async and await keywords. In C#, a Task object can be thought of as an ongoing operation. An object of the subclass Task<T> is an operation that will have a result of type T at some point in the future. It is like a promise of a T when the awaited operation completes.

The model is fairly simple in most cases:

**For I/O-bound code** - you await an operation which returns a `Task` or `Task<T>` inside of an async method
**For CPU-bound code** - you await an operation which is started on a background thread with the Task.Run method.

## Async method support in .NET Classes

The .NET Framework 4.5 or higher and .NET Core contain many members that work with async and await. You can recognize them by the “Async” suffix that’s appended to the member name, and by their return type of Task or Task<TResult>. For example, the System.IO.Stream class contains methods such as CopyToAsync, ReadAsync, and WriteAsync alongside the synchronous methods CopyTo, Read, and Write.

The Windows Runtime also contains many methods that you can use with async and await in Windows apps.

The .Net Core framework has a rich support for async methods. Types in the .Net Core framework that have support for the async methods include

### Network-oriented classes with async methods

1. **HttpClient**: Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI
2. **WebClient**: provides common methods for sending data to and receiving data from a resource identified by a URI

### Files I/O -oriented classes with async methods

1. **StreamWriter**: provides methods for writing characters to a stream in a particular encoding
2. **StreamReader**: this class allows reading of characters from a byte stream in a particular encoding
3. **XmlReader**: a class that represents a reader that provides a fast, non-cached, forward-only access to XML data.

## Characteristics of an Async Method in .NET Core

1. **Use the async keyword in the method declaration**

Use the `async` modifier to specify that a method, lambda expression or anonymous method is asynchronous.

```C#
public async Task<int> ExampleMethodAsync()
{
    // . . . .
}
```

2. **Use the await keyword in the code calling an asynchronous process/method**

The await operator is applied to a task in an asynchronous method to insert a suspension point in the execution of the method until the awaited task completes. The task represents ongoing work or a promise. It is not until you await on an async method call that it is actually executing. When you call an `async` method without using await, you only receive a promise (Task) that you can await on later. This task will give you the promised return type after it completes. In C# syntax, await acts as a unary operator. It is placed to the left of an expression and means to wait for that expression asynchronously with no blocking. If you apply await to a Task<T>, it becomes an await expression, and the whole expression has type T. That means you can assign the result of awaiting to a variable of type T and use it in the rest of the method.

`await` can only be used in an `async` method modified by the `async` keyword.

If await is applied to the result of a method call that returns a `Task<TResult>`, then the type of the `await` expression is `TResult`. If `await` is applied to the result of a method call that returns a `Task`, then the type of the `await` expression is `void`.

```C#

// await keyword used with a method that returns a Task<TResult>.
TResult result = await AsyncMethodThatReturnsTaskTResult();

// await keyword used with a method that returns a Task.
await AsyncMethodThatReturnsTask();

// await keyword used with a method that returns a ValueTask<TResult>.
TResult result = await AsyncMethodThatReturnsValueTaskTResult();

```

3. **Use one of the correct return types in the `async` method to get results**

Return types for an `async` method need to be one of the following

- `Task<TResult>` if your method has a return statement in which the operand has type TResult.
- `Task` if your method has no return statement or has a return statement with no operand.
- `void` if you're writing an `async` event handler.
- Any other type that has a `GetAwaiter` method (starting with C# 7).

4. **Adding the “Async” suffix at the end of the method name. This is not required but is considered a convention for writing `async` methods in C#.**

```C#
public async Task<int> ExampleMethodAsync()
{
    // . . . .
}
```

5. **Include at least one await expression in the async method code.**

The marked async method can use await to designate suspension points. The await operator tells the compiler that the async method can't continue past that point until the awaited asynchronous process is complete. In the meantime, control returns to the caller of the async method. The suspension of an async method at an await exression doesn't constitute an exit from the method, and finally blocks don't run.

```C#
public async Task<int> ExampleMethodAsync()
{
	//some code
	string pageContents = await client.GetStringAsync(uri);
	//some more code
	return pageContents.Length;
}

```

Although an async method typically contains one or more occurrences of an await operator, the absence of await expression doesn't cause a compile error. If an async method doesn't use an await operator to mark a suspension point, the method executes as a synchronous method does, despite the async modifier. The compiler issues a warning for such methods.

## Creating Async Methods

### When to use Async methods in your code

It may seem like using async programming in all your code is a good idea. Well, this is not correct. Async programming is best usefult in certain scenarios and use cases. Consider the following questions during your code design to decide whether async is the best practice for your application

1. Will your code be waiting for something to happen ? For instance, will it be integrating with web services?
2. Are you leveraging a library/method that is already asynchronous
3. Is your code likely to have multiple simultaneous users ?
4. Are you developing an application with a desktop/UI technology and responiveness is a key for the best user experience.

If the answer is yes to any of the questions above, then you may consider asynchronous programming.

If you choose to use asynchronous programming then your next step is to identify the entry point of asynchronous code. This means identifying where the async methods should start and where to await on calls. For example, consider where a web service will be called in the code and when (when a user clicks on a button for example, or web server receives a request from a client).

Another strategy is to start with synchronous code with network- or I/O bound code. Then work on converting your synchronous code to asynchronous code by doing the following:

Add await keyword for calling code.
Add async keyword for the method doing the await call.
Adjust return types.
Adjust calling methods on the call stack, to also be asynchronous.

## Understanding what is happening

In async methods, you use the proper keywords and types to indicate what you want to do, and the compiler does the rest, including keeping track of what must happen when control returns to an await point in a suspended method.

The .NET Framework simplifies many operations to allow methods to be async. It does a lot of work that you do not have to write code for unless you were writing asynchronous code manually. Examples of these operations are :

1. Saving state
2. Saving the parameters of your method
3. Saving local variables; any other variables in scope

The .NET Framework saves the location in your method where the asynchronous thread starts to be able to resume back to the right step in the execution.

The .NET Framework saves context of the current thread which includes:

- Execution Context
- Security Context
- Call Context

The most important thing to understand in asynchronous programming is how the control flow moves from method to method.

![](assets/process.PNG)

1. An event handler calls and awaits the `AccessTheWebAsync` async method.
2. `AccessTheWebAsync` creates an HttpClient instance and calls the `GetStringsAsync` asynchronous method to download the contents of a website as a string
3. Something happens in `GetStringAsync` that suspends its progress. Perhaps it must wait for a website to download or some other blocking activity. To avoid blocking resources, `GetStringAsync` yields control to its called, `AccessTheWebAsync`. `GetStringAsync` returns a `Task<TResult>` where `TResult` is a string, the `AccessTheWebAsync` assigns the task to the `getStringTask` variable. The task represents the ongoing process for the call to `GetStringAsync`, with a commitment to produce an actual string value when the work is complete.
4. Because `getStringTask` hasn't been awaited yet, `AccessTheWebAsync` can continue with other work that doesn't depend on the final result from `GetStringAsync`. That work is represented by a call to the synchronous method `DoIndependentWork`.
5. `DoIndpendentWork` is a synchronous method that does its work and returns to its caller.
6. `AccessTheWebAsync` has run out of work that it can do without a result from `getStringTask`. `AccessTheWebAsync` next wants to calculate and return the length of the downloaded string but the method can't calculate the value until the method has the string. Therefore `AccessTheWebAsync` uses an await operator to suspend its progress and to yield control to the method that called `AccessTheWebAsync`. `AccessTheWebAsync` returns a `Task<int>` to the caller. The task represents a promise to produce an integer result that's the length of the downloaded string.

   Note:
   If `GetStringAsync` (and therefore getStringTask) is complete before `AccessTheWebAsync` awaits it, control remains in `AccessTheWebAsync`. The expense of suspending and then returning to `AccessTheWebAsync` would be wasted if the called asynchronous process (getStringTask) has already completed and `AccessTheWebSync` doesn't have to wait for the final result.

Inside the caller (the event handler in this example), the processing pattern continues. The caller might do other work that doesn't depend on the result from `AccessTheWebAsync` before awaiting the result, or the caller might `await` immediately. The event handler is waiting for `AccessTheWebAsync` and the `AccessTheWebAsync` is waiting for `GetStringAsync`.

7. `GetStringAsync` completed and produces a string result. The string result isn't returned by the call to `GetStringAsync` in the way that you might expect. (Remember that the method already returned a task in step 3.) Instead, the string result is stored in the task that represents the completion of the method, getStringTask. The await operator retrieves the result from getStringTask. The assignment statement assigns the retrieved result to `urlContents`.
8. When AccessTheWebAsync has the string result, the method can calculate the length of the string. Then the work of AccessTheWebAsync is also complete, and the waiting event handler can resume. In the full example at the end of the topic, you can confirm that the event handler retrieves and prints the value of the length result.

Note 1: Take a minute to consider the difference between synchronous and asynchronous behavior. A synchronous method returns when its work is complete (step 5), but an async method returns a task value when its work is suspended (steps 3 and 6). When the async method eventually completes its work, the task is marked as completed and the result, if any, is stored in the task.

Note 2: The async/await keywords are often referred to as “syntatic sugar”, meaning that it's an easier way to write async code that uses callback methods. That's true in the sense that results are the same, but there are some low-level differences, such as memory allocations or how the contexts mentioned above are treated.

Note 3: As a rule of thumb, any legacy async code with callbacks can be consumed or replaced with async/await.
