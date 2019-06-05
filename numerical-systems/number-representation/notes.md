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
