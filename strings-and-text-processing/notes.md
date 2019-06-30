# Strings

A string is a sequence of charcters stored in a certain address in memory. The char variable can record only one charcter. where it is necessary to process more than one character, then strings come to our aid.

In .NET Framework, each character has a serial number from the Unicode table. The Unicode standard was established in the early 90s in order to store different types of text data. .NET uses 16-bit code table for the charcters. Thus 65536 chracters can be stored

The keyword string is an alias in C# of the System.String class from .NET Framework. The internal representation of the string class is quite simple - an array of charcters. Sometimes it is more appropriate to use a different charcter structure apart from the one offered by System.String.

The type string is a special data type. It is a class and as such it complies with the principles of object-oriented programming. Its values are stored in the dynamic memory(managed heap), and the variables of type string keeps a reference to an object in the heap.

## Strings are Immutable

The string class has an important feature - the character sequences stored in a variable of the class are never changing(immutable). After being assigned once, the content of the variable does not change directly - if we try to change the value, it will be saved to a new location in the dynamic memory and the variable will point to it.

Declaring a string represents a variable declaration of type string. This is not equivalent to setting a variable and allocating memory for it. With the declaration we inform the compiler that the variable str will be used and the expected type for it is string. We do not create a variable in the memory and it is not available for procesing yet(its value is null, which means no value)

Uninitialized variables of type string do not contain empty values, it contains the special value null - and each attempt for manipulating such a string will generate an error(exception for access to a missing value NullReferenceException)

We can initialize variables in the following 3 ways

1. By assigning a string literal
2. By assigning the value of another string
3. By passing the value of an operation which returns a string

### Assigning Value of Another String

e.g

```C#
string source = "Some source";
string assigned = source;
```

Since the string class is a reference type, the text 'Some source' is stored in the dynamic memory(heap) on an address defined by the first variable

In the second line we redirect the variable assigned to the same place, which the other variable points to. In this way, the two objects receive the same address in dynamic memory and hence the same value.
The change of either variable will affect only itself because of the immutability of the type string, as when a change occurs, a copy of the changed string willbe created. This is not true for the rest of the reference types(the normal, mutable types) because with them, the changes are made directly in the address in memory and all references point to theis changed address.

## String Operations

### Comparing Strings in Alphabetical Order

#### Comparison for Equality

If the requirements are to compare the two strings in order to determine whether their values are equal or not, the most convenient method is the Equals(…), which works equivalently to the operator ==. It returns a Boolean result with either true value, if the strings have the same values, or false value, if they are different. The method Equals(…) checks letter by letter for equality of string values, as it makes distinction between small and capital letters, i.e. comparing the "c#" and "C#" with the Equals(…) method will return the value false

In practice, we often are interested of only the actual text content when comparing two strings, regardless of the character casing (uppercase / lowercase). To ignore the difference between small and capital letters in string comparison we can use the method Equals(…) with the parameter StringComparison.CurrentCultureIgnoreCase. So now in the same example of comparing "C#" with "c#" the method will return the value true:

```C#
Console.WriteLine(word1.Equals(word2,
StringComparison.CurrentCultureIgnoreCase));
// True
```

## Comparing Strings in Alphabetical Order

If you want to compare two words and get information which one of them is before the other according to their alphabetical order of letters, here comes the method CompareTo(…). It allows us to compare the values of two strings in order to determine their lexicographical order. In order two strings to have the same values, they must have the same length (number of characters) and the all their characters should match accordingly. For example, the strings "give" and "given" are different because they differ in their lengths, and "near" and "fear" differ in their first character.

The method CompareTo(…) from the String class returns a negative value, 0 or positive value depending on the lexical order of the two compared strings. A negative value means that the first string is lexicographically before the second, zero means that the two strings are equal and positive value means that the second string is lexicographically before the first.

If we have to compare the strings lexicographically, namely to ignore the letters casing, then we could use string.Compare(string strA, string strB, bool ignoreCase).

Please note that according to the methods Compare(…) and CompareTo(…) the small letters are lexicographically before the capital ones. The correctness of this rule is quite controversial as in the Unicode table the capital letters are before the small ones. For example due to the standard Unicode, the letter “A” has a code 65, which is smaller than the code of the letter “a” (97).

### The == and != Operators

In the C# language the operators == and =! work for strings through an internal calling of Equals(…). We will go through some examples for using those two operators with variables from the string type:

## Memory Optimization for Strings

there is an optimization in the C# compiler and in CLR, which saves the memory from creating duplicated strings. This
optimization is called strings interning and thanks to it the two variables in the memory will be pointed to the same common block of memory. This reduces the memory space usage and optimizes certain operations such as comparing two completely matching strings. They are written in the memory in the following way:

When we initialize a variable of type string with a string literal, the memory checks invisibly for us whether this value already exists. If the value already exists, the new variable is simply pointed to it. If not, a new block of memory is allocated, the value is stored in it and the reference is changed to point to the new block. The string interning in .NET is possible because strings are immutable by design and it is not likely that the memory block referenced by several string variables will simultaneously be changed by someone.

## Manipulating Strings

concatentation,searching a string,extracting substrings, change the character casing,splitting a string by separator etc.

Strings are immutable! Any chhange of a variable of type string creates a new string in which the result is stored. therefore, operations that apply to strings return as a result a reference to the result. It is possible to process strings without creatin new objects in the memory every time a modification is made but for this purpose the StringBuilder should be used.

### String Concatentation

We can concatentate other data with strings. Any data, which can be presented in a text form can be appended to a string

### Upper and LowerCase

### Seraching Strings

When we have a string with a specified content, it is often necessary to process only a part of its value. The .NET platform provides us with two methods to search a string within another string: IndexOf(…) and LastIndexOf(…). They search into the string and check whether the passed as a parameter substring occurs in its content. The result of those methods is an integer. If the result is not a negative value, then this is the position where the first character of the substring is found. If the method returns value of -1, it means that the substring was not found. Remember that in C# indexing into strings start from 0.

The methods IndexOf(…) and LastIndexOf(…) search the contents of the text sequence, but in a different direction. The search with the first method starts from the beginning of the string towards the end, while the second method – the search is done backwards. If we are interested in the first encountered match, then we use IndexOf(…). If we want to search the string from its end (for example to detect the last dot in a file name or the last slash in an URL address), then we use LastIndexOf(…).

When calling IndexOf(…) and LastIndexOf(…) a second parameter could be passed, which will specify the position, which the searching should start from. This is useful if we want to search part of a string, not the entire string.

The methods IndexOf(…) and LastIndexOf(…) distinguish between uppercase and lowercase letters. If we want to ignore this difference, we can write text in a new variable and turn it to a text with entirely lower or entirely uppercase, and then we can perform the search in it, independently from the letters casing.

### Extracting a Portion of A string

We can use the method Substring(). By using it, we can extract a part of the string(substring) by a given starting position in the text and its length. If the length is omitted, a portion from the text will be extracted, starting from the initial position to the string's end.

Calling the method Substring(startIndex,length) extracts a substring from a string, which is located betwen startIndex and (startIndex + length-1) inclusively.

### Splitting the String by a Separator

One of the most flexible methods for working with strings is Split(). It allows us to split a string by a separator or an array of possible separators

### Replacing a Substring

The text processing in .NET Framework provides ready methods for replacing a substring with another.

The method `Replace()` replaces all the occurrences of a given substring with another substring, not just the first.

## Regular Expressions

Regular expressions are a powerful tool for text procesing and allow searching matches by a pattern. Regular expressions make text processing easier and more accurate: extracting some resources from texts, searhcing for phone numbers, finding email addresses in a text, splitting all the words in a sentence, data validation etc.

### Removing Unnecessary Characters at the Beginning and at the End of a String

When entering text in a file or to the console, you can often find some "parasitic" spaces (white-space) at the beginning or at the end of the text - some other space or a tab that cannot be observed at first glance. This may not be essential but if we do not validate the user data, there would be a problem in terms of checking the contents of the input information. In order to solve this problem, we can use the method Trim(). It is responnsible for eliminating (trimming) the white spaces at the beginning or at the end of a string. The white spaces can be spaces, tabs, line breaks etc
