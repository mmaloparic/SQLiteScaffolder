# SQLiteScaffolder

### What is SQLiteScaffolder?
It is a C# library that allows users to apply code-first approach when using SQLite.
SQLiteScaffolder does the heavy lifting when it comes to database and table creation, as well as packing and upacking objects for you.

Your job as a developer would only be to define the classes that will represent the database tables, create a class that represents the actual database and proceed with implementing your own data repositories and their respective logic.

Library comes with a small example project that implements a small database and shows how to use the SQLiteScaffolder.

### Basic usage
0. Add a reference to ```SQLiteScaffolder DLL``` in your project
1. Define the classes that will represent the entities inside your database
  * They must inherit from ```SQLiteEntity``` class
2. Decorate the classes and their properties with SQLiteScaffolder attributes
  * Use ```SQLiteTableInfo``` for decorating your classes that represent the tables
  * Use ```SQliteColumnInfo``` for decorating your properties that represent the table columns
3. Create the database class and define the tables
  * Your database class must inherit from ```SQLiteDatabase```
  * Your database class must implement a ```(string databaseName)``` constructor and call the ```base(databaseName)``` constructor in order for the SQLiteDatabase to properly initialize itself
  * You must initialize your table properties and pass in the reference to your database using ```this``` (more details in the example bellow)
4. Spawn your database file by calling ```CreateNewFile()``` on your database class
5. **Done!** You can start writing your repositories or business logic!
  * You can now use ```Insert(T)```, ```Update(T)```, ```Delete(T)```, ```InsertRange(T)```, ```UpdateRange(T)```, ```DeleteRange(T)``` where ```T``` represents entity classes defined by you. These methods are located on the ```SQLiteTable``` properties in your database class
  * You can skip all of this automation and simply use the ```SendQueryNoResponse()``` on your database class when you want to send a SQL query directly to database when not expecting a response or use the ```SendQueryGetResponse()``` method when you want to send a query and expect some response from the database.

#### Sample code:
###### Lecture table
```C#
    [SQLiteTableInfo("Lecture")]
    public class Lecture : SQLiteEntity
    {
        [SQLiteColumnInfo("ID", DataType.Text, Unique.Yes, PrimaryKey.Yes)]
        public Guid ID { get; set; }

        [SQLiteColumnInfo("Name", DataType.Text)]
        public string Name { get; set; }

        [SQLiteColumnInfo("Description", DataType.Text)]
        public string Description { get; set; }

        [SQLiteColumnInfo("Image", DataType.Blob)]
        public byte[] ImageBytes { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
```

###### Student table
```C#
    [SQLiteTableInfo("Student")]
    public class Student : SQLiteEntity
    {
        [SQLiteColumnInfo("ID", DataType.Text, Unique.Yes, PrimaryKey.Yes)]
        public Guid ID { get; set; }

        [SQLiteColumnInfo("Name", DataType.Text)]
        public string Name { get; set; }

        [SQLiteColumnInfo("Lastname", DataType.Text)]
        public string Lastname { get; set; }

        [SQLiteColumnInfo("Birthday", DataType.DateTime)]
        public DateTime Birthday { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Lastname);
        }
    }
```

###### Student-to-Lecture table
```C#
    [SQLiteTableInfo("StudentLecture")]
    public class StudentLecture : SQLiteEntity
    {
        [SQLiteColumnInfo("StudentId", DataType.Text)]
        public Guid StudentId { get; set; }

        [SQLiteColumnInfo("LectureId", DataType.Text, Unique.No, PrimaryKey.Yes)]
        public Guid LectureId { get; set; }
    }
```

###### Creating a database class
```C#
    public class UniversityDatabase : SQLiteDatabase
    {
        public UniversityDatabase(string databaseName) : base(databaseName)
        {
            Lectures = new SQLiteTable<Lecture>(this);
            Students = new SQLiteTable<Student>(this);
            StudentLecture = new SQLiteTable<StudentLecture>(this);        
        }
        
        public SQLiteTable<Lecture> Lectures { get; set; }

        public SQLiteTable<Student> Students { get; set; }

        public SQLiteTable<StudentLecture> StudentLecture { get; set; }
        
    }
```

###### How to insert an object in the database?
```C#
        //Inserts a new lecture
        public void Insert(string name, string description, byte[] imageBytes)
        {
            UniversityDatabase myUniversityDatabase = new UniversityDatabase("MyDatabase");
            Lecture l = new Lecture();
            l.ID = Guid.NewGuid();
            l.Name = name;
            l.Description = description;
            l.ImageBytes = imageBytes;

            myUniversityDatabase.Lectures.Insert(l);
        }
```

###### How to delete an object from the database?
```C#
        //Deletes a lecture
        public void Delete(Lecture lecture)
        {
            UniversityDatabase myUniversityDatabase = new UniversityDatabase("MyDatabase");
            myUniversityDatabase.Lectures.Delete(lecture);
        }
```

###### How to update an object in the database with new values?
```c#
        //Updates a lecture with new values
        public void Update(Lecture lecture, string newName, string newDescription, byte[] newImageBytes)
        {
            UniversityDatabase myUniversityDatabase = new UniversityDatabase("MyDatabase");
            lecture.Name = newName;
            lecture.Description = newDescription;
            lecture.ImageBytes = newImageBytes;
            myUniversityDatabase.Lectures.Update(lecture);
        }
```

###### How to select objects from the database?
```C#
        //Gets all lectures attached to a student
        public List<Lecture> GetLectures(Student student)
        {
            string whereCondition = string.Format("INNER JOIN StudentLecture ON Lecture.Id = StudentLecture.LectureId WHERE StudentLecture.StudentId = '{0}'", student.ID);
            List<Lecture> lectures = Database.Lectures.SelectAll(whereCondition).ToList();
            return lectures;
        }
```

#### Custom queries
###### How to send a query that does **not** generate a response?
```C#
        //Deletes all lectures
        public void DeleteAllLectures()
        {
            UniversityDatabase myUniversityDatabase = new UniversityDatabase("MyDatabase");
            SQLiteCommand myCommand = new SQLiteCommand("DELETE FROM Lecture");
            myUniversityDatabase.SendQueryNoResponse(myCommand);
        }
```

###### Send a query that **does** return a response?
```C#
        //Selects all lectures
        public List<Lecture> SelectAllLectures()
        {
            UniversityDatabase myUniversityDatabase = new UniversityDatabase("MyDatabase");
            SQLiteCommand myCommand = new SQLiteCommand("SELECT * FROM Lecture");
            SQLiteDataReader dataReader = myUniversityDatabase.SendQueryGetResponse(myCommand);

            //data extraction from SQLiteDataReader logic
            while (dataReader.Read())
            {
             . . .
            }
        }
```
