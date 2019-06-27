# Exception Handling

An exception is a notification that something interrupts the normal program execution.Exceptions provide a programming paradigm for detecting and reacting to unexpected events. When an exception arises, the state of the program is saved, the normal flow is interrupted and the control is passed to an exception handler(if such exists in the current context)

Exceptions are raised or thrown by programming code that must send a signal to the executing program about an error or an unusual situation. Exceptions are one of the main paradigms of object-oriented programming.

## Catching and Handling Exceptions

Exception handling is a mechanism, which allows exceptions to be thrown and caught. This mechanism is provided internally by the CLR(Common Language Runtime). Parts of the exception handling infrastructure are the language constructs in C# for thowing and catching exceptions.
Usually in OOP, a code executing some operation will cause an expetion if there is a problem and the operation could not be successfully completed. The method causing the operation could catch the exception(and handle the error) or pass the exception through to the calling method. This allows handling errors to be delegated to some upper level in the call stack and in general, allows flexible management of errors and unexpected situations.
Another fundamental concept is exceptions hierarchy. In OOP, exceptions are classes and they can be inherited to build hierarchies. When an exception is handled(caught), the handling mechanism could catch a whole class of exceptions and not just a particular error.

In OOP, it is recommended to use exceptions for managing error situations or unexpected events that may arise during a program execution. This replaces the procedural error-handling approach and gives important advantages such as centralized error processing, haandling multiple errors in one place and ability to pass errors to a higher-level handler. Another important advantage is that exceptions self-describe themselves and can create hierarchies.

Exception in .NET is an object, which signals an error or an event, which is not anticipated in the normal program flow. When such unusual events takes place, the executing method 'throws' a special object containing information about the type of the error, the place in the program where the error occured as well as the program state at the moment of the error.

Each exception in .NET contains the so-called stack trace, which gives information of where exactly the error occurred.

## How do Exceptions Work?

If during the normal program execution one of the methods throws an exception, the normal flow of the program is interrupted.

## Catching Exceptions

After a method throws an excpetion, CLR is looking for an exception handler that can process the error. To understand how this works, we need to take a closer look at the call stack.

The program call-stack is a stack structure that holds information about method calls, their local variables, method parameters and the nenory for value types.
.NET programs start from the Main() method, which is the entry point of the program. Another method, let's name is "Method1" could be called from Main.Let "Method1" call "Method2" and so on untly "Method N" is called.
When "Method N" finishes, the program flow returns back to its calling method(in our example it would be "Method N-1"), then back to its calling method and so on. This goes on until the Main() method is reached. Once Main() finished, the entire program exits.
The general principle is that when a new method is called, it is pushed on top of the stack. When the method finishes, it is pulled back from the stack.
The exception handling mechanism follows a reversed process. When an exception is thrown, CLR begins searching for an exception handler in the call stack starting from the method that has thrown the exeption. this is repeated for each of the methods doen the call-stack unitl a handler is found which catches the exception. If Main() is reached and no handler is found, CLR catches the exception and usually displays an error message.

![](errorhandling.png)

## The try-catch Programming Construct

To handle an exception, we must surround the code that could throw exception with a try-catch block:

```C#
try
{
    //some code that may throw an excpeiton
}
catch(ExceptionType objectName)
{
    // Code handling an Exception
}
catch(ExceptionType objectName)
{
//Code handling an exception
}
```

The try-catch constructs consists of one try block and one or more catch blocks. Within the try block we put code that cold throw excpetions. The ExceptionType in the catch block must be a type, derived from System.Exception or the code wouldn't compile. the expression within brackets after catch is also a declaration of a variable, thus inside the catch block, we can use objectName to use the properties of the excpetion or call its methods

## the Stack trace

The stack trace contains detailed information about the exception including where exaclty it occured in the program.The stack trace is very useful for programmers when they try to understand the problem causing the exception. During debugging, the stack trace is a priceless tool.

### Reading the Stack Trace

To be able to use the stack trace, we must be familiar with its structure. The stack trace contains the following information:

- The full name of the exception class
- A message with additional information about the error
- Information about the call stack
  Each line of the call stack dump contains something similar to the following:

          at <namespace>.<class>.<method> in <source file>.cs:line <line>

Every method is shown in a separate line. On the first line is the method that threw the exception and on the last line - the Main() method(notice that the Main() method might not be present in case of an exception thrown by a thread which is not the main thread of the program). Every method is given with full information about the class that contains it and (if possible) even the line in the source code.

The line numbers are included only if the respective class is compiled with debug infromation(this information contains line numbers, variable names and other technical information). The debug information is not included in the .NET assemblies but is in separate files called 'debug symbols'(.pdb).
If the method thowing the exception is a constructor, then instead of method name, the stack trace contains the word .ctor.

The rich information in the stack allows us to quickly and easily find the class, the method and even the source line where the error has occured

## Throwing Exceptions

Exceptions in C# are thrown using the keyword _throw_. We need to provide an instance of the exception, containing all the necessary information about the error. Exceptions are normal classes and the only requirement is that they inherit direclty or indirecly from the **System.Exception** class.

## Exceptions Hierarchy

There are two types of exceptions in .NET Framework: exceptions thrown by the applications we develop(ApplicationException) and exceptions thrown by the runtime(SystemException). Each of these is a base class for a hierarchy of exception classes.

![](exchier.png)

### the Exception Class

In .NET Framework, Exception is the base class for all exceptions. Several classes inherit directly from it, including ApplicationException and SystemException. These two classes are base classes for almost all exceptions that occur during the program execution.

The Exception class contains a copy of the call-stack at the time the exception instance was created. the class usually also has a short message describing the error (filled in by the method throwing the exception). Every exception could have a nested exception also sometimes called an inner exception, wrapped exception or internal exception.

The ability to wrap an exception with another exception is very useful in some cases and allows exceptions to be linked in the so called exception chain

### Aplication vs. system Exceptions

Exceptions in .NET are two types - system and application. System exceptions are defined in .NET libraries and are used by the framework, while applciation exceptions are defined by application developers and are used by the application software.
When we, as developers design our own exception classes, it is good practice to inherit from ApplicationException and not directly from SystemException(or even worse-direclty from Exception)

## Throwing and Catching Exceptions

### Nested Exceptions

Each exception could contain a nested(inner) exception.

In software engineering, it is good practice for every software component to define a small number of specific application exceptions. The component then would throw only these specific application exceptions and not the standard .NET exceptions. In this way, the users of the software component would know what exceptions could expect from it.

For instance, if we have a banking software and we have a component dealing with interests, this component would define (and throw) exceptions like InterestCalculationException and InvalidPeriodException. The interest component should not throw exceptions like FileNotFoundException, DivideByZeroException and NullReferenceException. When an error occurs, which is not directly related to interest calculation, the respective exception is wrapped in InterestCalculationException and the calling code will be informed that the interest calculation was not correctly done.

Still, these business application exceptions usually do not have detailed technical information about the nature of the problem. This is why, it is considered a good practice to include technical details about the problem and this is where inner exceptions come in handy. When the component throws its application exception, it should keep the original exception as an inner exception in order to preserve the technical details about the error.

Another example is when a software component (let’s call it Component A) defines its own application exceptions (A-exceptions). This component internally uses another component (called Component B). If for some reason B throws a B exception (an exception defined in B), perhaps A will have to propagate the error because it will not be able to do its task. And because A cannot simply throw a B-exception, it must throw an A-exception, containing the B-exception as a nested exception.

There could be various reasons why A cannot simply throw a B exception:

- Component A users should not even know Component B exists
- Component A had not declared it would throw Component B exceptions;
- Component A users are not prepared to receive Component B exceptions. They expect component A exceptions only.

### Which Exceptions to Handle and Which Not?

        A method should only handle exceptions which it expects and which it knows how to process. All the other exceptions must be left to the calling method.

If we follow this rule and every method leaves the exceptions it is not competent to process to the calling method, eventually we would reach the Main() method(or the starting method of the respective thread of execution) and if this method does not catch the exception, the CLR will display the error on the console and will terminate the program.

A method is competent to handle an exception if it expects this exception, it has information why the exception has been thrown and what to do in this situation.If we have a method that must read a text file and return its contents as a string, that method might catch FileNotFoundException and return an empty string in this case. Still, this same method will hardly be able to correctly handle OutOfMemoryException. What should the method do in case of insufficient memory? Return an empty string? Throw some other exception? Do something completely different? So apparently the method is not competent to handle such exception and thus the best way is to pass the exception up to the calling method so it could (hopefully) be handled at some other level by a method competent to do it. Using this simple philosophy allows exception handling to be done in a structured and systematic way.

Throwing exceptions from the Main() method is generally not a good practice. Instead it is better all exceptions to be caught in Main(). Every exception which is not handled in Main() is eventually caught by the CLR and visualized by printing the stack trace on the console output or in some other way. While for small applications it is not such a problem, big complex applications generally should not crash in such ungraceful manner.

### Catching Exceptions at Different Levels

The ability to pass(or bubble) exceptions through a given method up to the calling method allows structured exception handling to be done at multiple levels. This means that we can catch certain types of exceptions in given methods and pass all other exceptions to the previous leve;s in the call-stack.

### The try-finally Construct

Every try block could contain a respective finally block. The code within the finally block is always executed, no matter how the program flow leaves the try block. This gurantees that the finally block will be executed even if an exception is thrown or a return statement is executed within the try block.

```C#
try
{
// some code that could or could not cause an exception
}
finally
{
// Code here will always execute
}
```

Every try block may have zero or more catch blocks and at most one finally block. It is possible to have multiple catch blocks and a finally block in the same try-catch-finally constructs

```C#
try
{
//some code
}
catch (…)
{
// Code handling an exception
}
catch (…)
{
// Code handling another exception
}
finally
{
// This code will always execute
}
```

### Why Should We Use try-finally?

In many applications, we have to work with external resources in our programs. Examples of external resources include files, network connections, graphical elements, pipes and streams to or from different hardware devices. When we deal with such external resources, it is critically important to free up the resources as early as possible when the resource is no longer needed. For example, when we open a file to read its contents, we must close the file right after we have read the contents. If we leave the file open, the operating system will prevent other users and applications from making changes on the file.

The finally block is priceless when we need to free an external resource or make any other cleanup. The finally block guarantees that the cleanup operations will not be accidentally skipped because of the unexpected exception or because of return, continue or break. Proper resource management is an important concept in programming.

#### Mutlpitple Resources Cleanup

Sometimes we need to free more than one resource. It is a good practice to free the resources in reverse order in respect to their allocation.

```C#
static void readFile(string filename)
{
   Resource r1 = new Resource1();
try
{
Resource r2 = new Resource2();
try
{
// Use r1 and r2
}
finally
{
r2.Release();
}
}
finally
{
r1.Release();
}

```

## IDisposable and the "using" Statement

### IDisposable

The main use of IDisposable interface is to release resources. In .NET such resources are window handles, files, streams and other. For now, we may consider interface as an indication that given type of objects(for example streams for reading files) support a certain number of operations.

The important method in IDisposable interface is Dispose(). The main thing we need to know about the method is that is releases the resources of the class that implements it.In cases when resources are streams, readers or files releasing resorces can be done using the Dispose() method from IDisposable interface, which calls their Close() method. This method closes them and relesea their resources.

```C#
StreamReader reader = new StreamReader(fileName);
try
{
    //Use the reader here
}
finally
{
    if(reader != null)
    {
        reader.Dispose();
    }
}
```

The previous example can be written in shorter form with the help of the using keyword in C#

```C#
using(StreamReader reader = new StreamReader(fileName))
{
    //Use the reader here
}
```

The above simplified form of the 'dispose pattern' is simple to write, simple to use and simple to read and is guaranteed to release correctly the allocated resources specified in the brackets of the using statement.

It is not necessary to have try-finally or to explicitly call any method to release the resources. The compiler takes care to automatically put try-finally block and the used resources are released by calling the Dispose() method after leaving the using block.

It is important to mention that using statement is not related to exception handling. Its only purpose is to release the resources no matter whether exceptions are thrown or not. It does not handle exception.

Use the **using** statement with all classes that implement the IDidposable interface. When a class implements IDisposable interface this means the creator of this class expects it can be used with the using statement and the class contains some expensive resources that should not be left unreleased. Implementing IDisposable also means that it should be released immediately after we finnish using the class and the easiest way to do this in C# is with using statement.

### Advantages of Using Exceptions

1. **Separationg of the Exception Handling Code** - Using exceptions allow us to separate the code, which describes the normal execution of the program from code required for unexpected execution of the code for error handling. Exceptions not only save us the effort of finding and processing errors but give us more elegant, short, clear and efficient way to do it.
2. **Grouping Different Error Types** - The hierarchial nature of exceptions allows us to catch and handle whole groups of exceptions at one time. When using catch we are not only catching the given type of exception but the whole hierarchy of exception types that are inheritors of the declarred type.

```C#
   catch (IOException e)
{
// Handle IOException and all its descendants
}
```
The example above will catch not only the IOException, but all of its descendants including FileNotFoundException, EndOfStreamException, PathTooLongException and many others. In the same time exceptions like UnauthorizedAccessException and OutOfMemoryException will not be caught, because they don’t inherit from IOException. We can look in MSDN for the exceptions hierarchy if we wander which exceptions to catch.
It is not a good practice, but it is possible to catch all exceptions:
```C#
catch (Exception e)
{
// A (too) general exception handler
}
```
Catching Exception and all of its inheritors is not a good practice. It is better to catch more specific groups of exceptions like IOIException or just one type of exception like for example FileNotFoundException.

3. **Catching Exceptions at the Most Appropriate Place** - The ability to catch exceptions at multiple locations is extremely convenient. It allows us to handle the exceptioin at the most appropriate place. It is good to remeber the most important rule: every method should catch only exceptions that it can handle and skip all the others.


## Best Practices when using Exceptions
### When to Rely on Exceptions
It is not a good practixe to rely on exceptions for excpected events for another reason: performance. Throwing an exception is a time consuming. An object has to be created to hold the exception, the stack trace has to be initialized and handler for this exception has to be found and so on.

### Throw Exceptions to the End User?
Exceptions are confusing for most users. They give the impression of a poorly written program that 'has bugs'. It is recommended when exceptions are not caught by anyone(such exceptions can only be runtime errors) to be caught by a global exception handler which saves them on the disk and shows user friendly messages such as 'An error occurred, please try again later'. It is a good practice to show not only a user friendly message but also technocal information(stack trace) available on demand.

### Throw Exceptions at the Approprtiate Level of Abstraction
When we throw our own exceptions we must keep in mind the abstractions in the context our methods work. For example if our method works with arrays we can throw IndexOutOfRangeException or NullReferenceException because our method works at low level and directly operates with the memory and the array elements. But if our method is doing accumulating of interests at all accounts in a bank it should not throw IndexOutOfRangeException because this exception is not from the business area of the banking sector. It would be normal accumulation of interests in a bank software to throw InvalidInterestException exception with an appropriate error message where the original IndexOutOfRangeException exception to be attached.

Let’s give another example: we call a method that sorts an array of integers and throws an exception TransactionAbortedException. This is also an inappropriate exception just as NullReferenceException was in accumu-lation of interests in the bank software. That is why we should consider the abstraction level where our method works when we throw our exception.

### If Your Exception Has a Source, Use It!
When we catch an exception and throw a new one with a higher level of abstarction, we should always attach the original exception to it. This way the user of our code will be able to easily find the exact reason for the error and the location where it occurred at the first place. 
Each exception should carry detailed information about the problem. From the rule above many rules come out: we should have a relevant error message, the error type should match the problem and the exceptions should hold its source as inner exception.

### Give a detailed descriptive Error Message!
The error message that every exceptions holds is extremely important. In most cases it is enough to give us information of what the problem is. If the message is not good enough, users of your methods will not be able to quickly solve the problem.

Be careful not to show messages with incorrect content.

### Never Ignore the Exceptions You Catch
Never ignore the exceptions you catch without handling them

### Dump the Error Messages in Extreme cases Only

        **A method should either do the work it is created for or throw an exception. In case of wrong input, the method should throw an exception and should not return a wrong result!

A method is created to do a certain job. What the mthod is doing should be clear from its name. If we cannot give an appropriate name to the method, it means that it is doing too many things and we should split so everything is in a separate method. If the method cannot do the work it is created for it should throw an exception.

### Don't Catch All Exceptions

A very common mistake with exceptions is to catch all exceptions no matter what type they are.

### Only Catch Exceptions You Know How to Process

We should handle only errors that we expect and we are prepared for.We should leave the other exceptions so that they are caught by another method that knows how to handle them. A methos should not catch all exceptions- it should only catch the ones it can process correctly.