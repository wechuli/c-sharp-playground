## Expressions as Method Arguments

When a method is invoked, we can pass a whole expression instead of arguments. By doing so, C# calculates the values for those expressions and by the time of code execution replaces the expression with its result, when the method is invoked.

We must pass only arguments that are of type compatible with the related parameter, declared in the method's parameter list.

Values, that are passed to the method, ion the time of its invocation, must be in the same order as the parameters are declared in the parameters list.

## Variable Number of Arguments(var-args)
We can declare methods that allow the count or arguments to be different any time the method is incoked, so to meet the needs of the invoking code. Such methods are often called with a variable number of arguments.
When

## Position and Declaration of a Method with Variable Arguments
A method that has a variable number of arguments, can also have other parameters in its parameters list. The one thing that we must consider is that the element from the parameters list in the method's definition that allows passing of a variable number of arguments, must always be place at the end of the parameters list.

For the methods with variable number of arguments, the method cannot have in its declaration more than one parameter that allows passing of variable numbers of arguments. The var-args parameter can be empty

## Optional Parameters and Named Arguments

Optional parameters allow some parameters to be skipped when a method is invoked. Named arguments on their side, allow method parameter values to be set by their name instead of their exact position in the parameters list.
Declration of optional parameters can be done just by using default value.

We can pass a value by a particular parameter name, by setting the parameter's name, followed by a colon and the value of the parameter.