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
