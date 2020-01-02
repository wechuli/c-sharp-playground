# Lambda Expressions and LINQ

- How to make queries to collections using lambda expressions and LINQ
- how to add functionality to already created classes using extension methods.
- anonymous types, describe their usage briefly
- discuss lambada expressions and show in practice how most of the built-in lambda functions work.
- LINQ syntax

## Extensions Methods

In practice, programmers often have to add new functionality to already existing code. If the code is available, we can simply add the required functionality and recompile. When a given assembly (.exe) or .dll file has already been compiled, the source code is not available , a common way to extend functionality of the types is through inheritance. This approach can be quite difficult to apply, due to the fact that we will have to change the instances of the base class with the instances of the derived one to be able to use our new functionality. Unfortunately, that is the least of our problems. If the type we want to inherit is marked with the keyword sealed, inheritance is not possible.

Extension methods solve that very same problem - they present to us the opportunity to add new functionality to already existing type (class or interface), without having to change its original code or use inheritance i.e. also works fine with types that cannot be inherited. Notice that through extension methods we can add "implemented methods" even to interfaces.

The extension methods are defined as **static** in ordinary static classes. The type of their first argument is the class (or the interface) they extend. In front of it, we should place the keyword **this**. That is what makes them different from other static methods, and indicates to the compiler that this is an extension method. The parameters with the keyword **this** in front of it can be used in the method to create its functionality. Practically, it is the object that is used by the extension method.

Extension methods can be applied directly to objects of the class/interface they extend. They can also be invoked statically through the static class they are defined in, but it is not a good practice.

To refer to a specific extension method, we should add “using” and the corresponding namespace, where the static class, describing this method, is defined. Otherwise the compiler has no way of knowing about their existence.

### Extension Methods for Interfaces

Extension methods can not only be used on classes, but on interfaces as well. The extension methods also give us the opportunity to work on generic types.

## Anonymous Types

In object-oriented languages (such as C#), it is common to define small classes that will be used only once. Typical example is the class **Point** that has only two fields - the coordinates of a point. Creating a simple class with the idea of using it just once is inconvenient and time consuming for the programmer, especially when the standard operations for each class: **ToString()**, **Equals()**, and **GetHashCode()** have to be predefined.

In C# there is a built-in way to create **single-use types**, called anonymous types. Objects of such type are created almost the same way as other objects in C#. The thing with them is that we don't need to define data type for the variable in advance. The **keyword var** indicates to the compiler that the type of the variable will be automatically detected by the expression, after the equals sign. We actually don't have a choice here, since we can't tell the specific type of the variable, because it is defined as one of an anonymous type. After that, we specify name for the object, followed by the "=" operator and the keyword **new**. In curly braces we enumerate the names and the values of the properties of the anonymous type.
e.g

```C#
var myCar = new { Color = "Red", Brand = "BMW", Speed = 180 };

```

During compilation, the compiler will create a class with a **unique name** and will generate properties for it (with getter and setter).In the example above, the compiler will guess by its own, that the properties Color and Brand are of type string and Speed will be set as int. Right after the initialization, the object of the anonymous type can be used as one of an ordinary type with its three properties:

As any other type in .NET, the anonymous ones inherit the class **System.Object**. During compilation, the compiler will automatically redefine the methods **ToString()**, **Equals()** and **GetHashCode()** for us.

### Arrays of Anonymous Types

The anonymous types, like ordinary ones, can be used as elements of arrays. We can initialize them with the keyword **new** followed by square brackets. The values of the elements of the array are listed the same way, as the values assigned to the anonymous type. The values in the array should be homogenous, i.e. it is not possible to have different anonymous types in the same array.

## Delegates

A delegate is a type that represents references to methods with a particular parameter list and return type. When you instantiate a delegate, you can associate its instance with any method with a compatible signature and return type. You can invoke (or call) the method through the delegate instance.

Delegates are used to pass methods as arguments to other methods. Event handlers are mothing more than methods that are invoked through delegates.

```C#
public delegate int PerformCalculation(int x, int y);

```

Any method from any accessible class or struct that matches the delegate type can be assigned to the delegate. The method can be either static or an instance method. This makes is possible to programmatically change method calls, and also plug new code into existing classes.

This ability to refer to a method as a parameter makes delegates ideal for defining callback methods.

### Delegates Overview

Delegates have the following properties:

- Delegates are similar to C++ function pointers, but delegates are fully object-oriented, and unlike C++ pointers to member functions, delegates encapsulate both an object instance and a method.
- Delegates allow methods to be passed as parameters
- Delegates can be used to define callback methods
- Delegates can be chained together
- Methods do not have to match the delegate type exactly
- C# version 2.0 introduced the concept of anonymous methods, which allow code blocks to be passed as parameters in place of a separately defined method. C# 3.0 introduced lambda expressions as a more concise way of writing inline code blocks. Both anonymous methods and lambda expressions (in certain contexts) are compiled to delegate types. Together, these features are now known as anonymous functions. For more information about lambda expressions, see Lambda expressions.


A delegate object is normally constructed by providing the name of the method the delegate will wrap

## Lambda Expressions

Lambda expressions are anonymous functions that contain expressions or sequence of operators. All lambda expressions use the lambda operator =>, which can be read as `goes to`. The left side of the lambda operator specifies the input parameters and the right side holds an expression or a code block that works with the entry parameters and conceivably returns some result.

Usually lambda expressions are used as predicates or instead of delegates (a type that references a method instance), which can be applied on collections, processing their elements and/or returning a certain result.
