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

### The Base Type Object Upcasting and Downcasting

```C#
public class ObjectExample
{
    static void Main()
    {
        AfricanLion africanLion = new AfricanLion(true,80);
        //Impilicit casting
        object obj = africanLion;
    }
}

```

In this example, we cast an **AfricanLion** to **Object**. This operation is called upcasting and is permitted because **AfricanLion** is an indirect child of **Object** class.

```C#

AfricanLion africanLion = new AfricanLion(true,80);
//Implicit casting
object obj = africanLion;

try{
    //Explicit casting
    AfricanLion castedLion = (AfricanLion)obj;
}
catch(InvalidCastException ice)
{
    Console.WriteLine("obj cannot be downcasted to AfricanLion");
}

```

In this example, we cast an Object to AfricanLion. This operation is called downcasting and is permitted only if we indicate the type we want to cast to, because Object is a parent class of AfricanLion and it is not clear if the variable obj is of type AfricanLion. If it is nor, an InvalidCastException will be thrown.

##### The Object.ToString() method

One of the most commonly used methods, originating from the class **Object** is **ToString()**. It returns a textual representation of an object.

Notice that ToString() is invoked implicitly. When we pass an object to the WriteLine() method, that object provides its string representation using ToString() and only then it is printed to the output stream. That way, there’s no need to explicitly get string representations of objects when printing them.

#### Virtual Methods: the "override" and "new" Keywords

We need to explicitly instruct the compiler that we want our method to **override** another. In order to do this, we use the **override keyword**.

When we use the keyword **new**, we create a new method, which hides the old one. The old method can then only be called with an upcast.

It turns out that when we override a method, we cannot access the old implementation even if we use upcasting. This is becasue there are no longer two **ToString()** methods, but rather only the one we overrode.

A method, which can be overridden is called **virtual**. In .NET, methods are not virtual by default. If we want a method to be overridable, we can do so by including the keyword **virtual** in the declaration of the method.

The explicit instructions to the compiler that we want to override a method (by using override) is a protection against ,mistakes. If there's a typo in the method's name or the types of its parameters, the compiler will inform us immediately of this mistake. It will know something is not right when it cannot find a method with the same signature in any of the base classes.

#### Transitive Properties of Inheritance

In mathematics, transitivity indicates transferability of relationships. Let's take the indicator "larger than" (>) as an example. If A>B and B>C, we can conclude that A > C. This means that the relation "larger than" (>) is transitive, because we can unequivocally determine whether A is larger or smaller than C and vice versa.

If the class **Lion** inherits the class **Felidae** and the class **AfricanLion** inherits **Lion**, then this implies that **AfricanLion** inherits **Felidae**. Therefore **AfricanLion** has the property **Male** which is defined in **Felidae**. This useful property allows a particular functionality to be defined in the most appropriate class.

It is because of the transitive property of inheritance that we can be sure that all classes include the method **ToString()** and all other methods of **Object** regardless of which class they inherit.

#### Inheritance Hierarchy

If we try to describe all big cats, then, sooner or later, we will end up with a relatively large group of classes which inherit one another. All these classes, combined with the base classes, form a hierarchy of big cat classes. The easiest wat to describe such hierarchies is by using class diagrams.

#### Class Diagrams

A class Diagram is one of several types of diagrams defined in UML. UML (Unified Modeling Language) is a notation for visualizing different processes and objects to software development.

It is commonly accepted to draw class diagrams as rectangles with name attributes (member variables) and operations (methods). The connections between them are denoted with various types of arrows.
Pieces of terminology

- Generalization - is a term signifying the inheritance of a class or the implementation of an interface
- The other term is association. An association, would be, e.g "The Lion has paws", where Paw is another class. Association is has-a relationship.

This is what a sample class diagram looks like:
![](assets/class.PNG)

The class is represented as a **rectangle**, divided in 3 boxes one under another. The name of the class is at the top. Next, there are the attributes (UML term) of the class (in .NET they are called member variables and properties). At the very bottom are the operations (UML term) or methods (in .NET jargon). The plus/minus signs indicate whether an attribute /operation is visible (+ means public) or not visible (- means private). Protected members are marked with #.

Associations denote connections between classes. They model mutual relations. They define multiplicity.

#### Aggregation

Aggregation is a special type of association. It models the relationship of kind "whole/part". We refer to the parent class as an aggregate. The aggregated classes are called components.

Composition is an aggregation where the components cannot exist without the aggregate.

### Abstraction

Abstraction means working with something we know how to use without knowing how it works internally. Abstraction is an important concept in OOP. It allows us to write code, which works with abstract data structures (like dictionaries, lists, arrays and others). We can work with an abstract data type by using its interface without concerning ourselves with its implementation.

Abstraction allows us to do something very important - define an interface for our applications i.e. to define all tasks the program is capable of executing and their respective input and output data. That way, we can make a couple of small programs, each handling a smaller task. When we combine this with the ability to work with abstract data, we achieve great flexibility in integrating these small programs and much more opportunities for code reuse.

#### Interfaces

In the C# languages, the interface is a definition of a role (a group of abstract actions). It defines what sort of behavior a certain object must exhibit without specifying how this behavior should be implemented. Interfaces are also know as contract or specifications.

An object can have multiple roles (or implement multiple interfaces/contracts) and its users can utilize it from different points of view.

An interface can only declare methods and constants. A method signature is the combination of a method's name and a description of its parameters(type and order). A declaration is the combination of a method's return type and its signature. The return type only specifies what the method returns.

A class / method implementation is the source code of a class/method.

In an interface, methods are only declared; the implementation is coded in the class implementing the interface. The class that implements a certain interface must implement all methods in it. The only exception is when the class is abstract. Then it can implement none, some or all of the methods. All remaining methods have to be implemented in some of the inheriting classes.

#### Abstraction and Interfaces

The best way to achieve abstraction is by working through interfaces. A component works with interfaces which another implements. That way, a change in the second component will not affect the first one as long as the new component implements the old interface. The interface is also called a contract. Every component upholds a certain contract (the signature of certain methods). That way, two components upholding a contract can communicate with each other without knowing how their counterpart works.

Some important interfaces from the Common Type System (CTS) are the list and collection interfaces: `System.Collections.Generic.IList<T>` and `System.Collections.Generic.ICollection<T>`. All of the standard .NET collection classes implement these interfaces and the various components pass different implementations (arrays, linked lists, hash tables, etc.) to one another using a common interface.
Collections are an excellent example of an object-oriented library with classes and interfaces that actively use all core principles of OOP: abstraction, inheritance, encapsulation and polymorphism.

##### When Should We Use Abstraction and Interfaces

The answer to this question is: always when we want to achieve abstraction of data or actions, whose implementation can change later on. Code, which communicates with a other piece of code through interfaces is much more resilient to changes than code written using specific classes. Working through interfaces is common and a highly recommended practice.

It is always a good idea to use interfaces when functionality is exposed to another component. In the interface, we include only the functionality (in the form of a declaration) that others need to see.

Internally, a program/ component can use interfaces for defining roles. That way, an object can be used by different classes through different roles.

### Encapsulation

In object oriented programming languages, encapsulation refers to one of two related but distinct notions, and sometimes to the combination thereof:

- A language mechanism for restricting direct access to some of the object's components
- A language construct that facilitates the bundling of data with the methods(or other functions) operating on that data

The person writing the class has to decide what should be hidden and what not. When we program, we must define as **private** every method or field which other classes should not be able to access.

### Polymorphism

Polymorphism is the provision of a single interface to entities of different types. Polymorphism allows treating objects of a derived class as objects of its base class.

Polymorphism can bear strong resemblance to abstraction, but it is mostly related to overriding methods in derived classes, in order to change their original behavior inherited from the base class. Abstraction is associated with creating an interface of a component or functionality (defining a role).

#### Abstract Classes

The abstract modifier indicates that the thing being modified has a missing or incomplete implementation. The abstract modifier can be used with classes, methods, properties, indexers, and events. Use the abstract modifier in a class declaration to indicate that a class is intended only to be a base class of other classes, not instantiated on its own. Members marked as abstract must be implemented by non-abstract classes that derive from the abstract class.

Abstract classes have the following features:

- An abstract class cannot be instantiated
- An abstract class may contain abstract methods and accessors.
- It is not possible to modify an abstract class with the sealed modifier because because the two modifiers have opposite meanings. The `sealed` modifier prevents a class from being inherited and the `abtract` modifier requires a class to be inherited.
- A non-abstract class derived from an abstract class must include actual implementations of all inherited abstract methods and accessors.

Use the `abstract` modifier in a method or property declaration to indicate that the method or property does not contain implementation

Abstract methods have the following features:

- An abstract method is implicitly a virtual method
- Abstract method declarations are only permitted in abstract classes
- Because an abstract method declaration provides no actual implementation, there is not method body; the method declaration simply ends with a semicolon and there are no curly braces following the signature.
- It is an error to use the `static` or `virtual` modifiers in an abstract method declaration.
  Each class with at least one abstract method must be abstract. It is possible to define a class as an abstarct one, even when there are no abstract methods in it.

Abstract classes are something in the middle between classes and interfaces. They can define ordinary methods and abstract methods. Ordinary methods have an implementation, whereas abstract methods are empty (without an implementation) and remain to be implemented later by the derived classes.

A pure abstract class is an abstract class, which has no implemented methods and no member variables. It is very similar to an interface. The fundamental difference is that a class can implement many interfaces and inherit only one class (even if that class is abstract).

Initially, interfaces were not necessary in the presence of "multiple inheritance". They had to be conceived as a means to supersede it in specifying the numerous roles of an object.

#### Virtual Methods

A method which can be overridden in a derived class , is called a **virtual method**. Methods in .NET aren't virtual by default. If we want to make a virtual method, we mark it with the keyword **virtual**. Then the derived class can declare and define a method with the same signature. Virtual methods are important for **method overriding**, which lies at the hear of polymorphism.

Virtual methods as well as abstract methods can be overriden. Abstract methods are actually virtual methods without a specific implementation. All methods defined in an interface are abstract and therefore virtual, although this is not explicitly defined.

#### The Difference between Virtual and Non-Virtual Methods

**Virtual methods** are used when we expect the derived classes to change / complement / alter some of the inherited functionality. Then, even if we work with an object not directly, but rather by upcasting it to **Object**, we use the overwritten implementation of the virtual methods.

**Sealing of methods** is done when we rely on a piece of functionality and we don't want it to be altered. Methods are sealed by default. But if we want a base class' virtual method to become sealed in a derived class, we use **override sealed**.

#### When Should We Use Polymorphism

- Whenever we want to enable changing a method's implementation in a derived class.

It's a goof rule to work with the most basic class possible or directly with an interface. That way, changes in used classes reflect to a much lesser extent in classes written by us. The less a program know about its surrounding classes, the fewer changes (if any) it would have to undergo.

### Cohesion and Coupling

#### Cohesion

The concept of cohesion shows to what degree a program's or a component's various tasks and responsibilities are related to one another i.e. how much a program is focused on solving a single problem. Cohesion is divided into strong cohesion and weak cohesion.

##### Strong Cohesion

Strong cohesion indicates that the responsibilities and tasks of a piece of code (a method, class, component or a program) are related to one another and intended to solve a common problem. This is something we must always aim for. Strong cohesion is a typical characteristic of high-quality software.

Strong cohesion in a class indicates that the class defines only one entity. Each of these roles is defined in the same class. Strong cohesion indicates that the class solves only one task, one problem and not many at the same time. A class, which does many things at the same time, is difficult to understand and maintain.

A method is well written when it performs only one task and performs it well. A method, which does a lot of work related to different things , has bad cohesion. It has to be broken down into simpler methods, each solving only one task.

##### Weak Cohesion

Weak cohesion is observed along with methods, which perform several unrelated tasks.Such methods take several different groups of parameters in order to perform different tasks. Sometimes, this requires logically unrelated data to be unified for the sake of such methods. Weak cohesion is harmful and must be avoided.

#### Best Practices with Cohesion

Strong cohesion is quite logically the "good" way of writing code. The concept is associated with simpler and clearer source code - code that is easier to maintain and reuse.

Contrarily, with weak cohesion each change is a ticking time bomb, because it could affect other functionality. Sometimes a logical task is spread out to several different modules and thus changing it is more labor intensive. Code reuse is also difficult, because a component does several unrelated tasks and to reuse it the exact same conditions must be met which is hard to achieve.

#### Coupling

Coupling mostly describes the extent to which components / classes depend on one another. It is broken down into loose coupling and tight coupling. Loose coupling usually correlates with strong cohesion and vice versa.

##### Loose Coupling

Loose coupling is defined by a piece of code's (program/class/component) communication with other code through clearly defined interfaces (contracts). A change in the implementation of a loosely coupled component doesn't reflect on the others it communicates with. When you write source code, you must not rely on inner characteristics of components (specific behavior that is not described by interfaces).

The contract has to be maximally simplified and define only the required behavior for this component's work by hiding all unnecessary details.

##### Tight Coupling

We achieve tight coupling when there are many input parameters and output parameters; when we use undocumented(in the contract) characteristics of another component (for example, a dependency on static fields in another class); and when we use many of the so called control parameters that indicate behavior with actual data. Tight coupling between two or more methods, classes or components means they cannot work independently of one another and that a change in one of them will also affect the rest. This leads to difficult to read code and big problems with maintenance.

##### Best Practices with Coupling

The most common and advisable way of invoking a well written module's functionality is through interfaces. That way, the functionality can be substituted without clients f the code requiring changes. The jargon expression for this is "programming against interfaces"

Most commonly, an interface describes a "contract" observed by this module. It is good practice not to rely on anything else other than what's described by this contract. The use of inner classes, which are not part of the public interface of a module , is not recommended because their implementation can be substituted without substituting the contract.

It is good practice that the methods are made flexible and ready to work with all components, which observe their interfaces, and not only work with definitive ones. The latter would mean that these methods expect something specific from the components they can work with. It is also good practice that all dependencies are clearly described and visible. Otherwise, the maintenance of such code becomes difficult.

#### Spaghetti Code

Spaghetti code is unstructured code with unclear logic; it is difficult to read, understand and maintain; it violates and mixes up consistency; it has weak cohesion and tight coupling. Such code is associated with spaghetti, because it is just as tangled and twisted. When you pull out a strand of spaghetti (i.e. a class or method), the whole dish of spaghetti can turn out tangled in it (i.e. changes in one method or class lead to dozens of other changes because of the strong dependence between them). It is almost impossible to reuse spaghetti code, since there is no way to separate that part of the code, which is practically applicable.

Spaghetti code is achieved when you have written code, supplement it and have to readapt it again and again every time the requirements change. Time passes by until a moment comes when it has to be rewritten from scratch.

You classes must do only one thing, do it well, bind them minimally to other classes (or not link them at all whenever that's possible), have a clear interface and good abstraction and to hide the details of their internal workings.

### Object-Oriented Modeling (OOM)

Object-oriented modeling (OOM) is a process associated with OOP where all objects related to the problem we are solving are brought out (a model is created). Only the classes' characteristics which are important for solving this particular problem are elicited. The rest is ignored. That way, we create a new reality, a simplified version of the original one (its model) such that is allows us to solve the problem or task. In object-oriented modeling, the model is created by means of OOP: via classes, class attributes, class methods, objects, relations between classes

#### Steps in Object-Oriented Modeling

- Identification of classes
- Identification of class attributes
- Identification of operations on classes
- Identification of relations between classes.

##### Identification of Classes

The names of the classes are the nouns in the text, usually common nouns in singular like Student, Message, Lion. Avoid names that don’t come from the text, such as: StrangeClass, AddressTheStudentHas. Sometimes it's difficult to determine whether some subject or phenomena from the real world has to be a class.The better we explore the problem, the easier it will be to decide which entities must be represented as classes. When a class becomes large and complicated it has to be broken down into several smaller classes.

##### Identification of Class Attributes

Classes have attributes (characteristics), for example the class Student has a name, institution and a list of courses. Not all characteristics are important for a software system. For example, as far as the class Student is concerned eye color is a non-essential characteristic. Only essential characteristics have to be modeled.

##### Identification of Operations on Classes

Each class must have clearly defined responsibilities – what objects or processes from the real world it identifies and what tasks it performs. Each action in the program is performed by one or several methods in some class. The actions are modeled as operations (methods).

A combination of verb + noun is used for the name of a method, e.g. PrintReport(), ConnectToDatabase(). We cannot define all methods of a given class immediately. Firstly, we define the most important methods – those that implement the basic responsibilities of the class. Over time additional methods appear.

##### Identification of Relationships between classes

If a student is from a faculty and this is important for the task we are solving, then student and faculty are related, i.e. the Faculty class has a list of Students. These relations are called associations

### UML Notation

The UML (Unified Modeling Language) notation defines several additional types of diagrams.

#### Use Case Diagrams

They are used when we elicit the requirements for the description of possible actions. Actors represent roles (types of users).

Use cases describe interaction between the actors and the system. The use case model is a group of use cases - it provides a complete description of a system's functionality.

A use case describes a single functionality of the system, a single action can be performed by some actors. It has a unique name and is related to actors

#### Sequence Diagrams

Sequence diagrams are used when modeling the requirements of process specification and describing use case scenarios more extensively. They allow describing additional participants in the process and the sequence of the actions over time. They are used in designing the descriptions of system interfaces.

Sequence diagrams describe what happens over time, the interactions over time, the dynamic view of the system, a sequence of steps just like an algorithm.

### Design Patterns

Few years after the onset of the object-oriented paradigm, it was found that there are many situations, which occur frequently during software development, such as a class which must have only one instance within the entire application.

Design patterns appeared as proven and highly-efficient solutions to the most common problems of object-oriented modeling.

#### The Singleton Design Pattern

This is the most popular and most frequently used design pattern. It allows a class to have only one instance and defines where it has to be taken from.

#### The Factory Method Design Pattern

Factory method is another very common design pattern. It is intended for 'producing' objects. The instantiation of an object is not performed directly, but rather by the factory method. This allows the factory method to decide which specific instance to create from a family of classes implementing a common interface. the solution can depend on the environment, a parameter or some system setting.
