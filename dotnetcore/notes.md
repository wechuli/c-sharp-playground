# .NET Core

**.NET Core** is an open-source, general-purpose development platform maintained by Microsoft and the .NET community. It's cross-platform and can be used to build device, cloud and IoT applications.

.NET Core has the following characteristics:

- Cross-platform
- Consistent across architectures
- Command-line tools: Includes easy-to-use command-line tools that can be used for local development and in continous-integration scenarios
- Flexible deployment:Can be included in your app or installed side-by-side(user-wide or system-wide installations)
- Compatible with .NET Framework, Xamarin and Mono via .NET Standard
- Open source
- Supported by Microsoft

**.NET Standard** is a formal specification of .NET APIs that are intended to be available on all .NET implementations. The motivation behind the .NET Standard is establishing greater uniformity in the .NET ecosystem.

.NET Core exposes APIs for many scenarios e.g

- Primitive types, such as bool and int.
- Collections, such as System.Collections.Generic.List<T> and System.Collections.Generic.Dictionary<TKey,TValue>.
- Utility types, such as System.Net.Http.HttpClient, and System.IO.FileStream.
- Data types, such as System.Data.DataSet, and DbSet.
- High-performance types, such as System.Numerics.Vector and Pipelines.

Multiple frameworks have been built on top of .NET Core:

- ASP.NET Core
- Windows 10 Universal Windows Platform(UWP)
- Tizen

## Composition

.NET Core is composed of the following parts

- The .NET Core runtime, which provides a type system, assembly loading, a garbage collector, native interop and other basic services. .NET Core framework libraries provide primitive data types, app composition types and fundamental utilities
- The ASP.NET runtime, which provides a framework for building modern cloud-based internet connected applications such as web apps, IoT apps and mobile backends
- The .NET Core CLI tools and language compilers that enable the .NET Core developer experience
- The dotnet tool, which is used to launch .NET Core apps and CLI tools. It selects the runtime and hosts the runtime, provides an assembly loading policy and launches apps and tools

These componets are distributed in the following ways

- **.NET Core Runtime** - includes the .NET Core runtime and framework libraries
- **ASP.NET Core Runtime**- includes ASP.NET Core and .NET Core runtime and framework libraries
- **.NET Core SDK** -- includes the .NET CLI Tools, ASP.NET Core runtime and .NET Core runtime and framework.
