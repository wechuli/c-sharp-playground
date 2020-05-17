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

## Lambda expressions

Lambda expression is a shorter way of representing anonymous methods (delegates) using certain syntax (the lambda operator =>)

```C#
//the anonymous method
delegate(Student s) { return s.Age > 12 && s.Age < 20; };

//the lambda expression equivalent opetained by removing the delegate keyword and parameter type and adding a lambda operator => to separate the lambda's parameter list from its executable code.
s => { return s.Age > 12 && s.Age < 20; };
```

In the above example, we have only one statement that returns a value, in this case, we don't need the curly braces, return and semicolon. Also we can remove paranthesis(), if we have only one parameter.

```C#

 s => s.Age > 12 && s.Age < 20
```

If you have more than one parameter to pass, use parantheses as follows:

```C#

(s, minAge) => s.Age >= minAge;

```

### lambda returns

Lambda expressions that don't return a value correspond to a specific Action delegate, depending on its number of parameters. Lambda expressions that return a value correspond to a specific Func delegate, depending on its number of parameters. For example, a lambda expression that has two parameters but returns no value corresponds to an `Action<T1,T2>` delegate. A lambda expression that has one parameter and returns a value corresponds to `Func<T,TResult>` delegate. The last parameter type in a `Func<>` delegate is the return type and the rest are input parameters. The following lambda expression returns true if a student in between the age of 12 and 20.

```C#
Func<Student, bool> isStudentAgeInRange = s => s.age > 12 && s.age < 20;
Student s = new Student() { age = 14 };
// returns true
bool isTeen = isStudentAgeInRange(s);

```

### Querying with Lambda Expression

You do not use lambda expressions directly in query syntax, but you do use them in method calls. Since LINQ query syntax must be translated into method calls for the .NET common language runtime (CLR) when the code is compiled, lambda expressions can therefore be used in LINQ query expressions.

The following example demonstrates how to use a lambda expression in a method call of a query expression. The lambda is necessary because the Sum standard query operator cannot be invoked by using query syntax.

The query first groups the students according to their grade level, as defined in the GradeLevel enum. Then for each group it adds the total scores for each student. This requires two Sum operations. The inner Sum calculates the total score for each student, and the outer Sum keeps a running, combined total for all students in the group.

```C#

private static void TotalsByGradeLevel()
{
    // This query retrieves the total scores for First Year students, Second Years, and so on.
    // The outer Sum method uses a lambda in order to specify which numbers to add together.
    var categories =
    from student in students
    group student by student.Year into studentGroup
    select new { GradeLevel = studentGroup.Key, TotalScore = studentGroup.Sum(s => s.ExamScores.Sum()) };

    // Execute the query.
    foreach (var cat in categories)
    {
        Console.WriteLine("Key = {0} Sum = {1}", cat.GradeLevel, cat.TotalScore);
    }
}
/*
     Outputs:
     Key = SecondYear Sum = 1014 (just an example number)
     Key = ThirdYear Sum = 964 (just an example number)
     Key = FirstYear Sum = 1058 (just an example number)
     Key = FourthYear Sum = 974 (just an example number)
*/

```

LINQ query syntax must be translated into method calls for the .NET common language runtime (CLR) when the code is compiled. These method calls invoke the standard query operators, which have names such as Where, Select, GroupBy, Join, Max, and Average. You can call them directly by using method syntax instead of query syntax. The following example shows a simple query expression and the semantically equivalent query written as a method-based query.

```C#

class QueryVMethodSyntax
{
    static void Main()
    {
        int[] numbers = { 5, 10, 8, 3, 6, 12};

        //Query syntax:
        IEnumerable<int> numQuery1 =
            from num in numbers
            where num % 2 == 0
            orderby num
            select num;

        //Method syntax:
        IEnumerable<int> numQuery2 = numbers.Where(num => num % 2 == 0).OrderBy(n => n);

        foreach (int i in numQuery1)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine(System.Environment.NewLine);
        foreach (int i in numQuery2)
        {
            Console.Write(i + " ");
        }

        // Keep the console open in debug mode.
        Console.WriteLine(System.Environment.NewLine);
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}
/*
    Output:
    6 8 10 12
    6 8 10 12
 */

```

The output from the two examples is identical. You can see that the type of the query variable is the same in both forms: `IEnumerable<T>`.

## Migrations

When you develop a new application, your data model changes frequently, and each time the model changes, it gets out of sync with the database. If the database has no data yet, then maybe each time you change the data model- add, remove, or change entity classes or change your DbContext class - you can delete the database and EF Core creates a new one that matches the model, and seeds it with tests data if you are using any test data. However, in real production applications with real data in the database, this is not the case. When the application is running in production it is usually storing data that you want to keep, and you don't want to lose everything each time you make a change such as adding a new column. The EF Core Migrations feature solves this problem by enabling EF to update the database schema instead of creating a new database. After doing the changes in your model, you run the migration command which reflects the changes in your database.

### When to use migrations

1. In a code first approach with no pre-existing database, you create the application model as entity classes along with a DbContext class. Then EF Core can use this model to create the back-end database. This is called an initial migrations.
2. While working on your application, if you need to make any changes to your model (add a column, create an index, drop a table, ...etc) after the creation of the database, you can run a migration, after the model changes, to reflect these changes in the existing database.

### Generating and Running Migrations

Code First Migrations has two primary commands:

1. **Add-Migration** - will scaffold the next migration based on changes you have made to your model since the last migration was created. Each migration gets a unique name. When you run this command, the `Migrations` folder in your project directory will have a file with the migration name. The migration filename is pre-fixed with a timestamp to help ordering.
2. **Update-Database** - will apply any pending migrations added to the Add-migration command to the database. This is when the database is actually updated with the changes in the migration.

### Running the Add-Migration command

When you make some changes in your application model then run the Add-Migration command, EF Core will auto generate the migration file in the migrations folder. This file will contain a class that inherits from Microsoft.EntityFrameworkCore.Migrations.Migration and has a definition for two main methods. One method with the name Up and the other will have the name Down.

The Up method will have the EF generated code that will execute on the database when you call Update-Database command. The Down method has the EF generated code that will execute in the case of rolling back the migration.

## Keys, Composite Keys and Alternate Keys

A key serves as the primary unique identifier for each entity instance. When using a relational database, this maps to the concept of a primary key. Each entity needs one primary key. A primary key can either be:

1. **Simple key** which is configured using a single property or column. A simple key is usually referred to as just a key.
2. **Composite key** primary key that is composed of multiple properties or column from one table

In general keys can be generated using three methods:

1. **Conventions**: EF Core convention is that a property named Id or <type name>Id in the entity model will be automatically configured as the key of an entity when you run a migration. Conventions can be used to create simple primary keys.

```C#
class Car
{
    public string Id { get; set; }

    public string Make { get; set; }
    public string Model { get; set; }
}
```

2. **Data Annotations**: You can also use data annotations [Key] to configure a single property to be the key of an entity in the entity model. Data Annotations can be used to create simple primary keys.

```C#
class Car
{
	//configuring a key using data annotations
    [Key]
    public string LicensePlate { get; set; }

    public string Make { get; set; }
    public string Model { get; set; }
}

```

3. **The Fluent API HasKey**: The Fluent API can be used to create single as well as composite keys. It is the only way to create composite keys in EF Core. When using the Fluent API to create a key you will configure that in the DbContext derived class in the body of the OnModelCreating method.

```C#
class MyContext : DbContext
{
    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		//single property key
        modelBuilder.Entity<Car>()
            .HasKey(c => c.LicensePlate);

		//multiple property key
	modelBuilder.Entity<Car>()
            .HasKey(c => c.State, c.LicensePlate);
    }
}

class Car
{
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
}

```

### Alternate Keys

An alternate key serves as an alternate unique identifier for each entity instance in addition to the primary key. Alternate keys can be used as the target of a relationship. When using a relational database this maps to the concept of a unique index/constraint on the alternate key columns(s) and one or more foreign key constraints that reference the columns(s)

Conventions and Fluent API can be used to create alternate keys. Data Annotations can't be used to create alternate keys.

1. **Conventions** - By convention, an alternate key is introduced for you when you identify a property, that is not the primary key, as the target of a relationship.

```C#
class MyContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Posts)
            .HasForeignKey(p => p.BlogUrl)
            .HasPrincipalKey(b => b.Url);
    }
}
```

2. **Fluent API HasAlternateKey method** - You can use the Fluent API to configure a single property to be an alternate key. You can also configure multiple properties to be an alternate keys (known as composite alternate key).

```C#
class MyContext : DbContext
{
    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
	//single property alternate key
        modelBuilder.Entity<Car>()
            .HasAlternateKey(c => c.LicensePlate);
    }

	//multiple property alternate key
	modelBuilder.Entity<Car>()
            .HasAlternateKey(c => c.State, c.LicensePlate);
}
```

## Indexes

Indexes are a common concept across many data stores like files and databases. While their implementation may vary in different data stores, they are used to make lookups based on a column (or set of columns) more efficient. By convention, an index is created in each property(or set of properties) that are used as a foreign key.

### The Fluent API to create Indexes

The term Fluent API refers to a pattern of programming where method calls are chained together with the end result being less verbose and more readable than a series of statements. EF Core's Fluent API provides methods for configuring various aspects of your model. For example, the Fluent API is used to create an index on a specific property in an entity model by using `HasIndex` method. Index creation usually takes place on the `OnModelCreating` method. The following code shows how to create an index using the Fluent API

```C#
class MyContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasIndex(s => s.LastName);
    }
}

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

By default, indexes are non-unique. You can also specify that an index should be unique by using the IsUnique method, meaning that no two entities can have the same value(s) for the given property(s).

```C#
modelBuilder.Entity<Blog>()
            .HasIndex(b => b.Url)
            .IsUnique();
```

you can also create an index over more than one column as follows:

```C#

class MyContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasIndex(p => new { p.FirstName, p.LastName });
    }
}

```

## Related Entities

Any database of substance will have related tables. Dealing with those related tables can be an issue without some background knowledge.

There are different relationship types that can exist between data in a database:

1. One-to-One relationship
2. One-to-Many relationship
3. Many-to-Many relationship

The One-to-one relationship is the most basic type of relationship that can exist between tables or entities. It occurs when one row or record table is linked to one and only one record in another table record only. These relationships are the easiest to represent in a database. If you look at the relationship from any side that it can be related to the other side or table by only one link. For example, in a parent/teacher conference scheduling system each time slot is linked to one family and each family is assigned one time slot to have the conference at. So if table A has the records of families information and table B has the available slots records, then this is a one-to-one relationship where each family is scheduled for one slot and each slot is reserved for one family.

### How tables are linked

A relationship defines how two entities relate to each other. In a relational database, this is represented by a foreign key constraint. Foreign keys are used to link tables together. A foreign key is called so because it is a field borrowed from the parent table in a relationship and added to the child table(also known as dependent table or entity) to keep track of the relationship. A foreign key is not required to be unique. Usually, the foreign key in a child table is the primary key of the parent table of a relationship. In the case of one-to-one relationship, a foreign key needs to be unique to enforce the one and only one relationship type. To achieve this, you can introduce a unique index on the foreign key property to ensure only one dependent is related to each principal.

### Creating a one-to-one relationship in EF Core

EF Core uses conventions to auto detect one-to-one relationships from the model and creates them. One-to-one relationships have a reference navigation property on both sides with a unique index introduced on the foreign key property to ensure only one dependent is related to each principal. EF core will choose one of the model to be the dependent based on its ability to detect a foreign key property, if the wrong entity is chosen as the dependent, you can use the Fluent API to correct this.

Consider the following entities:

```C#
public class Student
{
	public int StudentId { get; set; }
	public string FirstName{ get; set; }
	public string LastName{ get; set; }
	public int Age{ get; set; }

	public StudentImage StudentImage { get; set; }
}

public class StudentImage
{
    public int StudentImageId { get; set; }
    public byte[] Image { get; set; }
    public string Caption { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}

```

When configuring the relationship with the Fluent API, you use the `HasOne` and `WithOne` methods.

When configuring the foreign key you need to specify the dependent entity type - notice the generic parameter provided to `HasForeignKey` in the listing below. In one-to-many relationship, it is clear that the entity with the reference navigation is the dependent and the one with the collection is the principal. But this is not so in a one-to-one relationship - hence the need to explicitly define it.

```C#

class MyContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentImage> StudentImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(p => p.StudentImage)
            .WithOne(i => i.Student)
            .HasForeignKey<StudentImage>(b => b.StudentForeignKey);
    }
}

public class Student
{
    public int StudentId { get; set; }
    public string FirstName{ get; set; }
	public string LastName{ get; set; }
	public int Age{ get; set; }

    public StudentImage StudentImage { get; set; }
}

public class StudentImage
{
    public int StudentImageId { get; set; }
    public byte[] Image { get; set; }
    public string Caption { get; set; }

    public int StudentForeignKey { get; set; }
    public Student Student { get; set; }
}

```

### One-to-Many relationship

In a one-to-many relationship, each row in the primary table can be related to many rows in the relating table. This allows frequently used information to be saved only once in a table and referenced many times in all other tables. In a one-to-many relationship between Table A and Table B, each row in Table A is linked to 0,1 or many rows in Table B. The number of rows in Table A is almost always less than the number of rows in Table B. An example of this type of relationship in the school system is the grade/students relationship. One grade has many students in it while each student is registered in one grade at a time.

- **Dependent entity** - This is the entity that contains the foreign key property(s). Sometimes referred to as the child of the relationship.
- **Principal entity** - This is the entity that contains the primary/alternate key property(s). Sometimes referred to as the parent of the relationship.
- **Foreign key** - The property(s) in the dependent entity that is used to store the values of the principal key property that the entity is related to.
- **Principal key** - The property(s) that uniquely identifies the principal entity. This may be the primary key or an alternate key.
- **Navigation property** - A property defined on the principal and/or dependent entity that contains a reference(s) to the related entity(s).
  - a. _Collection navigation property_: A navigation property that contains references to many related entities.
  - b. _Reference navigation property_: A navigation property that holds a reference to a single related entity.
  - c. _Inverse navigation property_: When discussing a particular navigation property, this term refers to the navigation property on the other end of the relationship.

```C#
public class Grade
{
  public int GradeId { get; set; }
  public string Name { get; set; }

  public List<Student> Students { get; set; }
}

public class Student
{
  public int StudentId { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int Age { get; set; }

  public int GradeId { get; set; }
  public Grade Grade { get; set; }
}
```

1. `Student` is the dependent entity
2. `Grade` is the principal entity
3. `Student.GradeId` is the foreign key
4. `Grade.GradeId` is the principal key (in this case it is a primary key rather than an alternate key)
5. `Student.Grade` is a reference navigation property
6. `Grade.Students` is a collection navigation property.
7. `Student.Grade` is the inverse navigation property of `Grade.Students` and vice versa

#### How EF Core creates the relationship from the model

By convention, EF Core will automatically create a relationship when there is a navigation property discovered on a type. A property is considered a navigation property if the type it points to can not be mapped as a scalar type by the current database provider. This auto discovery and creation of relationships by EF is called Conventions. Relationships that are discovered by convention will always target the primary key of the principal entity. To target an alternate key, additional configuration must be performed using the Fluent API.

The most common pattern for relationships is to have navigation properties defined on both ends of the relationship and a foreign key property defined in the dependent entity class. In the above example Student.Grade and Grade.Students are navigation properties on both the Student and Grade entities. Student.GradeId is the foreign key defined in the dependent entity which is the Student entity. In a one-to-many relationship, the dependent entity is the one that is on the many side of the relationship.

If a pair of navigation properties is found between two types, then they will be configured as inverse navigation properties of the same relationship. If the dependent entity contains a property named `<primary key property name>`, `<navigation property name><primary key property name>`, or `<principal entity name><primary key property name>`, then it will be configured as the foreign key.

#### Using Data Annotations

There are two data annotations that can be used to configure relationships, `[ForeignKey]` and `[InverseProperty]`. You can use the [ForeignKey] data annotation to configure which property should be used as the foreign key property for a given relationship. This is typically done when the foreign key property is not discovered by convention. You can also use the `[InverseProperty]` data annotation to configure how navigation properties on the dependent and principal entities pair up. This is typically done when there is more than one pair of navigation properties between two entity types.

```C#
public class Grade
{
    public int GradeId { get; set; }
    public string Name { get; set; }

	[InverseProperty("Student")]
    public List<Student> Students { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    [ForeignKey("GradeForeignKey")]
    public int GradeId { get; set; }
    public Grade Grade { get; set; }
}
```

#### Using Fluent API

To configure a relationship in the Fluent API, you start by identifying the navigation properties that make up the relationship. `HasOne` or `HasMany` identifies the navigation property on the entity type you are beginning the configuration on. You then chain a call to `WithOne` or `WithMany` to identify the inverse navigation. `HasOne/WithOne` are used for reference navigation properties and `HasMany/WithMany` are used for collection navigation properties.

```C#
class MyContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(p => p.Grade)
            .WithMany(b => b.Students);
    }
}

public class Grade
{
    public int GradeId { get; set; }
    public string Name { get; set; }

    public List<Post> Students { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

	public Grade grade {get; set;}
}
```
