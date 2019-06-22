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
