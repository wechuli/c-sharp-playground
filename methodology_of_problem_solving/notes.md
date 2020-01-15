# Methodology of Problem Solving

## Use Pen and Paper

The use of a pen and sheet of paper and the making of drafts and sketches when solving problems is something normal and natural, which every experienced mathematician, physicist and software engineer does when tasked with a non-trivial problem.

## Generate Ideas and Give Them a Try

The first thing to do is to sketch some sample examples for the problem on a piece of paper. When we have a real example of the problem in front of us, we can reflect on it and the ideas come.

When the idea is a fact, we need more examples in order to check if it a good one. Then we need some more examples drafted on paper to verify it again. We should be completely sure our solution is correct.Then we should go through our solution one more time, step by step, the same way like one actual computer program would do, and see if everything runs correctly.

The next thing to do is to try "braking" our solution and thinking of a case, in which our idea would not work properly (a counter-example). If we fail at that, then our idea is probably right. If our solution definitely has a flaw, we should think of a way to fix it. If our idea does not pass every test, we should invent a new one. The first idea that comes to your mind is not always the correct one.

Problem-solving is an iterative process, which represents the invention of ideas and then testing them over different examples until you reach one which seems to work correctly with every example that you could think of.

Sometimes it can take hours for you to try and find the right solution of a given problem. This is completely normal. Nobody has an ability to instantly find the correct solution of a problem, but surely the more experience you have the faster the good ideas will come. If a particular problem has something in common with one that you have solved in the past, then the proper idea will come to your mind more quickly, because one of the basic characteristics of the human brain is to work with analogies. The experience you get from solving given type of problems will help you with the invention of ideas for a solution of other analogical problems.

## Decompose the Task into Smaller SubTasks

Complex tasks can always be divided into smaller more manageable subtasks. There is not a single complex problem in the world that can been solved with one try. The correct formula for solving such a task is to split it into smaller simpler tasks, which have to be independent and different from one another. If these smaller subtasks prove to be complicated, we should split them again. This technique is called "divide and conquer".

## Verify Your Ideas

It seems that we have figured out everything. We have an idea. It seems to work properly. The only thing for us to do is to check if our idea is correct or it is only correct in our minds. After that we can start with the implementation.

**How to verify an idea?** Usually this happens with the help of some examples. We should choose examples that fully cover all different cases, with our algorithm should be able to pass. The sample examples should not be too easy for your algorithm, but also they should not be so hard to be sketched. We call these certain types of examples "good representatives of the common case".

When verifying your ideas, choose your examples carefully. They should be simple and easy enough for you to be able to sketch them down by hand in a minute and at the same time they should represent most general case in which your idea should work. Your examples should be good representatives of the common case and cover as much cases as possible without being too big and complicated.

## If a Problem Occurs, Invent a New Idea!

When you find your idea is incorrect, the obvious thing to do is to invent a new, better idea. We can do this in two ways: we can either try to fix our old idea or create a completely new one.

        The creating of a solution for a computer programming problem is an iterative process, which consists of inventing ideas, verifying them and sometimes, when problem occurs, inventing new ones. Sometimes the first idea that comes to our mind is the right one, but most of the times we need to go through many different ideas until we reach the best one.

## Choose Appropriate Data Structures

We should choose the right data structures, which are going to help us build a correct solution. Before you even start with the implementation of your idea, you should choose the proper data structures. It may turn out that your current idea is not as good as it seems. The solution could be inefficient or difficult to implement. It is better to figure this out before your write any programming code.

The choice of data structure begins with the consideration of all key operations that we are going to perform on it. Next we analyze all suitable structures and choose the one that will be most efficient and easiest to use. And sometimes we should make a compromise between efficiency and the simplicity.

## Think about Efficiency

You should think of efficiency before writing even a line of a programming code. Otherwise, you risk wasting your time implementing an algorithm, which is inefficient and slow.

You can estimate how many operations an algorithm performs to solve the problem. We sometimes have to make a compromise between the performance and the efforts, which we put, when we implement our algorithm.

## Implement Your Algorithm

We have finally reached the time where we can start with the implementation of our solution. We already have a working idea, we have chosen the best data structure and now it is the time to start writing the programming code. The implementation of already invented and checked idea is very easy and simple. But the implementation itself requires additional skills and mostly experience. The more experience you have the faster and easier it will be for you to write efficient programming code. With lots of practice, which will come with time, you will become very skilled in writing high-quality code and you will be able to write code faster.

## Write the Code Step by Step

Do not write large lumps of code at one time, instead you should write small parts and then test them. This helps us reduce the amount of code that we have to concentrate on in any given moment. By treating the problem in parts, we decrease its complexity.

## Test Your Solution!

In programming, to be ready with a task means:
- I have understood the description of the task well
- I have come up with an algorithm to solve the problem
- I have tested my algorithm on a piece of paper and I am sure that it is correct
- I have thought up for the data structure we need and for the complexity of my algorithm
- I have written a program, which implements my algorithm correctly
- I have tested my program with suitable examples so that I can be sure that everything works flawlessly, even in unusual situations

Testing is an important part of the programmer's duties.

### How to Test?

A program works correctly if it can handle every kind of input data. Testing is a process, which aims to find any type of bugs. Sadly, you can't predict all cases and test them. Therefore you must think up examples, which cover most of the situations, which could happen.

It is good to start testing with a typical case for our program. After that we have to test our program with more difficult and bigger examples to see how our program behaves in more complicated situations. We now have to test with borderline cases and test for performance.

### What Else to Test For ?
- A **hard common-case test** - The goal is to check whether your program can handle a bigger and harder to compute example. It is never late to find a bug in our program and the only way we can do that is to test it with many tests, which cover practical situations.
- **Borderline tests** - They check whether your program can handle an unusual case, which could happen. How do we think of borderline cases ? We analyze all of the data, which is being entered, to our program and think up such extreme values, which are possible to be entered. These values could be extremely small, extremely large or just strange.
- **Performance tests** - These tests put our program in extreme conditions. Usually these tests consists of large data, which needs to be inputted and processed.

### Regression Test

While fixing bugs, we often create new bugs without noticing. On every edit of code, which concerns other cases, we must redo the tests. That's why it is a good idea to save the tests as methods and be able to run them again. Re-testing with the tests already passed in the past is called "regression testing"

### Performance Tests

It is normal to have some performance requirements about a module or the program at all.

## General Conclusions

The first step in acquiring programming-problem-solving techniques is to learn to approach the problem systematically and to acquire the recipe for problem solving.