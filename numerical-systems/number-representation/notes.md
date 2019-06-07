## Integer Representation

The largest number that can be represented, in binary form, in a computer depends on its word length. An n-bit word computer can hable a number as large as 2^n -1. Negative numbers are stored using 2's compliment. This is obtained by taking the 1's complement of the binary representation of the positive number and then adding 1 to it

### Integer Types in C

- **sbyte** - 8bits -128-127
- **byte** - 8 bits 0-255
- **short** - 16bits -32,768-32767
- **ushort** - 16bits 0-65535
- **int** -32bits -2,147,483,648 - 2,147,483,647
- **uint** -32bits 0 - 4,294,967,295
- **long** - –9,223,372,036,854,775,808 - 9,223,372,036,854,775,807
- **ulong** - 0 - 18,446,744,073,709,551,615

### Big-Endian and Little-Endian Representation

There are two ways for ordering bytes in the memory when representing integers longer than one byte. Endianness is the sequential order in a list of arbitrary objects. A little-endian ordering always places the least-significant(the "smallest") element in the lowest-enumarated("earliest") position. A big-endian ordering places the least-significant element in the largest-enumarated("latest") position
In computer science, endianness usually refers to the ordering of packing bytes into words when stored in memory. Endianness can also describe the ordering of bits packed into larger words,especially with respect to the order of bits transmitted over a serial data link.
In big-endian format, whenever addressing memory or sending/storing words bytewise, the most significant byte-the byte containing the most significant bit-is stores first(has the lowest address) or sent first, then the following bytes are stored or sent in decresing significance order, with the least significant byte-the one containing the least significant bit -stored last(having the highest address) or sent last

Little-endian format reverses this order: the sequence addresses/sends/stores the least significant byte first(lowest address and the most significant byte last(highest address))

### Representation of Floating Point Numbers

Real numbers consist of a whole and fraction parts.In computers, they are represnted as floating-point numbers.The representation comes from the Standard for Floating-Point Arithmentic(IEEE 754), adopted by the leading microprocessor manufacturers.

- Arithmetical formats: a set of binary and decimal data with a floating-point, which consists of a finite number of digits
- Exchange formats: encoding(bit sequences), which can be used for data exchange in an effective and compact form
- Rounding algorithms: methods, which are used for rounding up numbers during calcultations
- Operations: arithmetic and other operations of the arithmetic formats
- Exceptions: they are signals for extraordinary events such as division by zero, overflowing and others

In C# we have at our disposal two types, which can represent floating-point numbers. The float type is a 32-bit real number with a floating-point and it is accepted to be called single precision floating-point number. The double is a 64-bit real number with a floating-point and it is accepted that it has a double precision floating-point. These real data types and the arithmetic operations with them correspond to the specification outlined by the IEEE 754-1985 standard. In the following table are presented the most important characteristics of the two types:

float ; 32 bits : ±1.5 × 10−45 ÷ ±3.4 × 1038 7 significant digits
double : 64 bits : ±5.0 × 10−324 ÷ ±1.7 × 10308 : 15-16 significatn bits

### The Decimal Type

The System.Decimal type in the .NET Framework uses decimal floating-point arithmetic and 128-bit precision, which is very suitable for big numbers and precise financial calculations

Unlike the floating-point numbers, the decimal type retains its precision for all decimal number in its range. The secret to this excellent precision when working with decimal numbers lies in the fact that the internal representation of the mantissa is not in the binary system but in the decimal one. The exponent is also a power of 10, not 2. This enables numbers to be represented precisely, without them being converted to the binary numeral system.
Because the float and double types and the operations on them are implementer by the arithmetic coprocessor, which is part of all modern computer microprocessors, and decimal is implemented by the software in .NET CLR, it is tens of times slower than double, but is irreplaceable for the execution of financial calculations.

Even though the decimal type has a higher precision than the floating-point types, it has a smaller value range and, for example, it cannot be used to represent the following value 1e-50. As a result, an overflow may occur when converting from floating-point numbers to decimal.

## Character Data(Strings)

Character(text) data in computing is text, encoded using a sequence of bytes. There are different encoding schemes used to encode text data. Most of them encode one character in one byte or in asequence of several bytes. Such encoding schemes are ASCII, Windows-1251, UTF-8 and UTF-16.

### ASCII

American Standard Code for Information Interchange. compares the unique number of the letters from the Latin alphabet and some other symbols and special characters and writes them in a single byte. The ASCII standard contains a total of 127 characters, each of which is written in one byte. A text, written as a sequence of bytes according to the ASCII standard, cannot contain Cyrillic or characters from other alphabets such as the Arabian, Korean and Chinese ones

### Windows-1251

Like the ASCII standard, the Windows-1251 encoding scheme compares the unique number of the letters in the Latin alphabet, Cyrillic and some other symbols and specialized characters and writes them in one byte. The Windows-1251 encoding defines the numbers of 256 characters – exactly as many as the different values that can be written in one byte. A text written according to the Windows-1251 standard can contain only Cyrillic and Latin letters, Arabian, Indian or Chinese are not supported.

### UTF-8

Unicode Transformation Format.All characters in the Unicode standard – the letters and symbols used in all widely spread languages in the world (Cyrillic, Latin, Arabian, Chinese, Japanese, Korean and many other languages and writing systems) – can be encoded in it. The UTF-8 encoding contains over half a million symbols. In the UTF-8 encoding, the more commonly used symbols are encoded in 1 byte (Latin letters and digits for example), the second most commonly used symbols are coded in 2 bytes (Cyrillic letters for example), and the ones that are used even more rarely are coded in 3 or 4 bytes (like the Chinese, Japanese and Korean alphabet).

### UTF-16

like UTF-8 can depict text of all commonly used languages and writing systems, described in the Unicode standard. In UTF-16, every symbol is written in 16 bits (2 bytes) and some of the more rarely used symbols are presented as a sequence of two 16-bit values.

## Presenting a Sequence of Characters

Character sequences can be presented in several ways. The most common method for writing text in the memory is to write in 2 or 4 bytes its length, followed by a sequence of bytes, which presents the text itself in some sort of encoding (for example Windows-1251 or UTF-8). Another, less common method of writing texts in the memory, typical for the C language, represents texts as a sequence of characters, usually coded in 1 byte, followed by a special ending character, most frequently a 0. When using this method, the length of the text saved at a given position in the memory is not known in advance. This is considered a disadvantage in many situations.

### Char Type

The char type in the C# language is a 16-bit value, in which a single Unicode character or part of it is coded. In most alphabets (for example the ones used by all European languages) one letter is written in a single 16-bit value, and thus it is assumed that a variable of the char type represents a single character

### String Type

The string type in C# holds text, encoded in UTF-16. A single string in C# consists of 4 bytes length and a sequence of characters written as 16-bit values of the char type. The string type can store texts written in all widespread alphabets and human writing systems – Latin, Cyrillic, Chinese, Japanese, Arabian and many, many others
