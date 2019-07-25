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