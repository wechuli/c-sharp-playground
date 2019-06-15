# Recursion

Recursion is a programming technique in which a method makes a call to itself to solve a particular problem. Such methods are called recursive. By means of recursion we can solve complicated combinatorial problems, in which we can easily exhaust different combinatorial configurations e.g generating permutations and variations and simulating nested loops.

## Direct and Indirect Recursion

When in the body of a method there is a call to the same method, we say that the method is directly recursive. If method A calls method B, method B calls method C and method C calls method A, we call the methods A,B and C indirectly recursive or mutually recurcive.

## Bottom of Recursion

When using recursion, we have to be totally sure that after a certain count of steps we get a concrete result. For this reason, we should have one or more cases in shich the solution could be found directlly, without a recursive call. These cases are called bottom of recursion.
If a recursive method has no base i.e. bottom, it will become infinite and the result will be a StackOverflowException.

## Creating Recursive Methods

When we create recursive methods, it is necessary that we break the task we are trying to solve in subtasks, for the solution of which we can use the same algorithm(recursively). The combination of solutions of all subtasks should lead to the solution of the initial problem.

In each recursive call, the problem area should be limited so that at some point the bottom of the recusrion is reached i.e breaking of each subtask must lead eventually to the bottom of the recursion.

Before proceeding with recursive implementation, we should think about an iterative variant, after which we should choose the better solution according to the situation

## Simulation of N Nested Loops

Very often, we have to write nested loops. It is very easy when they are two, or three. However, if their count is not known in advance, we have to think of an alternative approach

## Recursion VS Iteration

If the algorithm solving the problem is recursive, the implementation of the recursive solution can be much more readable and elegant than iterative solution to the same problem. Sometimes defining equivalent algorithm is considerably more difficult and it is not easy to prove that the two algorithms are equivalent.
In certain cases, by using recusrion, we can accomplish much simpler shorter and easy to understand solutions. On the other hand, recursive calls can consume much more resources(CPU time and memory). On each recursive call in the stack, new memory is set aside for arguments, local variables and returned reults. If there are too many recursive calls, a stack overflow could happen because of lack of memory. In certain situations, the recursive solutions can be much more difficult to understand and follow than the relevant iterative solutions.
Recursion is a powerful programming technique, but we have to think carefully before using it. If used incorrectly, it can lead to inefficient and tough to understand and maintain solutions.

### Closer look at the Fibonaci Recursive algorithmic solution

Avoid recursion, unless you are certain about how it works and what has to happen behind the scenes. Recursion is a great and powerful weapon, with which you can easily shoot yourself in the leg. Use it carefully.

## More about Recusrion and Iteration

Generally, when we have a linear computational process, we do not have to use recursion because iteration can be constructed easily and leads to simple and efficient calculations.
What is distinctive about linear computational processes is that on each step of the calulation, recursion is called only once, only in one direction. In such a process, when we have only one recursive call in the body of the recursive method, it is not necessary to use recursion, because the iteration is obvious.

Recursion has to be used when it provides simple, easy-to-understand and efficient solution to a problem, for which we have no obvious iterative solution.

In tree-like(branched) computational processes on each step of the recursion, a couple of recursive calls are made and the scheme of calculations could be visualized as a tree(and not as a list like in linear calculations).

A typical scheme of a tree computational process could be described with a pseudo-code in the following way:

```C#

void Recursion(parameters)
{
do some calculations;
Recursion(some parameters);
…
Recursion(some other parameters);
do some calculations;
}

```
Use recursion for branched recursive calculations(and ensure each value is calculated only once). For linear recursive calculations, prefer using iteration.
