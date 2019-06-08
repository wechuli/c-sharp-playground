# Methods

Whenever we write software programs, we aim to solve a particular task. We usually separate the task into smaller tasks, then develop solutions for them and put them together into one program. Those smaller tasks we call subroutines aka methods.

## Why Use Methods

- Better structured program and more readable code
- Avoid duplicated code
- code reuse. Repeating code may become very noxious and hazardous because it impedes the maintenance of the program and leads to errors.

**Declaring a method** we call method registration inthe program, so it can be successfully identified in the rest of the program
**Implementation(creation)** of a method is the process of typing the code that resolves a particular task. This code is in the method itself and represents its logic
**Method call** - is the process that invokes the already declared method, from a part of the code.

## Declaring Methods

- In C#, a method can only be declared inside a class but not inside the declaration of another method
- To declare a method means to register the method in our program
- [static] <return_type> <method_name> ([<param_list>])
- There are some mandatory elements to declare a method
  - Type of the result returned by the methos
  - Method's name
  - List of parameters to the method. It can be an empty list or it can consist of a sequence of parameters declarations
  - Optionally, the declarations can have access modifiers(as public and static)
- C# as a language used for object oriented programming also distinguished the methjods using their specification(signature) - method's name<method name> and the list of paramaters <param_list>

## Naming Methods
- The name of a method must start with a capital letter
- The PascalCase rule must be applied
- It is recommended that the method name must consist of verb, or verb and noun
## Modifiers
A modifier is a keyword in C#, which gives additional information to the compiler for a certain code.e.g public static

### Access Modifiers
- **public** - used to show that that method can be called by any C# class, no matter where it is.
- **private** - This method cannot be called anywhere except from the class in which it is declared
If a method is declared without an access modifier, it is accessible from all classes in the current assembly

A static method modifier means that there is no need to have an instance of a class in which the static method is declared.

## Local Variables
Whenever we declare a variable inside the body of amethod, we call that variable local varibale for the method.The varible is only visible inside the function - its scope.

## Invoking a Method

Invoking or calling a method is actually the process of execution of the method's code, placed into its body.

When a method executes it takes control of the program. The called method will return back the control to the caller right after its execution finished. The execution o fthe caller will conitnue from that line, where it was beore calling the other method.

A method can be invoked from 
    - From the main program method - Main()
    - From some other method
    - Amthod can be invoked from its own body. Such a call is referref to as recursion

In C#, the order of the methods in the class is not important. We are allowed to invoke(call) a method before it is declared in code

## Parameters in Methods
Often to solve certain problems, the method may need additional information, which depends on the environment in what the method executes. To pass information necessary for our method , we use the parameters list. The parameter list is a list with zero or more declaration of variables, separated by a comma, so that they will be used for the implementation of the method's logic

When a method has parameters, its behaviou depends upon parameters values

Methods can have multiple parameters. When a method with mutliple paramaters is declared, we must note that even if the parameters are of the same type, usage of short way of variable declaration is not allowed. Type of the parameters has to be explicityl written defore each parameter

When we declare a method, any of the elements from the parameters list we will call parameters. When we call a method, the values we use to assign to its parameters are called arguments

### Arguments of Primitive Types
When a variable is passed as a method argument, its value is copied to the parameter from the declaration of the method. After that, the copy will be used in the method body. If the declared parameter is of a primitive type, the usage of the arguments does not change the argument itself