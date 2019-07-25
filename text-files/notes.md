# Text Files

## Streams

Streams are an essential part of any input-output library. You can use streams when your program needs to 'read' or 'write' data to an external data source such as files, other PCs, servers etc

A stream is an ordered sequence of bytes, which is sent from one application or input device to another application or output device. These bytes are written and read one after the other and always arrive in the same order as they were sent. Streams are an abstraction of a data communication channel that connects two devices or applications.

Streams are the primary means of exchanging information in the computer world. Because of streams, different applications are able to access filed on the computer and are able to establish network communication between remote computers.In the world of computers, many operations can be interpreted as reading and writing to a stream.For example, printing is a process of sending a sequence of bytes to a stream, associated with the corresponding port, to which is the printer connected. Recreating sounds from the computer’s sound card can be done by sending some commands, followed by the sample sound, which is actually a sequence of bytes. The scanning of documents from a scanner can be done by sending commands to the scanner (an output stream) and then reading the scanned image (an input stream). This way, you can work with any peripheral device (camera, mouse, keyboard, USB stick, soundcard, printer, scanner etc.).

Every time you read or write from or to a file, you have to open a stream to the corresponding file, do the reading or writing and then close the stream. There are two types of streams - text streams and binary streams but this separation has to do with the interpretation of the sent and received bytes. Sometimes, for convenience, a sequence of bytes can be treated as text(in a predefined encoding) and is referred to as a text stream.

Today's modern web sites cannot do without the so-called streaming, which represents stream access to bulky multimedia files coming from the Internet. Streaming audio and video allows files to be played before they are downloaded locally, making the site more interactive. Streams and media streaming are different concepts but both use sequences of data.
