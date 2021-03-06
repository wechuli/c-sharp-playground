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

A delegate object is normally constructed by providing the name of the method the delegate will wrap, or with an anonymous function. Once a delegate is instantiated, a method call made to the delegate will be passed by the delegate to that method. The parameters passed to the delegate by the caller are passed to the method, and the return value, if any, from the method is returned to the caller by the delegate. This is known as invoking the delegate.

Delegate types are derived from the Delegate class in the .NET Framework. Delegate types are sealed—they cannot be derived from— and it is not possible to derive custom classes from Delegate. Because the instantiated delegate is an object, it can be passed as a parameter, or assigned to a property. This allows a method to accept a delegate as a parameter, and call the delegate at some later time. This is known as an asynchronous callback, and is a common method of notifying a caller when a long process has completed. When a delegate is used in this fashion, the code using the delegate does not need any knowledge of the implementation of the method being used. The functionality is similar to the encapsulation interfaces provide.

Another common use of callbacks is defining a custom comparison method and passing that delegate to a sort method. It allows the caller's code to become part of the sort algorithm.

When a delegate is constructed to wrap an instance method, the delegate references both the instance and the method. A delegate has no knowledge of the instance type aside from the method it wraps, so a delegate can refer to any type of object as long as there is a method on that object that matches the delegate signature. When a delegate is constructed to wrap a static method, it only references the method.

A delegate can call more than one method when invoked. This is referred to as multicasting. To add an extra method to the delegate's list of methods - the invocation list - simply requires adding two delegates using the addition or addition assignment operators ('+' or '+=').

```C#
var obj = new MethodClass();
Del d1 = obj.Method1;
Del d2 = obj.Method2;
Del d3 = DelegateMethod;

//Both types of assignment are valid.
Del allMethodsDelegate = d1 + d2;
allMethodsDelegate += d3;

```

At this point allMethodsDelegate contains three methods in its invocation list—Method1, Method2, and DelegateMethod. The original three delegates, d1, d2, and d3, remain unchanged. When allMethodsDelegate is invoked, all three methods are called in order. If the delegate uses reference parameters, the reference is passed sequentially to each of the three methods in turn, and any changes by one method are visible to the next method. When any of the methods throws an exception that is not caught within the method, that exception is passed to the caller of the delegate and no subsequent methods in the invocation list are called. If the delegate has a return value and/or out parameters, it returns the return value and parameters of the last method invoked. To remove a method from the invocation list, use the subtraction or subtraction assignment operators (- or -=)

```C#
//remove Method1
allMethodsDelegate -= d1;

// copy AllMethodsDelegate while removing d2
Del oneMethodDelegate = allMethodsDelegate - d2;
```

Because delegate types are derived from System.Delegate, the methods and properties defined by that class can be called on the delegate. For example, to find the number of methods in a delegate's invocation list, you may write:

```C#
int invocationCount = d1.GetInvocationList().GetLength(0);

```

Delegates with more than one method in their invocation list derive from MulticastDelegate, which is a subclass of System.Delegate. The above code works in either case because both classes support GetInvocationList.

Multicast delegates are used extensively in event handling. Event source objects send event notifications to recipient objects that have registered to receive that event. To register for an event, the recipient creates a method designed to handle the event, then creates a delegate for that method and passes the delegate to the event source. The source calls the delegate when the event occurs. The delegate then calls the event handling method on the recipient, delivering the event data. The delegate type for a given event is defined by the event source. For more, see Events.

## Lambda Expressions

Lambda expressions are anonymous functions that contain expressions or sequence of operators. All lambda expressions use the lambda operator =>, which can be read as `goes to`. The left side of the lambda operator specifies the input parameters and the right side holds an expression or a code block that works with the entry parameters and conceivably returns some result.

Usually lambda expressions are used as predicates or instead of delegates (a type that references a method instance), which can be applied on collections, processing their elements and/or returning a certain result.

### Using Lambda Expressions with Anonymous Types

We can create collections of anonymous types from a collection with some elements by using lambda expressions.

### Statements in Lambda Expressions

Lambda functions can also have a body.

```C#

List<int> list = new List<int>() { 20, 1, 4, 8, 9, 44 };
// Process each argument with code statements
var evenNumbers = list.FindAll((i) =>
{
Console.WriteLine("Value of i is: {0}", i);
return (i % 2) == 0;
});

```

### Lambda Expressions as Delegates

Lambda functions can be written in delegates. Delegates are such a type of variable that contains a reference to methods.
Some standard delegate types in .NET are: `Action`, `Action<in T>`, `Action<in T1, in T2>`, and so on and `Func<out TResult>`, `Func<in T, out TResult>`, `Func<in T1, in T2, out TResult>` and so on. The types `Func` and `Action` are generic and contain the types of the return value, and the types of the parameters of the functions. The variables of such types are references to methods.

## Language Integrated Query (LINQ)

- https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/

LINQ is the name of a set of technologies based on the integration of query capabilities directly into the C# language.
You can write LINQ queries in C# for SQL Server databases, XML documents, ADO.NET Datasets, and any collection of objects that supports IEnumerable or the generic `IEnumerable<T>` interface. LINQ support is also provided by third parties for many Web services and other database implementations.

LINQ is a very powerful tool, similar to most SQL languages by logic and syntax

### Data Sources with LINQ

To define the data source (collection, array and so on), we have to use the keywords **from** and **in** and a variable for the collection (the iteration is similar to the one with the **foreach** operator).

### Data Filtering with LINQ

The Keyword **where** can be used to set conditions, that should be kept by each item of the collection, in order to continue with the execution of the query. The expression after **where** is always of a Boolean type. We can say that **where** works as a filter for the elements. After **where ... in**, we use only the name we gave for the iteration of the variables in the collection.

### Results of LINQ Queries

To choose the output data for the query, we can use the keyword **select**. The result is an object of an existing class or anonymous type. The result can also be a property of the objects, the query runs through or the objects themselves. The select statement and everything following it is placed always at the end of the query.

### Sorting Data with LINQ

Sorting with LINQ queries is done through the keyword **orderby**. The conditions, used for sorting the elements, are placed after it. For each condition, the order of arrangement can be indicated: ascending,descending as by default the elements are ordered in ascending order.

### Grouping Results with LINQ

To group the results by some criteria the keyword **group** should be used. The pattern is as follows:

        group [variable name] by [grouping condition] into [group name]

The result of grouping is a new collection of a special type that can be used further in the query. After the grouping, however, the query stops working with its initial variable. This means that in the **select** statement, we can only use the group.

### Joining Data with LINQ

The **join** statement is a bit more complicated that the other LINQ statements. It joins collections by certain matching criteria and extracts the needed data

Its syntax is as follows:

        from [variable name from collection 1] in [collection 1] join [variable name from collection 2] in [collection 2] on [part of the compare condition from collection 1] equals [part of the compare condition from collection 2]

### Nested LINQ Queries

LINQ also supports nested queries e.g.

```C#
var productsWithCategories =
from product in products
select new {
Name = product.Name,
Category =
(from category in categories
where category.ID == product.CategoryID
select category.Name).First()
};

```

Since each query in LINQ returns a collection of items (irrespective of whether the result from it is of 0, 1 or more elements), we need to use the extension method First() over the result of the nested query. The method First() returns the first element (in our case the only one) of the collection it is applied on. In this way we get the name of the category only by its ID number.

### LINQ Performance

As a rule using LINQ and extension methods is slower than using direct operations over a collection of elements, so beware of using LINQ when processing large collection or the performance is critical.

LINQ technology and extension methods work through the concept of expression trees. Each LINQ query is translated by the compiler to an expression tree and is executed when its results are actually accessed (not earlier).

Standard .NET Framework collection classes like `List<T>`, `HashSet<T>` and `Dictionary<K,V>` are optimized to work fast with LINQ. Most operations with LINQ work almost as fast as if we run them directly.
