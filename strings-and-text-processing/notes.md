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
The method Trim() can accept an array of characters , which we want to remove from the string.

## Constructing Strings: the StringBuilder Class

Strings are immutable, this means that any adjustments applied to an existing string do not change it but return a new string. They allocate a new area in the memory where the new content is saved. This behavior has many advantages but is some cases can cause performance problems.

### String Concatentation in a Loop: Never Do This!

Serious performance problems may be encountered when trying to concatenate strings in a loop. The problem is directly related to the strings handling and dynamic memory, which is used to store them.

```C#
string str1 = "Super";
string str2 = "Star";
string result = str1 + str2;
```

What will happen with the memory? Creating the variable result will alocate a new area in dynamic memory, which will record the outcome of the str1 + str2 which is 'SuperStar'. Then the variable itself will keep the address of the allocated area. As a result we will have three areas in memory and 3 references to them. This is convenient , but allocating a new area, recording a value, creating a new variable and referencing it in memory is a time consuming process that would be problem when repeated many times typically inside a loop.

Unlike some programming languages, in C#, it is not necessary to manually dispose the objecs stored in memory. There is a special mechanism called a garbage collector(memory cleaning system), which takes care of clearing the unused memory and resources. The garbage collector is responsible for disposing of objects in dynamic memory when they are no longer used. Creation of many objects containing multiple references in dynamic memory is bad, because it fills memory and then the garbage collector is automatically enforced to start execution. It takes quite some time and slows the overal performance of the process. Furthermore, transferring characters from one place to another in memory (when string concatenation is executed) is slow, especially if the strings are long.

#### Processing Strings in Memory

The problem with time-consuming loop processing is related to the way strings work in memory. Each iteration creates a new object in the heap and point the reference to it. This process requires a certain physical time.

Several things happen at each step:

1. An area of memory is allocated for recording the next number concatenation result. This memory is used only temporarily while concatentating, and is called a buffer.
2. The old string is moved into the new buffer. If the string is long (say 500KB,5MB), it can be quite slow!
3. Next number is concatenated to the buffer.
4. The buffer is converted to a string
5. The old string and the temporary buffer become unused. Later they are destroyed by the garbage collector. This may also be a slow operation.

Much more elegant and appropriate way to concatenate strings in a Loop is using the StringBuilder class. Let’s see how it works.

#### Building and Changing Strings with StringBuilder

StringBuilder is a class that serves to build and change strings. It overcomes the performance problems that arise when concatenating strings of type `string`. The class is built in the form of an array of characters and what we need to know about it is that the information in it can be freely changed. Changes that are required in the variables of type `StringBuilder` are carried out in the same area of memory(buffer), which saves time and resources. Changing the content does not create a new object but simply changes the current.

##### How Does the StringBuilder Class Work?

The `StringBuilder` class is an implementation of a string in C#, but different than the class `String`. Unlike the already familiar strings, the objects of the StringBuilder class are not immutable, namely edit operations do not require creating a new object in the memory. This reduces the unnecessary transfer of data in memory when performing basic operations aas string concatenation.

StringBuilder keeps a buffer with a certain capacity (16 characters by default). The buffer is implemented as an array of characters that is provided to the developer by a user-friendly interface – methods that quickly and easily add and edit elements of the string. At any moment part of the characters in the buffer are used and the rest stay in reserve. This allows the addition to work very quickly. Other operations also operate faster than the class string, because the changes do not create a new object.
Once the internal buffer of the StringBuilder is full, it automatically is doubled (the internal buffer is resized to increase its capacity while its content is kept unchanged). Resizing is a slow operation but is happens rarely so the total performance is good.

#### StringBuilder - More Important Methods

The `StringBuilder` class provides us with a set of methods that help us to easily and efficiently edit text data and construct text.

- `StringBuilder(int capacity)` - constructor with an initial capacity parameter.It may be used to set the buffer size in advance if we have estimates of the number of iterations and concatenations, which will be performed. This way we can save unnecessary dynamic memory allocations
- `Capacity` - returns the buffer size (total number of used and unused positions in the buffer)
- `Length` - returns the length of string saved in the variable(number of used postitions in the buffer)
- `Index[int index]` -return the character stored in given position
- `Append(..)` -appends string, number or other value after the last charcter in the buffer
- `Clear(...)` - removes all characters from the buffer
- `Remove(int startIndex,int length)` - removes(deletes) string from the buffer with a given position and length
- `Insert(int offset,string str)` - insert a string in agiven start position(offset)
- `Replace(string oldValue,string newValue)` - replaces all occurences of a given substring with another substring
- `ToString()` - returns the StringBuilder object content as a string

### String Formatting
.NET Framework provides the developer with mechanisms for formatting strings, numbers and dates.

#### ToString(...)
One of the interesting concepts in .NET is that practically every object of a class and primitive variables can be presented as text. This is done by the method ToString(...), which is present in all .NET objects. It is implicit in the defintion of the object class - the base class that all .NET data types inherit directly or indirectly. Thus the definition of the method appears in each class and we can use it to bring the content of each object in some text form.

The method ToString(…) is called automatically when we print objects from different classes to the console

The default implementation of the ToString(...) method in the object class returns the full name of the class. All classes that do not explicitly redefine the bahaviour of the ToString(...) are using this implementation. Most classes in C# have their own implementation of the method, which represents readable and understandable content in text form.

#### String.Format(..)
`String.Format(...)` is a static method by which we can format text and other data through a template(formatting string). The templates contain text and declared parameters (placeholders) and are used to obtain formatted text after replacing the parameters with specific values.

### Parsing Data

The reverse operation of data formatting is data parsing. Parsing of data(data parsing) means to obtain a value of a given type from the text represantation of this value in a specific format i.e converting from text to some other data type, the opposite of ToString().

Often working with applications with graphical user interface requires the user input to be passed in variables of type string. This way, we can work well with numbers and charcters as well as text and dates, formatted in a user's preferred way. It is up to the developer's experience to represent the expected input data into the right way for the user. The data is then converted to a specific data type and processed.

When converting types, we should not rely only on trusting the user. Always check the correctness of the input user data! Otherwise there could be an exception that could change the normal program logic.

In case the passed to the `Parse(...)` method value is invalid for the type(e.g. we pass 'John' when parsing a number), an exception is thrown.

### Parsing Dates

Parsing to a date is similar to parsing to a numeric type, but it is recommended to set a specific date format. If we want to set a format explicitly, which does not depend on the culture, we can use the method DateTime.ParseExact(..) and specify particular formatting pattern of our choice

```C#
string text = "11/12/2001";
string format = "MM/dd/yyyy";
DateTime parsedDate = DateTime.ParseExact(
text, format, CultureInfo.InvariantCulture);
Console.WriteLine("Day: {0}\nMonth: {1}\nYear: {2}",
parsedDate.Day, parsedDate.Month, parsedDate.Year);
// Day: 12
// Month: 11
// Year: 2001

```
When parsing with an explicitly set format, it is required to pass a specific culture from which to take information about date format and separators between days and years. Since we want the parsing not to depend on a particular culture, we explicitly specify the neutral culture to be used: CultureInfo.InvariantCulture. To use the class CultureInfo, we must include the namespace System.Globalization in the beginning of our C# source code.