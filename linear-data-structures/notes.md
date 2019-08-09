# Linear Data Structures

Very often, in order to solve a given problem, we need to work with a sequence of elements. Depending on the task, we have to apply different operations on this set of data.
- Abstract data types(ADT)
- Linked list
- Doubly-linked list
- array-list
- stacks
- queue

## Abstract Data Structures

Very often, when we write programs, we have to work with many objects(data). Sometimes we add and remove elements, other times we would like to order them to process the data in another specific way. For this reason, different ways of storing data are developed, depending on the task. Most frequently, these elements are ordered in some way. At this point, we come to the need of data structures -a set od data organized on the basis of logical and mathematical laws. Very often, the right data structure makes the program much more efficient - we could save memory and execution time.

In general, abstract data types(ADT) gives us a definition(abstraction) of the specific structure i.e. defines the allowed operations and properties without being interested in the specific implementation. This allows an abstract data type to have several different implementations and repectively different efficiency.

The definition of ADT only mentions what operations are to be performed but not how these operations will be implemented. It does not  specify how data will be organized in memory and what algorithms will be used for implementing the operations. It is called "abstract" because it gives an implementation-independedn view. The process of providing only the essentials and hiding the details is known as abstraction.


### Basic Data Structures in Programming

We can differentiate several groups of data structures:

- **Linear** - these include lists, stacks and queues
- **Tree-like** - different types of tress like binary trees, B-trees and balanced trees
- **Dictionaries** - key-value pairs organized in hash tables
- **Sets** - unordered bunches of unique elements
- **Others** - multi-sets, bags, multi-bags, priority queues, graphs

Mastering basic data atsructures in programming is essential,as without them we could not program efficiently.

## List

We could imagine the list as an ordered sequence (line) of elements. List is a linear data atsructure, which contains a sequence of elements. The list has the property length(count of elements) and its elements are arranged consecutively.

The list allows adding elements on different positions, removing them and incremental crawling.

An Interface in C# is a type definition similar to a class, except that it purely represents a contract between an object and its user. It can neither be directly instantiated as an object, nor can data members be defined. So and interface is nothing but a collection of method and property declarations.

Each ADT defines some interface. Let's consider the interface System.Collections.IList. The basic methods, which it defines are:
- int Add(object) - adds element in the end of the list
- void Insert(int,object) - adds elements on a preliminary chosen position in the list
- void Clear() - removes all elements in thenlist
- bool Contains(object) - checks whether the list contains the element
- void Remove(object) - removes the element from the list
- void RemoveAt(int) - removes the element on a given position
- int IndexOf(object) - returns the position of the element
- this[int] - indexes, allows access to the elements on a set position

Let’s see several from the basic implementations of the ADT list and explain in which situations they should be used.

### Static List(Array-Based Implemkentation)

Arrays perform many of the features of the ADT list, but there is a significant difference - the lists allow adding new elements, while arrays have fixed size.

Despite of that, an implementation of list is possible with an array, which automatically increments its size.


