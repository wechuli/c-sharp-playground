## Methods with Return

Methods usually return results.

When the method is executed and returns a value, we can imagine that C# puts this value where this method has been invoked from. Then the program continues work with that value. We can also assign the result of the method execution to a variable of an appropriate type. After a method returns a result, it can be then be used in expressions too. We can pass the result from the method execution as value in the parameters list from another method

### Return Value Type

The result that a method returns can be of any type, and if the method does not return a result, the keyword void is used. To make a method return a value, the keyword return must be places in the method's body followed by an expression that will be returned as a result.

The result returned by the method can be of a type that is compatible(the one that can be implicitly converted) with the type of the returned value. You can use an expression after the Return Operator

### Features of the Return Operator

- Stops the method execution immediately, any code below it will not be executed.
- Returns the result of the executed method to the calling method

When the method has void for returned value type, then after return, there would be no expression to be returned. In that case return usage is only used to stop the method's execution

#### Multiple Return Statements

The return operator can be called from several places in the code of our method, but should be gauranteed that atleast one of the operators return that we have used will be reached while executing the method.

The returned type is not a part of the method signature, so it is not allowed to have several methods that have equal name and parametyers, but different type of returned value.
