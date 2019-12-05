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
