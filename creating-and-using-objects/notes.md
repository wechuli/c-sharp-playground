# Objects

Object-oriented programming (OOP) is a programming paradigm, which uses objects and their interactions for building computer programs. In OOP, encapsulation, abstraction, polymorphism and inheritence is important to understand.

Software objects model real world objects or abstract concepts.In objects from the real world(as well as in the abstract objects) we can distinguish the following two groups:
- States - these are the characteristics of the object which define it in a way and describe it in general or in a specific moment.
- Behavior - these are the specific distinctive actions which can be done by the object.

Objects in OOP combine data and the means for their processing in one. They correspond to objects in real worlf and contain data and actions:
- Data members - embedded in objects variables, which describe their states
- Methods - 

## Class
The class defines abstract charcteristics of objects. It provides a structure for objects or a pattern which we use to describe the nature of something(some object). Classes provide modularity in object-oriented programs. The class defines the characteristics of an object(attributes) and its behavior(actions that can be performed by the object). The attributes of the class are defined as its own variables in its body(called member variables). The behaviour of objects is modeled by the definition of methods in classes.

## Onjects - Instances of Classes
Each object is an instance of just one class and is created according to a pattern of this class. Creating the object of a defined class is called instantiation.

Classes in C# can contain the following elements:

- **Fields** - member-variables from a certain type. fields are actually variables in your object that stores a particular piece of information.
- **Properties** - these are a special type of elements, which extend the functionality of the fields by giving the ability of extra data management when extracting and recording it in the class fields. Properties offer another level of abstraction to expose the fields.
- **Methods** - they implement the manipulation of the data

## System Classes
We call system classes the classes defined in standard libraries for building applications with C#. They can be used in all our .NET applications. The standard class library provides thousands of system classes for accomplishing the most common tasks in programming like console-based input/output , text processing, collection classes, parallel execution, networking, database access, data processing as well as creating Web-based, GUI and mobile applications.

It is important to know that the implementation of the logic in classes is encapsulated(hidden) inside them. for the programmer it is important what they do, not how they do it. With system classes, the implementation is often not available at all to the programmer. Thus, new layers of abstraction are created which is one of the basic principles in OOP.

## Creating and Releasing Objects
The creation of objects from preliminary defined classes during program execution is performed by the operator new. The newly created object is usually assigned to the variable from type coinciding with the class of the object. We are going to note that in this assignement, the object is not copied, and only a reference to the newly created object is recorded in the variable(its address in the memory)

### Creating Objects with Set Parameters
When creating an object with the operator new, two things happen: memory is set aside for this object and its data members are initialized. The initialization is performed by a special method called constructor


### Releasing the Objects
An important feature of working with objects in C# is that usually, there is no need to manually destroy them and release the memory taken up by them. This is possible because of the embedded .NET CLR system for cleaning the memory(garbage collector) which takes care of releasing unused objects instead of us. Objects to which there is no reference in the program at a certain moment are automatically released and the memory they take up is released. This way, many potential bugs and problems are prevented. If we would like to manually release a certain object, we have to detsroy the reference to it. This does not destroy the object immediately, but puts it is a state in which it is inaccessible to the program and the next time the garbage collector cleans the memory, it id goinf to be released.

### Access to Fields of an Object
The access to the fields and properties of a given object is done by the operator .(dot) placed between the names of the object and the name of the field(or the property). The operator . is not necessary in case we access field or property of given class in the body of a method of the same class.
We can access the fields and the properties either to extract data from them, or to assign new data. In the case of a property, the access is implemented in exactly the same way as in the case of a field - C# gives us this ability. This is achieved by the keywords get and set in the definition of the property, which perform respectively extraction of the value of the property and assignment of a new value.

### Calling Methods of Objects
Calling the mthods of a given object is done through the invocation operator() and with the help of the operator .(dot). The operator dot is not obligatory only in case the method is called in the body of another method of the same class. calling a method is performed by its name followed by () or (<parameters>) for the case when we pass it some arguments.

Methods of classes have access modifiers public, private or protected with which the ability to call them could be retricted.The access modifier public does not introduce any restrictions for calling the method i.e makes it publicly available;