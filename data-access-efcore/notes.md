# Data Access in C# and .NET Core

Data is a very important piece in all enterprise applications and almost every other type of application you will need to develop. Data is usually stored in databases. An application usually has an object model that represents the data it deals with created in the form of classes.

At the backend of the application, you need to store this data in a reliable storage to be able to access it back when needed, it is like your archive. This is usually a database that has tables of data created with columns to represent the same data you are using in the application object model.

To load the data from the database into your application object model, and store or update the data back into the database from your application, you need a way to map the columns in the database tables to the properties of your application object model classes by storing some information to know what fields in the database should map to what properties in the application data model. This information is called metadata. And this mapper is referred to as **Object to Relational Mapper** or simply ORM.

The Object-Relational Mapper, or simply ORM, is an a programming technique of connecting an object model in an object-oriented programming languages to a relational database by using metadata as the descriptor of the object and data.

As an application developer you will not be building ORM for your application, in most cases, you will be using an ORM tool provided either by the framework you are using or by a third-party provider (for example, LINQ to SQL) that provides you with ready-to-use mapping functionality.

Entity Framework, or simply EF, is an object-relational mapper (O/RM) that enables .NET developers to work with a database using .NET objects. It eliminates the need for most of the data-access code that developers usually need to write.

Entity Framework (EF) is an object-relational mapper (O/RM) that enables .NET developers to work with relational data from a database using domain-specific .NET objects. It eliminates the need for most of the data-access code that developers usually need to write. Entity Framework is Microsoft’s recommended data access technology for new applications.

EF Core is a lightweight, modern, extensible, and cross-platform version of Entity Framework.

EF Core supports many database engines like: Microsoft SQl Server, IBM Data Server (DB2), SQLite, MySQL, and PostgreSQL. Some of these databases are natively supported by EF Core, while others are supported through third party providers using NuGet packages that need to be installed.

EF Core is the recommended data access technology for new applications and for applications that target .NET Core, such as Universal Windows Platform (UWP) and ASP.NET Core applications.

With EF Core, data access is performed using a `model`. A model is made up of entity classes and a derived context that represents a session with the database, allowing you to query and save data.

## Importing Schema from existing DB

In many cases, you will build an application that performs data access operations against an existing database. You can use EF Core to do the reverse engineering to create an Entity Framework model based on the existing database. This is called **Scaffolding**.

## Creating Entities with EF Core

When you have an application and you need to create a database for it using EF Core, you will be taking a code-first approach meaning that you will be creating the model first. From that model EF Core will generate the database tables and sets your application up to interact with the database.

Remember that EF Core achieves data access by using a model and the model is composed of two main parts, the context and the entity classes.

The entities(or entity sets) are basically the tables you have (or will have) in the database which represents a certain concept. In your EF Core model, these entities will translate into classes or objects in the .Net application data model and in that sense, they are called Entity Classes.

For example, Lets say in your class enrollment website application you are taking a code-first approach targeting a new database and you are planning to have three tables. One table for students data, one for enrollment data and a third table for courses data. In the code-first approach you will be creating the model in your application first that includes the entity classes and the context. In this lesson we will be focusing on creating the entity classes portion of the model. In this example, you will be creating three entity classes for the three mentioned tables to be able to access their data in your application model.

![](assets/sql.PNG)

```C#
public class Student
{
    public int ID {get;set;} // this is the primary key of the Student table
    public string LastName {get;set;}
    public string FirstMidName {get;set;}
    public DateTime EnrollmentDate {get;set;}

    // Enrollments is a navigation property to hold enrollment data found in another table
    public ICollection<Enrollment> Enrollments {get;set;}
}


```

The ID property will become the primary key column of the database table that corresponds to this class. By default, the Entity Framework interprets a property that's named ID or `classnameID` as the primary key.

The `Enrollments` property is a **navigation property**. Navigation properties hold other entities that are related to this entity. In this case, the `Enrollments` property of a `Student` entity will hold all of the Enrollment entities that are related to that Student entity. In other words, if a given Student row in the database has two related Enrollment rows, that Student entity's Enrollments navigation property will contain those two Enrollment entities.

If a navigation property can hold multiple entities (as in many-to-many or one-to-many relationships), its type must be a list in which entries can be added, deleted, and updated, such as `ICollection<T>`. You can specify `ICollection<T>` or a type such as `List<T>` or `HashSet<T>`. If you specify `ICollection<T>`, EF creates a `HashSet<T>` collection by default.

```C#
// The Enrollment Entity Class
///////////////////////////
   public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }  //foreign key
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }


```

The EnrollmentID property will be the primary key; this entity uses the `classnameID` pattern instead of ID by itself as you saw in the Student entity. Ordinarily you would choose one pattern and use it throughout your data model. Here, the variation illustrates that you can use either pattern.

The Grade property is an enum. The question mark after the Grade type declaration indicates that the Grade property is nullable. A grade that's null is different from a zero grade – null means a grade isn't known or hasn't been assigned yet, it is an empty field in the table row.

The StudentID property is a foreign key, and the corresponding navigation property is Student. An Enrollment entity is associated with one Student entity, so the property can only hold a single Student entity (unlike the Student.Enrollments navigation property you saw earlier, which can hold multiple Enrollment entities).

The CourseID property is a foreign key, and the corresponding navigation property is Course. An Enrollment entity is associated with one Course entity.

Note: Entity Framework interprets a property as a foreign key property if it's named <navigation property name><primary key property name> (for example, StudentID for the Student navigation property since the Student entity's primary key is ID). Foreign key properties can also be named simply <primary key property name> (for example, CourseID since the Course entity's primary key is CourseID).

```C#

// The Course Entity Class
///////////////////////////////
using System.ComponentModel.DataAnnotations.Schema;

public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

```

The Enrollments property is a navigation property. A Course entity can be related to any number of Enrollment entities.

The DatabaseGenerated attribute lets you enter the primary key for the course rather than having the database generate it (not auto generated).

## Create the Database Context

The main class that coordinates Entity Framework functionality for a given model is the database context class. You create this class by deriving from `Microsoft.EntityFramework.DbContext` class. The derived context represents a session with the database, allowing you to query and save data. In your code you specify which entity classes are included in the data model by exposing a typed `DbSet<TEntity>` for each class in your model. You can also customize certain Entity Framework behavior. For the same class enrollment example we have been looking at in the previous lesson, we will create a DBContext class named SchoolContext.

```C#
using Microsoft.EntityFrameworkCore;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }
}

```

This code creates a `DbSet` property for each entity set. In Entity Framework terminology, an entity set typically corresponds to a database table and an entity corresponds to a row in the table.

NB
You could have omitted the `DbSet<Enrollment>` and `DbSet<Course>` statements and it would work the same. The Entity Framework would include them implicitly because the Student entity references the Enrollment entity and the Enrollment entity references the Course entity. This has been explained in the previous lesson when we created the entity classes.

When the database is created, EF creates tables that have names the same as the DbSet property names. Property names for collections are typically plural (Students rather than Student), but developers disagree about whether table names should be pluralized or not. EF Core gives you the option to override the default behavior by specifying different table names than the corresponding DbSet names in the `DbContext`. To do that, you will override the OnModelCreating method of the DbContext parent class. Add the following highlighted code after the last DbSet property.

```C#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Course>().ToTable("Course");
    modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
    modelBuilder.Entity<Student>().ToTable("Student");
}

```

The final code for the SchoolContext class will look like this:

```C#
using Microsoft.EntityFrameworkCore;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().ToTable("Course");
        modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        modelBuilder.Entity<Student>().ToTable("Student");
    }
}

```

As you have seen, Entity Framework uses a set of conventions to build a model based on the shape of your entity classes. You can specify additional configuration to supplement and/or override what was discovered by convention. There are two main methods for configuring a model.

### Methods of model configuration

1. **Fluent API**

You can override the `OnModelCreating` method in your derived context and use the ModelBuilder API to configure your model. This is the most powerful method of configuration and allows configuration to be specified without modifying your entity classes. Fluent API configuration has the highest precedence and will override conventions and data annotations.

```C#
class MyContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .IsRequired();
        }
    }

```

2. **Data Annotations**

You can also apply attributes (known as Data Annotations) to your classes and properties. Data annotations will override conventions, but will be overwritten by Fluent API configuration.

```C#
public class Blog
    {
        public int BlogId { get; set; }
        [Required]
        public string Url { get; set; }
    }

```

That is all the code you need to start storing and retrieving data.

## Basic Data Operations

The next step that comes normally after you create the model(both the entities and the context) is to start dealing with the data by reading and writing from and to the database through the EF model. The basic data operations in computer programming are referred to as CRUD which is the acronym for data operations involving Create, Read, Update and Delete. CRUD can map to the corresponding standard SQL statements for relational database operations which are INSERT SELECT UPDATE and DELETE.

Entity Framework Core uses Language Integrated Query (LINQ) to query data from the database. LINQ allows you to use C# to write strongly typed queries based on your derived context and entity classes. The dbcontext derived class you will create in your application, which represents a database session, along with the DBSet objects you have defined in it, both have functionalities, form their respective .Net classes and parent classes DbContext and DbSet, that allows you to do CRUD operations.

### Create

To create or insert a new entity(or row) in a database table you need to use the `DbSet.Add` method and supply the new student object. After that, you will need to confirm the insert so that EF Core would actually reflect that into the database.

```C#

using(var context = new SchoolContext()
{
	var newStudent = new Student(....);
	context.Students.Add(newStudent);
	context.SaveChanges();
}

```

### Read

To read or select data from your tables you need to use LINQ queries.

```C#
using(var context = new SchoolContext())
{
	// Get all Students from the database
		var query = from s in context.Students
				select s;

		Console.WriteLine("All students in the database:");
	//Display all students' names
		foreach (var item in query)
		{
			Console.WriteLine(item.Name);
		}
		Console.ReadKey();
}
```

### Update

EF Core will automatically detect changes made to an existing entity that is tracked by the context. This includes entities that you load/query from the database and entities that were previously added and saved to the database. Simply modify the values assigned to properties and then call `SaveChanges`

```C#
using (var context = new SchoolContext())
{
    var course = context.Courses.First();
    course.Title = "Data Access in C# and .Net Core";
    context.SaveChanges();
}
```

### Delete

Use the DbSet.Remove method to delete instances of you entity classes. If the entity already exists in the database, it will be deleted during SaveChanges. If the entity has not yet been saved to the database (i.e. it is tracked as added) then it will be removed from the context and will no longer be inserted when SaveChanges is called.

```C#
using (var context = new SchoolContext())
{
    var lastCourse = context.Courses.Last();
    context.Courses.Remove(lastCourse);
    context.SaveChanges();
}

```

Note: All operations that require a write to the database (create, update, delete ) require a call to the DbContext.SaveChanges method so that EF reflects the changes in the database.

Note: You can combine multiple Add/Update/Remove operations into a single call to SaveChanges. For most database providers, SaveChanges is transactional. This means all the operations applied to the context since the last save will either succeed (commit) or fail (rollback) and the operations will never be left partially applied.

## Querying Data

### Sorting

Many times you will need to query the database and have the returned data sorted based on a certain field or group of fields and you may want your sorting to be in an ascending or descending order. Two main methods for sorting are provided through the System.Linq namespace and you can use them off your DbSet objects: OrderBy and OrderByDescending. Also, you can achieve sorting by using the orderby clause when writing LINQ queries using LINQ syntax.

#### OrderBy method

```C#
using System.Linq;

using(var context = new SchoolContext()
{
	// Get all Students from the database ordered by Name
	var orderedStudents = context.Students.OrderBy(s => s.First);
	console.WriteLine("All students in the database:");
	//Display all students' names in ascending order
	foreach (var student in orderedStudents)
	{
		Console.WriteLine(student.First + " " + student.Last);
	}
	// Keep the console window open in debug mode
	Console.WriteLine("Press any key to exit.");
	Console.ReadLine();
}
```

The Enumerable.OrderBy method that is available from the System.Linq namespace sorts the elements of a sequence in ascending order. Since the Microsoft.EntityFrameworkCore.DbSet class is an enumerable (implements the IEnumerable interface), you can use this method off any DbSet object in your model. LINQ queries against a Microsoft.EntityFrameworkCore.DbSet will be translated into queries against the database. The input to the method is a Func that specifies the source to be sorted and the field in that source that will act as the key to use for sorting.
OrderBy method compares keys by using the default comparer for the key type. An overload of the method is available that can sort the elements of a sequence in ascending order by using a specified comparer. It is the developers responsibility to create the IComparer and pass it to the method upon calling.

#### OrderByDescending method

To sort items in descending order according to a certain key, the Enumerable.OrderByDescending method that is available from the System.Linq namespace sorts the elements of a sequence in descending order. The method is very similar to the OrderBy method except that it does the sorting in the reverse order. Everything mentioned above for the OrderBy method is also true for the OrderByDescending method.

```C#
using System.Linq;

using(var context = new SchoolContext()
{
	// Get all Students from the database ordered by Age
	var orderedStudents = context.Students.OrderByDescending(s => s.Age);
	console.WriteLine("All students in the database listed from oldest to youngest:");
	//Display all students' names in ascending order
	foreach (var student in orderedStudents)
	{
		Console.WriteLine(student.First + " " + student.Last + " : " + student.Age);
	}
	// Keep the console window open in debug mode
	Console.WriteLine("Press any key to exit.");
	Console.ReadLine();
}
```

#### orderby clause

In a query expression, the orderby clause in a LINQ query causes the returned sequence or subsequence (group) to be sorted in either ascending or descending order. Multiple keys can be specified in order to perform one or more secondary sort operations. The sorting is performed by the default comparer for the type of the element. The default sort order is ascending. At compile time, the orderby clause is translated to a call to the OrderBy method. Multiple keys in the orderby clause translate to ThenBy method calls.

```C#

using System.Linq;

using(var context = new SchoolContext()
{
	// Get all Students from the database ordered by Name
	var query = from s in context.Students
			orderby s.Last ascending, student.First ascending
			select s;

	console.WriteLine("All students in the database:");
	//Display all students' names
	foreach (var student in query)
	{
		Console.WriteLine(student.Last + " " + student.First);
	}
	// Keep the console window open in debug mode
	Console.WriteLine("Press any key to exit.");
	Console.ReadLine();
}

```

### Paging

As with many web applications, you may have a need for server-side paging. Paging is used in web applications to present large amounts of information to users. For example, when you post a query to an Internet search engine, it usually returns thousands of results. If the engine returned all those results at once, the browser or the receiving application would be overwhelmed. This is also very important in the critical conditions for small companies, with limited hardware or software. The places where Internet access is limited and slow. We also have the need to reduce network traffic data. These are factors that require a query to retrieve only the needed data that will be displayed in the User Interface screen, excluding the extra that maybe used in another page or cause an unnecessary overhead to the system. Paging is the feature that achieves these requirements. Paging breaks the data into fixed-size blocks that make the results manageable and reduces the amount of information that moves between the server and the client at one time. With paging, the application gets only a few records at a time. Paging makes the data easier to understand and browse, and also helps improve application performance as retrieving and processing large amounts of information creates unnecessary overhead that can slow your system.

There are two main methods provided by EF Core with which you can achieve paging in your application:
`a.Enumerable.Skip` Method `b.Enumerable.Take` Method

#### Skip method

The Enumerable.Skip method that is available from the System.Linq namespace is used to bypass a specified number of elements in a sequence and then returns the remaining elements. This is method definition:

```C#
public static IEnumerable<TSource> Skip<TSource>(
	this IEnumerable<TSource> source,
	int count
)

```

The method takes two parameters:

1. a source which is an `IEnumerable` type to query the data from.
2. a count which is an integer numeral that represents the number of elements to skip before returning the remaining elements.

The method returns an `IEnumerable<T>` that contains the elements that occur after the specified index in the input sequence.

```C#
using System.Linq;

using(var context = new SchoolContext()
{
	// Get all Students from the database starting from the 6th student
	var pagedStudents = context.Students.Skip(5);
	console.WriteLine("All students in the database:");
	//Display all students' names starting skipping the first five
	foreach (var student in pagedStudents)
	{
		Console.WriteLine(student.First + " " + student.Last);
	}
	// Keep the console window open in debug mode
	Console.WriteLine("Press any key to exit.");
	Console.ReadLine();
}

```

If the collection source contains fewer than the supplied count elements, an empty `IEnumerable<T>` is returned. If the count is less than or equal to zero, all elements of the source are yielded.

Two variations of the Skip method are SkipLast and SkipWhile. The SkipLast method takes a count integer and skips the last count elements in the returned collection. The SkipWhile method bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.

This code will skip the last two students from the Students table:

```C#
var pagedStudents = context.Students.SkipLast(2);
```

and this code will skip all students who are older than 18 years old:

```C#
var pagedStudents = context.Students.SkipWhile(s => s.Age > 18)
```

#### Take method

The `Enumerable.Take` method is also available from the `System.Linq` namespace and is used to get a specified number of contiguous elements from the start of a sequence.

This code will get the oldest three students in the students table:

```C#

var pagedStudents = context.Students.OrderByDescending(s => s.Age).Take(3);
	foreach (var student in pagedStudents)
	{
		Console.WriteLine(student.First + " " + student.Last + " " + student.Age);
	}
	// Keep the console window open in debug mode
	Console.WriteLine("Press any key to exit.");
	Console.ReadLine();

```

Note: The Take and Skip methods are functional complements. Given a sequence coll and an integer n, concatenating the results of coll.Take(n) and coll.Skip(n) yields the same sequence as coll.

## LINQ in EF Core

Language-Integrated Query (LINQ) is the name of a set of technologies based on the integration of query capabilities directly into the C# language. Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support. Furthermore, you have to learn a different query language for each type of data source: SQL databases, XML documents, various Web services, and so on. With LINQ, a query is a first-class language construct, just like classes, methods, events.

For a developer who writes queries, the most visible “language-integrated” part of LINQ is the query expression. A Query is an expression that retrieves data from a data source. Query expressions are written in a declarative query syntax or language. Different languages have been developed over time for the various types of data sources, for example SQL for relational databases and XQuery for XML. Therefore, developers have had to learn a new query language for each type of data source or data format that they must support. LINQ simplifies this situation by offering a consistent model for working with data across various kinds of data sources and formats. By using LINQ query syntax, you can perform filtering, ordering, and grouping operations on data sources with a minimum of code. You use the same basic query expression patterns to query and transform data in SQL databases, ADO .NET Datasets, XML documents and streams, .NET collections, and any other format for which a LINQ provider is available.

Entity Framework Core uses Language Integrate Query (LINQ) to query data from the database. LINQ allows you to use C# (or your .NET language of choice) to write strongly typed queries based on your derived context and entity classes. A representation of the LINQ query is passed to the database provider, to be translated in database-specific query language (e.g. SQL for a relational database).

All LINQ query operations consist of three distinct actions:

- Obtain the data source - in the case of EF Core, the data source is the model.
- Create the query.
- Execute the query.

The following example shows how the three parts of a query operation are expressed in source code. The example uses the entity classes in a DbContext as a data source.

```C#

class LINQBasics
{
    static void Main()
    {
        // The Three Parts of a LINQ Query:
        //  1. Data source.
        var students = context.Students;

        // 2. Query creation.
        // studentsQuery is an IEnumerable<Student>
        var studentsQuery =
            from student in students
            where (students.Age > 10)
            select student;

        // 3. Query execution.
        foreach (var student in studentsQuery)
        {
            Console.WriteLine(students.Name);
        }
    }
}

```

The query specifies what information to retrieve from the data source or sources. Optionally, a query also specifies how that information should be sorted, grouped, and shaped before it is returned. A query is stored in a query variable and initialized with a query expression. To make it easier to write queries, C# has introduced new query syntax. The query in the previous example returns all the students who are older than 10 years old. The query expression contains three clauses: from, where and select. (If you are familiar with SQL, you will have noticed that the ordering of the clauses is reversed from the order in SQL.) The from clause specifies the data source, the where clause applies the filter, and the select clause specifies the type of the returned elements. In LINQ, the query variable itself takes no action and returns no data. It just stores the information that is required to produce the results when the query is executed at some later point. The actual execution of the query is deferred until you iterate over the query variable in a foreach statement. This concept is referred to as deferred execution.

There are two main clauses in LINQ expressions that we would like to focus on besides the from, where, and select clauses, these are the group clause and the orderby clause:

### The group clause

The `group` clause returns a sequence of `IGrouping<TKey,TElement>` objects that contain zero or more items that match the key value for the group.

For example, you can group a sequence of strings according to the first letter in each string. In this case, the first letter is the key and has a type char, and is stored in the Key property of each `IGrouping<TKey,TElement>` object. The compiler infers the type of the key.

You can end a query expression with a group clause, as shown in the following example:

```C#
// Query variable is an IEnumerable<IGrouping<char, Student>>
var studentQuery1 =
    from student in students
    group student by student.Last[0];
```

If you want to perform additional query operations on each group, you can specify a temporary identifier by using the into contextual keyword. When you use into, you must continue with the query, and eventually end it with either a select statement or another group clause, as shown in the following example:

```C#

// Group students by the first letter of their last name
// Query variable is an IEnumerable<IGrouping<char, Student>>
var studentQuery2 =
    from student in students
    group student by student.Last[0] into g
    orderby g.Key
    select g;

```

Because the `IGrouping<TKey,TElement>` objects produced by a group query are essentially a list of lists, you must use a nested foreach loop to access the items in each group. The outer loop iterates over the group keys, and the inner loop iterates over each item in the group itself. A group may have a key but no elements. Group keys can be any type, such as a string, a built-in numeric type, or a user-defined named type or anonymous type. The following is the foreach loop that executes the query in the previous code examples:

```C#
// Iterate group items with a nested foreach. This IGrouping encapsulates
// a sequence of Student objects, and a Key of type char.
// For convenience, var can also be used in the foreach statement.
foreach (IGrouping<char, Student> studentGroup in studentQuery2)
{
     Console.WriteLine(studentGroup.Key);
     // Explicit type for student could also be used here.
     foreach (var student in studentGroup)
     {
         Console.WriteLine("   {0}, {1}", student.Last, student.First);
     }
 }


```

### The orderby clause

In a query expression, the orderby clause causes the returned sequence or subsequence (group) to be sorted in either ascending or descending order. Multiple keys can be specified in order to perform one or more secondary sort operations. The sorting is performed by the default comparer for the type of the element. The default sort order is ascending.
The following example performs a primary sort on the students' last names, and then a secondary sort on their first names:

```C#
IEnumerable<Student> sortedStudents =
            from student in students
            orderby student.Last ascending, student.First ascending
            select student;

// Now create groups and sort the groups. The query first sorts the names
// of all students so that they will be in alphabetical order after they are
// grouped. The second orderby sorts the group keys in alpha order.
var sortedGroups =
    from student in students
    orderby student.Last, student.First
    group student by student.Last[0] into newGroup
    orderby newGroup.Key
    select newGroup;

```
