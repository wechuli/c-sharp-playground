# Object-Oriented Programming Principles

**Classes** are a description (model) of real objects and events referred to as entities. Classes posses characteristics referred to as properties.

Classes also expose behavior known as methods. Methods and properties can be visible only within the scope of the class, which declared them and their descendants (private/protected) or visible to other classes (public)
Objects are instances of classes.

Object-oriented programming is the successor of procedural (structural) programming. Procedural programming describes programs as groups of reusable code units (procedures) which define input and output parameters.Procedural programs consist of procedures, which invoke each other.

The problem with procedural programming is that code reusability is hard and limited - Only procedures and it is hard to make them generic flexible. There is no easy way to work with abstract data structures with different implementations.

The object-oriented approach relies on the paradigm that each and every program works with data that describes entities (objects or events) from real life.

This is how objects came to be. They describe characteristics (properties) and behavior(methods) of such real life entities.
The main advantages and goals of OOP are to make complex software faster to develop and easier to maintain. OOP enables the easy reuse of code by applying simple and widely accepted rules.

## Fundamental Principles of OOP

In order for a programming language to be object-oriented, it has to enable working with classes and objects as well as the implementation and use of the fundamental object-oriented principles and concepts: inheritance,abstraction, encapsulation and polymorphism.

### Encapsulation

Encapsulation refers to the bundling of data with the methods that operate on that data, or the restricting of direct access to some of an object's components. Encapsulation is used to hide the values or state if structured data object inside a class, preventing unauthorized parties direct access to them. Publicly accessible methods are generally provided in the class to access the values, and other client classes call these methods to retrieve and modify the values within the object.

### Inheritance

Inheritance is the mechanism of basing an object or class upon another object(prototype-bases inheritance) or class (class-based inheritance), retaining similar implementation.

### Abstraction

The process of hiding unnecessary details from the user that enables the user to implement more complex logic on top of the provided abstraction without understanding or even thinking about all the hidden complexity.

### Polymorphism

Polymorphism is the ability of an object to take on many forms.

### Inheritance

Inheritance is a fundamental principle of object-oriented programming. It allows a class to 'inherit' (behavior or characteristics) of another, more general class.

The class from which we inherit is referred to as parent class or base class/super class.

```C#

public class Lion : Felidae
{
private int weight;
// Keyword "base" will be explained in the next paragraph
public Lion(bool male, int weight) : base(male)
{
this.weight = weight;
}
public int Weight
{
get { return weight; }
set { this.weight = value; }
}

```

#### The "base" Keyword

In the above example, we used the keyword **base** in the constructor of the class **Lion**. The keyword indicates that the base class must be used and allows access to its methods, constructors and member variables. Using **base()**, we can all the constructor of the base class. Using **base.Method(...)**, we can invoke a method of the base class, pass parameters to it and use its results. Using base.field, we can get the value of a member variable from the base class or assign a different one to it.

In .NET, methods inherited from the base class and declared as virtual can be overridden. This means changing their implementation; the original source code from the base class is ignored and new code takes its place. We can invoke non-overridden methods from the base class without using the keyword **base**. Using the keyword is required only if we have an overridden method or variable with the same name in the inheriting class.

The keyword base can be used explicitly for clarity. **base.Method(...)** calls a method, which is necessarily from the base class. Such source code is easier to read, because we know where to look for the method in question.

#### Constructors with Inheritance

When inheriting a class, our constructors must call the base class constructor, so that it can initialize its member variables. If we do not do this explicitly, the compiler will place a call to the parameter less base class constructor "**:base()**"

If the base class has no default constructor (one without parameters) or that constructor is hidden, our constructors need to explicitly call one of the other base class constructors. The omission of such a call will result in a compile error.

If a class has private constructors only, then it cannot be inherited. If a class has private constructors only, then this could indicate many other things. For example, no-one (other than that class itself) can create instances of such a class. Actually, that's how one of the most popular design patterns (Singleton) is implemented.

Calling the constructor of a base class happens outside the body of the constructors. The idea is that the fields of the base class should be initialized before we start initializing fields of the inheriting class, because they might depend on a base class field.

### Access Modifiers of Class Members and Inheritance

There is public, private and internal. Additional, protected and protected internal

- **protected** - defines class members which are not visible to users of the class (those who initialize and use it), but are visible to all inheriting classes (descendants)
- **protected internal** - defines class members which are both internal i.e. visible within the entire assembly, and protected i.e. not visible outside the assembly, but visible to classes who inherit it (even outside the assembly)

When a base class is inherited:
- All of its **public**,**protected** and **protected internal** members (methods, properties) as visible to the inheriting class.
- All of its private methods, properties and member-variables are not visible to the inheriting class
- All of its internal members are visible to the inheriting class, only if the base class and the inheriting class are in the same assembly

### The System.Object Class

In .NET, every class, which does not inherit a class explicitly, inherits the system class System.Object by default. The compiler takes care of that. All objects can be perceived as instances of this class. It is convenient that this class contains important methods and their default implementation.

Every class, which inherits from another class indirectly, inherits **Object** from it. This way every class inherits explicitly or implicitly from Object and contains all of its fields and methods.

Because of this property, every class instance can be cast to Object.

The generic types (generics) have been provided specifically for working with collections and objects of different types. They allow creating typified classes.

### .NET Standard Libraries and Object

In .NET, there are a lot of predefined classes. These classes are part of the .NET framework; they are available wherever .NET is supported. These classes are refereed to as Common Type System (CTS).

.NET also provides a lot of libraries, which can be referenced additionally, and it stands to reason that they are called class libraries or external libraries.


