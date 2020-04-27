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
