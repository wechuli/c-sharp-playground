# Defining Classes

The aim of every program written by the programmer is to solve a given problem based on the implementation of a certain idea. In order to create a solution,first, we sketch a simplified actual model, which does not represent everything, but focuses on these facts, which are significant for the end result. Afterwards based on the sketched model, we are looking for an answer(i.e to create an algorithm) for our problem and the solution we describe via given programming language

Nowadays, the most used programming languages are the object-oriented. And because the object-oriented programming(OOP) is close to the way humans think, using one easily allows us to describe models of the surrounding life.Certain reason for this behavior is, because OOP offers tools to draw the set of concepts, which outline classes of objects in every model. The term – class and the definition of custom classes, different from the .NET system framework’s, is built-in feature of the C# programming language.

## Classes and Objects

**Class** in the OOP paradigm is called a definition(specification) of a given type of objects from the real-world. The class represents a pattern, which describes the different states and behavior of the certain objects(the copies), which are created from this class(pattern)
**Object** is a copy created from the definition(specification) of a given class also called an instance. When one object is created by the description of one class, we say the object is from type "name of the class"

## What does a Class Contain

Every class contains a definition of what kind of data types and objects has in order to be described. The object holds the actual data. The data defines the object's state.

In addition to the stae, in the class is described the behavior of the objects. The behavior is represented by actions, which can be performed by the objects themselves.The resource in OOP, through which we can describe this behavior of the objects from a given class, is the declaration of methods in the class body.

## Elements of the Class

The main elements of a C# class are the following:

- **Class declaration** - this is the line where we declare the name of the class

```C#
public class Dog
```

- **Class body** - similar to the method idioms in the language, the classes also have single class body. It is defined right after the class declaration, enclosed in curly brackets "{" and "}". The content inside the brackets is known as body of the class. The elements of the class, which are numbered below, are part of the body.

```C#
public class Dog
{

}
```

- **Constructor** - it is used for creating new objects. Here is a typical constructor

```C#
public Dog()
{
    // ..Some code ..
}
```

- **Fields** - they are variables, declared inside the class(somewhere in the literature are known as member-variables). The data of the object, which these variables represent, and are retained into them is the specific state of an object, and one is required for the proper work of object’s methods. The values, which are in the fields, reflect the specific state of the given object, but despite of this there are other types of fields, called static, which are shared among all the objects.

```C#
//Field definition
private string name;
```

-**properties** - this is the way to describe the characterisics of a given class.Usually, the value of the characteristics is kept in the fields of the object. Similar to the fields, the properties may be held by certain object or to be shared among the rest of the objects.

```C#
//Property definition
private string Name{get;set}
```

- **Methods** - We know that methods are names blocks of programming code. They perform particular actions and through them the objects achieve their behavior based on the class type. Methods execute the implemented programming logic(algorithms) and handling of data.

## Nature of Objects

When we create an object in .NET, one consists from two parts - the significant part(data), which contains its data and it is located in the memory of the operating system called dynamic memory(heap) and a reference part to this object, which resides in the other part of the operating system's memory, where the local variables an parameters of the methods are stored(the program execution stack).

For example, let's have a class called `Dog`, which has the properties for name,kind,and age. Lets create a variable from this class. This variable is a reference to the object and is in the dynamic memory(heap).

The `reference` is a variable which can access objects. When we declare one variable from type a particular class, and we do not want the variable to be associated with a specific object, then we assign to it the value null. The reserved word `null` in the C# language means that the variable does not point to any object(there is a missing value)

## Organizing Classes in Files and Namespaces
