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
