# C# Attributes

Attributes provide a powerful method of associating metadata, or declarative information, with code(assemblies, types, methods, properties and so forth). After an attribute is associated with a program entity, the attribute can be queried at run time by using a technique called reflection.

Attributes have the following properties:

- Attributes add metadata to your program. Metadata is information about the types defined in a program. All .NET assemblies contain a specified set of metadata that describes the type and type members defined in the assembly. You can add custom attributes to specify any additional information that is required.
- You can apply one or more attributes to entire assemblies, modules or smaller program elements such as classes and properties.
- Attributes can accept arguments in the same way as methods and properties.
- Your program can examine its own metadata or the metadata in other programs by using reflection

## Uses of attributes

- Configure conditional code completion
- Control debugging experience
- Mark code as deprecated
- Add metadata without code comments
- Define data validation rules
- Control serialization/deserialization
- Control runtime rendering/display
- Expose internals
- Mark methods as test methods
- Specify design time data/appearance
- Configure serverless functions bindings

Attributes are basically additional information about your code. They are compiled into the assembly unlike comments. You can have a prebuilt or custom attributes.

We can use attributes at code time, design time and run time.

### Code time

- Coding
- Compilation
- Debugging

### Design time

- Visual GUI designer
- IDE

### Run time

- ASP.NET
- Azure Functions
- Reflection

## Attributes Inheritance

- Attributes can be inherited

### Controlling the debugging experience

- `[DebuggerDisplay]`
- `[DegubberTypeProxy]`
- `[DebuggerBrowsable]`

## Custom attributes

- Defining where a custom attribute can be applied
- Allowing a custom attribute to be used multiple times
- Controlling attribute inheritance
- Create a custom display attribute
- Access a runtime with reflection
- Apply custom attribute
- Add a class level custom attribute
- Add a multiple use custom attribute
