# C# Language Guides

Several C# features aid in the construction of robust and durable applications: Garbage collection automatically reclaims memory occupied by unused objects; exception handling provides a structured and extensible approach to error detection and recovery; and the type-safe design of the language makes it impossible to read from uninitialized variables, to index arrays beyond their bounds, or to perform unchecked type casts.

C# has a unified type system. All C# types, including primitive types such as `int` and `double`, inherit from a single root object type. Thus, all types share a set of common operations, and values of any type can be stored, transported, and operated upon in a consistent manner. Furthermore, C# supports both user-defined reference types and value types, allowing dynamic allocation of objects as well as in-line storage of lightweight structures.

To ensure that C# programs and libraries can evolve over time in a compatible manner, much emphasis has been placed on versioning in C#'s design. Many programming languages pay little attention to this issue, and, as a result, programs written in those languages break more often than necessary when newer versions of dependent libraries are introduced. Aspects of C#'s design that were directly influenced by versioning considerations include the separate virtual and override modifiers, the rules for method overload resolution, and support for explicit interface member declarations.

## Structure of a C# Program

C# programs can consist of one or more files. Each file can contain zero or more namespaces. A namespace can contain types such as classes, structs, interfaces, enumerations, and delegates, in addition to other namespaces. The key organizational concepts in C# are programs, namespaces, types, members and assemblies. C# programs consist of one or more source files. Programs declare types, which contain members and can be organized into namespaces. When C# programs are compiled, they are physically packaged into assemblies. Assemblies typically have the file extension `.exe` or `.dll`, depending on whether they implement applications or libraries.

## Types and Variables

There are two kinds of types in C#: **value types** and **reference types**. Variables of value types directly contain their data whereas variables of reference types store references to their data, the latter being known as objects. With reference types, it is possible for two variables to reference the same object and thus possible for operations on one variable to affect the object referenced by the other variable. With value types, the variables each have their own copy of the data, and it is not possible for operations on one to affect the other (except in the case of ref and out parameter variables).

C#'s value types are further divided into _simple types_, _enum types_, _struct types_, and _nullable types_, and C#'s reference types are further divided into _class types_, _interface types_, _array types_, and _delegate types_.
