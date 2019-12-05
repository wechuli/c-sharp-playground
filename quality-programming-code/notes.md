# Quality Programming Code

The quality of a program encompasses two aspects: the quality perceived by the user (called external quality), and the quality in regard to the internal organization(called internal quality).

The external quality is largely determined by the operational correctness of the particular program (absence of defects). Things like usability and intuitiveness of the user interface (UI) do greatly influence the external quality as well. Performance, a term which includes operational speed, memory usage and resource utilization, also plays in the equation, whenever these things matter.

Internal quality, on the other hand, is determined by how well the program is built. It depends on whether the employed design and architecture are suitable and sufficiently simple, and whether it is easy to make a change or add new functionality (maintainability). The comprehensibility of the implementation and the readability of the code are vital as well. In general, internal quality mostly has to do with the code of the program and its internal work.

## Characteristics of Quality Code

Quality code is easy to read and understand. It is maintained easily and straightforwardly. It must withstand any kind of input without breaking or behaving strangely, and be well tested. The design and the architecture must be suitable and not over-engineered. Documentation should be at a decent level, or at least the code should be self-documenting. Formatting should be adequately chosen and applied consistently throughout the whole project.

At all levels (modules, classes, methods) there should be a strong relation and a high focus of the responsibilities (strong cohesion) – that means, a piece of code should only do one particular thing.
Functional independence (or more precisely, loose coupling) between modules, classes and methods is crucially important. Suitable and consistent naming of all program identifiers is a must. Documentation should be embedded in the code itself.
Quality code is easy to reuse because it does just one thing (strong cohesion), but does it well, depending on a minimal amount of other components (loose coupling), using only their public interfaces. As an end result, quality code saves time and labor, and makes the produced software more valuable.
Some programmers consider quality code as being overly simple. They tend to think that it limits their opportunity to demonstrate their knowledge. That is the reason why they write code that is hard to read, and for using features of the language which are unpopular or poorly documented. They squeeze functions on a single line. This is an entirely wrong practice.

## Managing Complexity

The management of complexity plays a central role when writing software. The main objective is to reduce the complexity that each member has to deal with at a certain moment. This way, the brain of each of the members is burdened with less stuff to think about.

The complexity management starts from the architecture and the design. Each and every module (or rather, each autonomous code unit) should be designed with reducing complexity in mind.

Good practices should be applied at all levels - classes, methods, member variables, naming, operators, error handling, formatting, comments etc. They transform a lot of the decisions about the code in a strictly-defined set of rules, which enables a developer to think about one thing less while reading and writing code.

The complexity management can be approached in another way: it is especially helpful for a developer to be able to abstract himself away from the big picture while writing small piece of code. For that to be possible, the piece of code should have very clear boundaries, which are intact with the big picture.

The rules we are talking about later on are directed exactly towards eliminating complexity while working on a single piece of software.

### 1. Identifier Naming

Identifiers are the names of classes, interfaces, structures, enumerations, properties, methods, parameters and variables. Names should not be random. They should be composed in such a way that they carry meaningful information about their purpose and their role in the code. This makes the code easier to read. Do not give a name that contains digits - this is an indication for bad naming.

- Avoid abbreviations - abbreviations should be avoided because they can be confusing.
- Consistency in Naming - Naming should be consistent. Use the same words for the same situations, do not use synonyms. Name opposite things symmetrically.

A name should describe everything that the method does. If a suitable name cannot be found, it most probably means that the cohesion is weak, i.e. the method does many things and should be split up into separate methods.

Prefer names from the business domain in which the software operates, not from the technical names that come from the programming language: use CompanyNames rather than StringArray.

- Parameters, properties and variables can be of a Boolean type. In this point we describe the specifics of these identifiers.
  Their names should be a prerequisite for either truth or falsehood. For example, names like canRead, available, isOpen and valid are good. Examples of inadequate names for Boolean variables are: student, read, reader.

It would be useful if Boolean identifiers start with is, has or can (with an uppercase letter for properties), but only if this adds for clarity.

Names of constants should be written in Pascal Case or entirely in uppercase, with underscores between words (ALL_CAPS):

## Code Formatting

Formatting, along with naming one of the most basic prerequisites for readable code. Without proper formatting, the code is not going to be readable, whatever rules for naming and code structuring are chosen.

Formatting has two objectives: easier to read code, and, as a consequence – code that is easy to maintain.

### Rules for formatting of Types

- When classes, interfaces, structures and enumerations are created, a few recommendations should be followed for formatting the code inside.
- As we know, the class name is declared on the first line, preceded by the **class** keyword
- Constants follow next. They should be ordered according to the access modifier - **public** constants are first, then **protected** and the **private**
- Then follow the non-static fields. Like static fields, those labeled public are first, then protected and finally private fields follow:
- After non-static class fields, constructor declarations follow
- After the constructors, properties are declared
- Finally after the properties, the methods are declared. It is recommended that methods are grouped by functionality, not by access level or scope.

## High-Quality Classes

### Software Design

When a system is designed, separate **subtasks** are often divided into separate modules or subsystems. The task that each one solves must be clearly defined. The relationships between the modules should be decided in advance, not on the go.

Good software design has minimal complexity and is easy to understand. It is maintained easily and changes are incorporated straightforwardly. Every program element (method, class, module) is logically connected internally (string cohesion), functionally-independent and minimally tied to other modules (loose coupling). Well-designed is easily reused.

### Abstraction

A few basic rules:

- Public properties of a class should have the same level of abstraction
- The interface of a class should be simple and clear
- A class should describe only one thing
- A class should hide its internal implementation

Code is developed and changes and evolves over time. In spite of the evolution of classes, their interfaces should remain in-tact.

### Inheritance

Do not hide methods in derived classes.

- Move common methods, data and behavior as high as possible in the inheritance tree. This way, functionality is less likely to be duplicated and will be accessible to a wider audience.
- If you have a class with a single successor only, consider this suspicious. That level of abstraction is probably unnecessary. A suspicious method would be one that re-implements a base method, but does nothing more than the corresponding base method.
- Deep inheritance with more than 6 levels is hard for tracing, debugging and maintaining, and is not recommended. In a derived class, use member-variables through properties, rather than directly.

### Encapsulation

A good approach is to make all members **private**. Only those of them that should be visible from outside could be marked **protected** or eventually **public**.

- Implementation details should be hidden. The user of a high-quality class should not be aware of its inner-workings; he should only know what is does and how it is used.
- Member-variables (fields) should be hidden behind properties. Public member-variables are a manifestation of low-quality code. Constants are an exceptions in this regard.
- The public members of a class should be consistent with the abstraction represented by this class. Do not make assumptions about the usage scenario of a class.

### Constructors

It is preferred that all class members are initialized in the constructor. Usage of an uninitialized class is dangerous. A half-initialized class may be even more dangerous. Initialize member-variables in the same order as they are declared.

### Deep and Shallow Copy

When we assign values sometime we need to copy an object (make a duplicate). This can be done in two ways: deep copy or shallow copy.
Deep copies of an object are copies in which all member-variables are copied, and their member-variables also, and so on, until no other member-variables refer to objects. In a shallow copy, only the members at the first level are copied.

Shallow copies are dangerous because a change in one object leads to indirect changes in others.

## High Quality Methods
