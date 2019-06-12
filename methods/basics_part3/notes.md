## Method Overloading

When in a class, a method is declared and its name coincides with the name of another method, but their signatures differ by their parameters list(**count of the method's parameters** or **the way they are arranged**), we say that there are different variations/overloads of that method(method overloading). There are two things required in C# to specify a method signature, the parameter type and the order in which the parameters are listed.

Overloaded methods are invoked by their name and their special order or type of arguments

The return type is not part of the method signature

## Best Practices When Using Methods
- Each method must resolve a distinct, well defined task. This feature is also known as strong cohesion, i.e. it gives a focus onto one single task, not to several tasks no strongly related logically.A single method should perform a single task, its code should be well structured, easy to understand and easy to be maintained. One method must NOT solve several tasks!

- A method has to have a good name. i.e. the name that is descriptive and from which becomes clear what the method does. If it cannot be given a good name, this may indicate that the method solves more than one task and hence it must be separated into sub-methods

- The method name should describe an action, so they should contain a verb or a verb + noun.
- It is assumed that all the method names in C# will start with capital letter. PascalCase rule is used
- A method must do whatever is described with its name, or it must return an error(throws an exception). It is not correct that the methods return wrong or unusual result when it has received invalid input data. The method resolves the task it is created for, or returns an error. any other behavior is incorrect.
- A method must have minimum dependency to the class in which the method is declared and to other methods and classes. This feature of the methods is also known as losse coupling. This means that the method must do its job by using the data that passed to itt as parameters, but not data that can be accessed from other places.