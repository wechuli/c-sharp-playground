# Text Files

## Streams

Streams are an essential part of any input-output library. You can use streams when your program needs to 'read' or 'write' data to an external data source such as files, other PCs, servers etc

A stream is an ordered sequence of bytes, which is sent from one application or input device to another application or output device. These bytes are written and read one after the other and always arrive in the same order as they were sent. Streams are an abstraction of a data communication channel that connects two devices or applications.

Streams are the primary means of exchanging information in the computer world. Because of streams, different applications are able to access filed on the computer and are able to establish network communication between remote computers.In the world of computers, many operations can be interpreted as reading and writing to a stream.For example, printing is a process of sending a sequence of bytes to a stream, associated with the corresponding port, to which is the printer connected. Recreating sounds from the computer’s sound card can be done by sending some commands, followed by the sample sound, which is actually a sequence of bytes. The scanning of documents from a scanner can be done by sending commands to the scanner (an output stream) and then reading the scanned image (an input stream). This way, you can work with any peripheral device (camera, mouse, keyboard, USB stick, soundcard, printer, scanner etc.).

Every time you read or write from or to a file, you have to open a stream to the corresponding file, do the reading or writing and then close the stream. There are two types of streams - text streams and binary streams but this separation has to do with the interpretation of the sent and received bytes. Sometimes, for convenience, a sequence of bytes can be treated as text(in a predefined encoding) and is referred to as a text stream.

Today's modern web sites cannot do without the so-called streaming, which represents stream access to bulky multimedia files coming from the Internet. Streaming audio and video allows files to be played before they are downloaded locally, making the site more interactive. Streams and media streaming are different concepts but both use sequences of data.

### Basic Concepts on Streams

- Many devices use streams for reading and writing data. Because of streams, communication between program and file, program and remote computer is made easy.
- Streams are \*ordered sequences of bytes\*\*. The word 'order' is intentionally left stressed because it is of great importance to remember that streams are highly ordered and organized. In no way must you influence the order of the information flow, because it will render it unusable. If a byte is sent to a stream earlier than another byte, it will arrive earlier at the other end of the stream, which is guaranteed by the abstraction "stream".

- Streams allow sequenctial data access. Again, it is important to understand the meaning of the word sequenctial. You can manipulate the data only in the order in which it arrives from the stream. This is closely related to the previous feature. You cannot take the first, then the righth, then 4th and so on. Streams do not allow random access to their data, only sequenctial. You can think of streams as of a linked list that contains bytes, in which they have a strict order.
- Different situations require different types of streams. Some streams are used with text files, others-with binary files and then there are those that work with strings. For network communciation, you have to use a specific type of stream. The vast variety of streams can help us in different situations, but can also trouble us, because we need to be familiar with every type of stream, before we can use it in our application
- Streams are opened before we can begin working with them and are closed after they have served their purpose. Closing the stream is very important and must not be left out, because you risk losing data, damaging the file, to which the stream is opened and so on - all these are very troublesome scenarios, which must not happen in our programs.
- We can say that streams are like pipes that connect two points. From one side we pour data in and from the other data leaks out. The one who pours data is not concerned of how it is transfered, but can be sure that what he has poured will out the same on the other side. Those who use streams do not care how the data reaches them. They know that if someone poured something on the other side, it will reach them. Therefore, we can consider streams as a data transport channel, such as pipes.

## Basic Operations with Streams

You can do the following operations with streams: creation/opening, reading data, writing data, seeking/positioning, closing/disconnecting

### Creation

To create or open a stream means to connect the stream to a data source, a mechanism for data transfer or another stream. For example, wehn we have a file stream, then we pass the file name and the file mode in which it is to be opened(reading,writing or reading and writing simultanesouly).

### Reading

Reading means extracting data from a stream. Reading is always performed sequentially from the current position of the stream. Reading is a blocking operation. A delay may occur if we try to read from a stream where the other party has not sent any data.

### Writing

Writing means sending data to the stream in a specific way. The writing is performed from the current position of the stream. Writing may be a potentially blocking operation, before the data is sent on its way. For example, if you send bulk data via a network stream, the operation may be delayed while the data is travelling over the network.

### Positioning

Positioning or seeking in the stream means to move the current position of the stream. Moving is done according to the current position, where we can position according to the current position, beginning of the stream or the end of the stream.Moving can be done only in streams that support positioning.

### Closing

To close or disconnect a stream means to complete the work with the stream and release the occupied resources. Closing must take place as soon as possible after the stream has served its purpose, because a resource opened by a user, cannot usually be used by another user(including other programs on the same computer that run parallel to our program)

## Streams in .NET - Basic Classes

In .NET Framework classes for working with streams are located in the namespace **System.IO**.
We can distinguish two main types of streams - those who work with binary data and those which work with text data.
At the top of the stream hierarchy stands an abstract input-output stream class. It cannot be instantiated but defines the basic functionality that all the other streams have.

These are buffered streams that do not add any extra functionality but use a buffer for reading and writing data, which significantly enhances perfomance.

Some streams add additional functionality to reading and writing data. For example, there are streams that compress/decompress data sent to them and streams that encrypt/decrypt data. These streams are connected to another stream(such as file or network stream) and add additional processing to its functionality.

The main classes in the **System.IO** namespace are **Stream**(abstract base class for all streams in .NET Framework), BufferedStream, FileStream, MemoryStream, GZIPStream and NetworkStream.

All streams in C# have one thing in common - it is mandatory to close them after we have finished working with them. Otherwise we risk damaging the data in the stream or file that we have opened.

Always close the streams and files you work with! Leaving an open stream or file leads to loss of resources and can block the work of other users or processes in your system.

## Binary and Text Streams

### Binary Streams

Binary streams, as their name suggests, work with binary(raw) data. They can be used to read information from all sorts of files(images, music and multimedia files, text files etc)
The main classes that we use to read and write from and to binary streans are : FileStream, BinaryReader and BinaryWriter

The class FileStream provides us with various methods for reading and writing from a binary file(read/write one byte and a sequence of bytes), skipping a number of bytes, checking the number of bytes available and of course a method for closing the stream. We can get an object of that class by calling its contructor with a file name as an argument.

The class BinaryWriter enables you to write primitive types and binary values in a specific encoding to a stream. It has one main method – Write(…), which allows recording of any primitive data types – integers, characters, Booleans, arrays, strings and more.

BinaryReader allows you to read primitive data types and binary values recorded using a BinaryWriter. Its main methods allow us to read a character, an array of characters, integers, floating point, etc. Like the previous two classes, we can get on object of that class by calling its constructor.

### Text Streams

Text streams are very similar to binary, but only work with text data or rather a sequence of charachetrs(chars) and strings(string). Text streams are ideal for working with text files. On the other hand, this makes them unusable when working with any binaries.

The main classes for working with text streams in .NET are TextReader and TextWriter. They are abstract classes and they cannot be instantiated. These classes define the basic functionality for reading and writing for the classes that inherit them. Their more important methods are:

- **ReadLine()** - reads one line of text and returns a atring
- **ReadToEnd()**- reads the entire stream to its end and returns a string
- **Write()** - writes a tring to the stream
- **WriteLine()** - writes one line of text into the stream

The characters in .NET are Unicode characters, but streams can also work with Unicode and other encodings like the standard encoding for Cyrillic languages

The classes, to which we will turn our attention to in this chapter, are StreamReader and StreamWriter. They directly inherit the TextReader and TextWriter classes and implement functionality for reading and writing textual information to and from a file.
To create an object of type StreamReader or StreamWriter, we need a file or a string, containing the file path. Working with these classes, we can use all of the methods that we are already familiar with, to work with the console. Reading and writing to the console is much like reading and writing respectively with StreamReader and StreamWriter.

### Relationship between Text and Binary Streams

When writing text, hidden from us, the class **StreamWriter** transforms the text into bytes before recoding it at the current position in the file. For this purpose, it uses the character encoding, which is set during its creation. The StreamReader class works similarly. It uses StringBuilder internally and when reading binary data from a file, it converts the received bytes to text before sending the text back as a result from reading.

Rememeber that the operation systems have not concepts of "text file". The file is alwyas a sequence of bytes, but whether it is text or binary depends on the interpretion of these bytes. If we want to look at a file or stream as text, we must read and write to it with text streams.

Bear in mind that text streams work with text lines, that is, they interpret binary data as a sequence of text lines, separated from each other with a new line separators.

The character for the new line is not the same for different platforms and operating systems. For UNIX and Linux it is LF (0x0A), for Windows and DOS it is CR + LF (0x0D + 0x0A), and for Mac OS (up to version 9) it is CR (0x0A). Reading one line of text from a given file or a stream means reading a sequence of bytes until reading one of the characters CR or LF and converting these bytes to text according to the encoding, used by the stream. Similarly, writing one line of text to a text file or stream means writing the binary representation of the text (according to the current encoding), followed by the character (or characters) for a new line for the current operating system (such as CR + LF).

It is recommended to avoid full paths and work with relative paths! This makes your application portable and easy for installation and maintenance. Using the full path to a file(e.g. C:\Temp\test.txt) is bad practice because it makes your application dependent on the environmanet and also non-transferable.

Remember that when you start the C# program, the current directory is the one, in which the executable (.exe) file is located. Most often this is the subdirectory bin\Debug or bin\Release directory to the root of the project. Therefore, to open the file example.txt from the root directory of your Visual Studio project, you should use a relative path ..\..\example.txt.
