# Interfaces

An interface in C# is a type definition similar to a class, except that is purely represents a contract between an object and its user. It can neither be directly instantiated as an object, nor can data members be defined. An interface contains definitions for a group of related functionalities that a non-abstract class or a struct must implement.

Interfaces can contain methods, properties, events, indexers or any combination of those four members types.An interface can't contain constants, fields, operators, instance constructors, finalizers, or types. Interface members are automatically public, and they can't include any access modifiers.

To implement an interface member, the corresponding member of the implementing class must be public, non-static and have the same name and signature as the interface member.

When a class or struct implements an interface, the class or struct must provide an implementation for all of the members that the interface defines. The interface itself provides no functionality that a class or struct can inherit in the way that it can inherit base class functionality. However, if a base class implements an interface, any class that's derived from the base class inherits that implementation.

Interfaces can inherit from other interfaces. A class might include an interface multiple times through base classes that it inherits or through interfaces that other interfaces inherit. However, the class can provide an implementation of an interface only one time and only if the class declares the interface as part of the definition of the class. If the interface is inherited because you inherited a base class that implements the interface, the base class provides the implementation of the interface. However, the derived class can reimplement any virtual interface members instead of using the inherited implementation.

A base class can also implement interface members by using virtual members. In that case, a derived class can change the interface behavior by overriding the virtual members.

## Interfaces Summary
- An interface is like an abstract base class with only abstract members. Any class or struct that implements the interface must implement all its members.
- An interface can't be instantiated directly. Its members are implemented by any class or struct that implements the interface.
- Interface can contain events, indexers, methods and properties
- Interfaces contain no implementation of methods.
- A class or struct can implement multiple interfaces. A class can inherit a base class and also implement one or more interfaces.

## Why use Interfaces
- Interface provide room for flexible code - resilience in the face of change, Insulation from implementation details
- Provides loose coupling and component-based programming
- Easier maintainability and makes the code base more scalable


Program to an interface rather than a concrete class
