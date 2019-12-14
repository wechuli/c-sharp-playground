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

The quality of our methods is of significant importance to creating high-quality software and its maintenance. They contribute to more readable and more comprehensible programs. Methods do help us reduce the complexity of our software, in order to make it more flexible and easier to modify.

### Why Should We Use Methods?

A method solves a small problem. Many individual methods solve many small problems. Taken together, they solve a bigger problem. With methods, the overall complexity of a task is reduced: Complex problems are being split into simpler ones, additional layers of abstraction are added, implementation details are hidden and the risk of failure is lowered. Code duplication is avoided as well. Complex sequences of actions are hidden.

Since methods are the smallest reusable unit of code, their biggest advantage is the ability they give us to reuse code.

### What Should a Method Do?

A method should do the work described by its name, and nothing more.If a method does not do what its name suggests, then either its name is wrong, or it does many things at the same time, or the method simply is incorrectly implemented. In any of these three cases, the method does not meet the requirements for code quality and should be refactored accordingly.

A method should either do its expected job, or should inform for an error and terminate. In .NET, informing for errors is done by throwing an exception. In case of invalid input, it is unacceptable for a method to return a wrong result. Instead, the method should inform the caller that is cannot do its job because the necessary preconditions are not met (such as invalid parameters being supplied, or an unexpected internal object state)

Returning a neutral value (such as null) instead of an error message is generally not recommended, except in cases where that value does not collide with an error condition, such as a `Find()` method returning `null` because nothing was found. Otherwise, the caller loses its ability to handle the error, and the cause of the error is lost because of the lack of a richly informative exception.

        A public method should either correctly accomplish exactly what its name suggests, or should inform the caller for an error by throwing an exception.
         Any other behavior is incorrect!

The above rule has some exceptions when private methods are concerned. Unlike public methods, which should either work correctly or throw an exception, a compromise can be made for private methods. Since only the author of the class is supposed to call them, he should be aware of the validity of the passed arguments. Therefore, error conditions need not be handled because they can be predicted and prevented in the first place.

### Strong Cohesion and Loose Coupling

The rules regarding the logical relatedness of the responsibilities (string cohesion) and the functional independence through a minimal amount of interaction with other methods and classes (loose coupling) are of a major importance when methods are concerned.

A method should solve only one problem, not many. A method should not solve numerous unrelated problems and should not have side effects.

- Methods should depend as little as possible on the rest of the methods in their class and on the methods/properties/fields in other classes. This concept is called loose coupling. In the best-case scenario, a method should depend only on its parameters and not use any other data as its input or output. Such methods can be easily pulled out and reused in another project, because they are unbound to the environment in which they execute.

Sometimes methods depend on private variables declared within their class, or they alter the state of the object they belong to. This is not wrong and is entirely OK. In such a case we are talking about coupling between the method and its class. Such coupling is not problematic because the class and its internal data and logic are encapsulated: the whole class can still be moved into another project and reused without any modifications.

Most of the classes from .NET Common Type System (CTS) and .NET Framework define methods that depend only on the data within their class and the passed arguments. In standard libraries, the methods dependencies from external classes are minimal and that is why they are easy to reuse. The .NET Framework class library strongly follows the idea of loose coupling.

Whenever a method reads or modifies global data and depends on 10 additional objects, which must be initialized within the instance of its own class, it is considered a coupled to its environment and to all of these objects. This means that it functions in an overly complex way and is affected by too many external conditions, therefore the probability for an error is high. Methods that depend on too many external conditions are hard to read, understand and maintain. Strong functional coupling is bad and should be avoided as much as possible, because it often leads to spaghetti code.

### How Long Should a Method Be ?

Shorter methods (not longer than a single screen) should be preferred. Such methods are visible on the screen without scrolling and this simplifies their reading and understanding and the probability for making mistakes.

The longer a method, the more complex it becomes. Consequent modifications become considerably harder and more time-consuming than with shorter methods. These factors lead towards errors and harder maintenance.

### Method Parameters

- One of the basic rules for ordering method parameters is that the primary one(s) should precede the rest. Another rule is to have meaningful parameter names. A common mistake is to tie the parameter names to their type.
- Parameters should not ne used as local variables, that is, they should not be modified. Modifying method parameters makes the code harder to read and the logic becomes more convoluted. You can always declare a new variable instead of modifying a parameter.
- Implicit assumptions should be documented. An example would be to specify the measurement unit of a parameter to a method that computes the cosine of an angle - whether the angle is in radians or degrees, in case the name does not make it obvious.
- The parameter count should not exceed 7. Seven is a special, magic number. It is proven in the psychology that the human mind cannot trace more than 7 (+/- 2) things simultaneously. As with parameter count, this recommendation is only advisory. Sometimes you need to pass more parameters. If that is the case, think about passing them as an object that represents a class with many fields. For example, instead of having an AddStudent(…) method with 15 parameters (name, address, contacts, etc.), you can reduce them by grouping logically related parameters into separate objects: AddStudent(personalData, contacts, universityDetails). This way, each of the three parameters will contain a few fields inside, and the same information will be passed to the method, but in an easier to understand form.
- Sometimes it is more appropriate, from a logical standpoint, to pass only one or a few of the fields of an object, rather than the whole object. This mostly depends on whether the method should be aware of the existence of this object or not. Suppose we have a method that calculates the final grade of a given student – CalcFinalGrade(Student s). Because the final grade depends only on the previous grades and the rest of the student’s data does not matter, it would be better if only the list of grades is passed – CalcFinalGrade(IList<Grade>), instead of a Student object.

## Proper Use of Variables

### Returning a Result

Whenever a result is returned, it should first be saved in a variable, before being returned. There are a few reasons for saving the result before returning it.

- For one, the additional variable contributes to self-documenting the code and makes it clear what is returned.
- Another reason is tracing the returned value when debugging - we can stop the program from execution as soon as the value is computed and then inspect it.
- It also helps to avoid long expressions, which can become quite convoluted.

### Principles for Initialization

In .NET, all member-variables (fields) belonging to a class are initialized automatically at the time of being declared. This is managed by the runtime and provides for a safer environment, less prone to errors caused from incorrectly initialized memory.All reference type variables are initialized to null and all primitive types to 0 (false for bool).

The compiler forces the explicit initialization of all local variables; otherwise a compile-time error is given. A good practice is to initialize all variables explicitly at the time of their declaration.

A local variable should be declared at the beginning of its enclosing block or method.

### Scope, Lifetime and Span of

In .NET, three layers of variable scope exist: **static** variables, member-variables of a class (**fields**), and **local variables** inside a method.

The wider the scope of a variable, the higher the probability that more code will be tied to it, thereby increasing the level of coupling. Since strong coupling is not desirable, variable scope should be as narrow as possible.

A good approach in using variables is to initially declare them with the minimal scope and extend it only when necessary. This is a natural way of assigning a variable the scope it needs.

#### Minimizing the Variable Span

The span of a variable corresponds to the average amount of lines between its occurrences in the code. Considering minimal variable span, variables should be declared and initialized as close as possible to their first occurrence in the code, and not necessarily in the beginning of a method or a code block.

Keep the variable span as small as possible! This improves the code quality, readability, understandability and maintainability because less code needs to be inspected in order to read and understand the code.

#### Minimizing the Variable Lifetime

The lifetime of a local variable inside a method lasts between the place of its declaration (the beginning of a block, most usually), until the end of the enclosing block. Class fields (member-variables) exist as long as their class is instantiated. Static variables last throughout the entire execution of the program.

As you may guess, the lifetime should be kept minimal. This reduces the lines of code that you should consider at the same time when reading the code. This will maximized the portion of the code you can safely ignore when you read the code. This will reduce the total complexity in your brain, because it works better with smaller and simpler pieces of code, right?

It is important that the programmer tracks the usage of a particular variable, along with its scope, span and lifetime. The main objective is to reduce the scope, the lifetime and the span as much as possible. This leads to an important rule about correctly using variables:

        Declare local variables as late as possible, immediately before using them for the first time. Initialize them at the time of declaration.

Variables with a wider scope and a longer lifetime should have more descriptive names, such as totalStudentsCount instead of count. That is because they occur at more locations within a larger piece of code, and hence the context around them is not going to be entirely clear.

Variables that span across just 4-5 lines can have short and simple names, for example count. They do not need long names because their purpose becomes clear from their limited context (a few lines), and ambiguities can rarely arise there.

A very important rule is to use a variable for one purpose only. The excuse that memory is conserved the other way is not generally convincing. If a variable is used for multiple different purposes, what name can we give it?

        Use one variable for a single purpose only. Otherwise, an appropriate name cannot be found.

Unused local variables should not be present in the code. Their declarations alone are useless. Fortunately, most of the decent development environments do warn you about such anomalies.
The use of local variables with hidden meaning should be avoided.

## Proper Use of Expressions

When using expressions, the simple rule is: avoid complex expressions! A complex expression is one that performs more than one thing.

There are many reasons to avoid the use of complex expressions:

- Code becomes hard to read.
- Code is hard to maintain
- Code is hard to fix in case of defects.
- Code is hard to debug

Instead of a single complex expression, we can write a few less complex ones and save them in variables with descriptive names. In this way, the code becomes simpler, easier to read and understand and easier to maintain, debug and fix.

## Use of Constants

Well written code should not contain "magic numbers" and "magic strings". Such constants are all the literals in a program having a value other than 0,-1,1,"" and null.

### When to Use Constants

The use of constants allows us to avoid the use of "magic numbers" and strings in our programs, and enable us to give names to the numbers and strings we use.

Constants should be used whenever we need to use numbers or strings whose origin and meaning are not obvious. Constants should generally be defined for every number or string that is used more than once in a program.
e.g

- For filenames the program operates on.They need to be frequently changed and it is convenient to have them as named constants at the beginning of the program.
- For constants taking part in mathematical expressions.
- For buffer sizes and sizes of memory blocks

## Proper Use of Control Flow Statements

Control flow statements are represented by loops and conditional statements.

- Always enclose the body of loops and conditional statements in curly brackets – { and }.
- Deep nesting of **if** statements is a bad practice because it obstructs the comprehensibility of the code. Extracting parts of the code into separate methods is the easiest and most efficient way to reduce the level of nesting of a group of conditional statements, while preserving their logic.
- If we need a loop that will execute a fixed number of times, a for-loop is a good fit. If it is necessary to check some conditions in order to stop the execution of the loop, then it is probably better to pick a **while** loop. A while loop is suitable in cases where the exact number of iterations is not known. The execution there continues until the exit condition has been encountered. If the prerequisites for using a while loop are in place, but the loop body must unconditionally execute at least once, a do-while loop should be used instead.
- As with conditional statements, deep nesting of loops is a bad practice. Deep nesting usually happens because of a large number of loops and conditional statements residing in one another. This makes the code hard to read and maintain. Such code can easily be improved by moving away parts of it into separate methods.

## Defensive Programming

Defensive programming is a term denoting a practice towards defending the code from incorrect data. Defensive programming keeps the code from errors that nobody expects. It is implemented by checking the validity of all input data. This is the data coming from external sources, input parameters of methods, configuration files and settings, input from the user, and even the data from another local method.

The main idea behind defensive programming is that methods should check their input parameters (and other input data) and inform the caller when the object's internal state or the input parameters are incorrect

Defensive programming requires that all data is checked, even if it is coming from a trusted source. If the trusted source happens to have a bug, the bug will be found earlier and more easily.
Defensive programming is implemented through assertions, exceptions and other means of error handling.

### Assertions

Assertions are special conditions that should always be met. If not met, they throw an error message and the program terminates.

### Assertions vs. Exceptions

Exceptions are announcements for an error of for an unexpected event. They inform the programmer using the code for an error. Exceptions can be caught and program execution can still continue.

Assertions produce fatal errors. They cannot be caught or handled because they are meant to indicate a bug in the code. A failed assertion causes the program to terminate.

Assertions can be turned off. The concept is to have them turned on only at the time of developing, in order to find as many bugs as possible. When turned off, the conditions are no longer checked. Turning off the assertions is plausible when the software goes to production, since these checks are affecting the performance and the messages are not always meaningful to the end user.

If a particular check should continue to exist when the software goes to production (for example, checking the input that comes from the user), it should not be implemented as an assertion in the first place. Exceptions should be used in such cases instead. Assertions should only be used for conditions that, if not met, it is due to a bug in the program.

### Defensive Programming with Exceptions

Exceptions provide a powerful mechanism for centralized handling of error and unusual conditions. Exceptions allow problematic situations to be handled at many levels. They ease the writing and the maintenance of reliable program code.

Another difference between exceptions and assertions is that, in defensive programming, exceptions are mainly used for protecting the public interface of a class or component. This provides for a fail-safe mechanism.

Exceptions should be used to inform other parts of the code for problems that should not be ignored. Throwing an exception is reasonable only in situations when an abnormal condition has occurred. If a particular problem can be handled locally, the handling should be performed in the method itself, and no exceptions should be thrown. If a problem cannot be handled locally, the exception should be thrown to the caller. The thrown exceptions should be at an appropriate level of abstraction.

## Code Documentation

### Self-Documenting Code

A very important point to remember is that comments in the code are not the primary source of documentation. Good programming style provides the best documentation. Self-documenting code rarely needs comments because its intention becomes clear directly by reading it.

#### Properties of Self-Documenting Code

Self-documenting code boasts a good structure. In order to qualify our code as self-documenting, there are few questions we should ask ourselves:

- Is the class name appropriate and does it describe its main purpose?
- Is the **public interface** of the class intuitive to use ?
- Does the name of a method describe its main purpose ?
- Is every method performing a single, well-defined task?
- Are the names of the variables corresponding to the intent of their use ?
- Are loops performing only a single task?
- Are conditional statements deeply nested ?
- Does the organization of the code illustrate its logical structure ?
- Is the design clear and unambiguous ?
- Are implementation details hidden as much as possible ?

### Effective Comments

Comments can sometimes do more harm than good. Good comments do not repeat the code and do not explain it line by line: they rather clarify its idea. Comments should describe as a higher level what our intentions are. Comments enable use to think better about what we want to implement.

Comments should be written at the time the code is written, not after that. Productivity is never a good excuse for not writing comments. Everything that is not instantly obvious should be documented. Writing too much unnecessary comments is as bad as not having any at all. Bad code cannot be improved by putting more comments. It should instead be rewritten or refactored.

### XML Documentation in C

This is an in-built style in C#. It is enclosed in triple comments /// and uses few special XML tags: to document a type / method summary (`<summary>`), to describe method's parameters (`<param name="">`), to describe a method's return value (`<returns>`) to document exceptions that eventually might be thrown (`<exception cref="…"`), to make a cross-reference link to related type (`<seealso cref="…"/>`), to describe some remarks (`<remarks>`), to give an example how to use the type / method (`<example>`), etc.

Using XML-style documentation in the source code has several advantages

- The XML documentation is built-in the source code itself
- The XML documentation is automatically processed by Visual Studio and is displayed in its autocomplete feature.
- The XML documentation can be complied into an MSDN-style web site or e-book.

## Code Refactoring

- A program needs refactoring in case of code duplication.Code duplication is dangerous because a change in one place requires that all the other duplicated code be changed as well. The latter is error-prone and inconsistencies can arise therefore. Avoiding code duplication can be achieved by putting the particular piece of code in a method, or by moving common functionality to base classes.
- Refactoring is necessary for methods, which have grown over time. The excessive length of a method is a good reason to think about splitting it up logically into a few smaller and simpler methods.
- Deeply nested constructs are another reason for refactoring. they can be eliminated by taking out a block of code into a method.
- Classes that do not provide a sufficiently good level of abstraction or ones that perform unrelated tasks (weak cohesion) are candidates for refactoring as well.
- Long parameter lists and public fields should also do to the fix-it list. Tightly coupled classes go in the same category.

### Refactoring at Data Level

A good practice is to avoid magic numbers scattered throughout the code. They should be replaced by named constants. Variables with unclear names should be renamed. Long conditional expressions can be refactored into separate methods. Variables can be used to hold the intermediate results of expressions. A group of data that always appears together can be refactored into a separate class. Related constants should be grouped into enumerations.

### Refactoring at Method and Class Level

Within a longer method, all tasks that are unrelated to its main purpose are better moved into separate methods. Similar tasks should be grouped in common classes, similar classes – in a common package. If a group of classes have common functionality, it should be moved into a base class.
Circular dependencies between the classes should not exist, they should be removed. In most cases the more common class has a reference to the more specialized class (parent-child relationship).

## Unit Testing

