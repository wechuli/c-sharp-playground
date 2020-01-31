# Interfaces

An interface contains definitions for a group of related functionalities that a non-abstract class or struct must implement. By using interfaces, you can for example include behavior from multiple sources in a class. That capability is important in C# because the language doesn't support multiple inheritance of classes. In addition, you must use an interface if you want to simulate inheritance for structs, because they can't actually inherit from another struct or class.

You define an interface by using the **interface** keyword as follows:

```C#
interface IEquatable<T>
{
    bool Equals(T obj);
}

```

Any class or struct that implements the `IEquatable<T>` interface must contain a definition for an **Equals** method that matches the signature that the interface specifies. As a result, you can count on a class that implements `IEquatable<T>` to contain an **Equals** method with which an instance of the class can determine whether it's equal to another instance of the same class.

An interface in C# is a type definition similar to a class, except that is purely represents a contract between an object and its user. It can neither be directly instantiated as an object, nor can data members be defined. An interface contains definitions for a group of related functionalities that a non-abstract class or a struct must implement.

Interfaces can contain methods, properties, events, indexers or any combination of those four members types.An interface can't contain constants, fields, operators, instance constructors, finalizers, or types. Interface members are automatically public, and they can't include any access modifiers.

To implement an interface member, the corresponding member of the implementing class must be public, non-static and have the same name and signature as the interface member.

When a class or struct implements an interface, the class or struct must provide an implementation for all of the members that the interface defines. The interface itself provides no functionality that a class or struct can inherit in the way that it can inherit base class functionality. However, if a base class implements an interface, any class that's derived from the base class inherits that implementation.

Interfaces can inherit from other interfaces. A class might include an interface multiple times through base classes that it inherits or through interfaces that other interfaces inherit. However, the class can provide an implementation of an interface only one time and only if the class declares the interface as part of the definition of the class (class ClassName : InterfaceName). If the interface is inherited because you inherited a base class that implements the interface, the base class provides the implementation of the interface. However, the derived class can reimplement any virtual interface members instead of using the inherited implementation.

A base class can also implement interface members by using virtual members. In that case, a derived class can change the interface behavior by overriding the virtual members.

## Explicit Interface Implementation

If a **class** implements two interfaces that contain a member with the same signature, then implementing that member on the class will cause both interfaces to use that member as their implementation.

If the two interface members do not perform the same function, however, this can lead to an incorrect implementation of one or both of the interface. It is possible to implement an interface member explicitly - creating a class member that is only called through the interface, and is specific to that interface. This is accomplished by naming the class member with the name of the interface and a period

```C#

  public class AnotherSampleClass : IControl, ISurface
    {
        void IControl.Paint()
        {

            Console.WriteLine("IControl.Paint");
        }
        void ISurface.Paint()
        {
            Console.WriteLine("ISurface.Paint");
        }

    }

```

The class member IControl.Paint is only available through the IControl interface, and ISurface.Paint is only available through ISurface. Both method implementations are separate, and neither is available directly on the class.

Explicit implementation is also used to resolve cases where two interfaces each declare different members of the same name such as property and a method:

```C#
interface ILeft
{
    int P{get;}
}

interface IRight
{
    int P();
}

```

To implement both interfaces, a class has to use explicit implementation either for the property P or the method P, or both, to avoid a compile error. e.g

```C#
class Middle : ILeft, IRight
{
    public int P() { return 0; }
    int ILeft.P { get { return 0; } }
}

```

Explicit interface implementation also allows the programmer to implement two interfaces that have the same member names and give each interface member a separate implementation.

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
