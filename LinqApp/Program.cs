// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
#region Review of Last Lecture
//string[] courses = { "Math", "Turkish", "Science", "Physical Education", "History", "Music" };

// Query Syntax
//var courseList = from course in courses
//                 select course;

//string[] courses = { "Math", "Turkish", "Science", "Physical Education", "History", "Music" };

//var courseList = from course in courses
//             where course.Contains("a")
//             select course;

//string[] courses = { "Math", "Turkish", "Science", "Physical Education", "History", "Music" };

//var courseList = from course in courses
//                 orderby course descending
//                 select course;

//string[] courses = { "Math", "Turkish", "Science", "Physical Education", "History", "Music" };

//var courseList = courses.Take(3);

//Console.WriteLine(string.Join(", ", courseList));

//string[] courses = { "Math", "Turkish", "Science", "Physical Education", "History", "Music" };

//var courseList = courses.TakeLast(3);

//Console.WriteLine(string.Join(", ", courseList));
#endregion

using LinqApp;

List<Personnel> personnelList = new List<Personnel>()
{
    new Personnel{ID = 1, FirstName = "Jax", LastName = "Teller", Salary = 25000},
    new Personnel{ID = 2, FirstName = "Tony", LastName = "Montana", Salary = 45000},
    new Personnel{ID = 3, FirstName = "Tony", LastName = "Soprano", Salary = 50000},
    new Personnel{ID = 4, FirstName = "Tommy", LastName = "Shelby", Salary = 15000},
    new Personnel{ID = 5, FirstName = "Michael", LastName = "Scofield", Salary = 10000},
};

// All personnels
//var personnels = from personnel in personnelList
//                 select personnel;

// Query Syntaxt
// Personnels with higher salary from 40000
//var personnels = from personnel in personnelList
//                 where personnel.Salary > 40000
//                 select personnel;

// Method Syntaxt
//var personnels = personnelList.Where(p => p.Salary > 40000).OrderByDescending(p => p.Salary);

// Personnels that their first name or last name contains "a"
// Q.S.
//var personnels = from personnel in personnelList
//                 where personnel.FirstName.Contains("a") || personnel.LastName.Contains("a")
//                 orderby personnel.Salary descending
//                 select personnel;

// M.S.
//var personnels = personnelList.Where(p => p.FirstName.Contains("a") || p.LastName.Contains("a")).OrderByDescending(p => p.Salary);

//foreach (var personnel in personnels)
//{
//    Console.WriteLine($"Personnel ID: {personnel.ID}");
//    Console.WriteLine($"Personnel Name: {personnel.FirstName} {personnel.LastName}");
//    Console.WriteLine($"Salary: {personnel.Salary}");
//    Console.WriteLine();
//    Console.WriteLine(new string('-', 88));
//    Console.WriteLine();
//}

IList<Student> studentList = new List<Student>()
{
    new Student {StudentId = 1, Name = "John Dani", Age = 18},
    new Student {StudentId = 2, Name = "Alex Kelly", Age = 22},
    new Student {StudentId = 3, Name = "Marry Johnson", Age = 21},
    new Student {StudentId = 4, Name = "Larry Long", Age = 18},
    new Student {StudentId = 5, Name = "Barry Davidfson", Age = 19},
};

// All students
// QS
//var students = from student in studentList
//               select student;
//foreach (var student in students)
//{
//    Console.WriteLine($"Student ID: {student.StudentId} - Student Name: {student.Name} - Student Age: {student.Age}");
//}

// MS
//var students = studentList.ToList();
//foreach (var student in students)
//{
//    Console.WriteLine($"Student ID: {student.StudentId} - Student Name: {student.Name} - Student Age: {student.Age}");
//}

// Specific properties
// QS
//var students = from student in studentList
//               select new
//               {
//                   student.StudentId,
//                   student.Name,
//               };
//foreach (var student in students)
//{
//    Console.WriteLine($"Student ID: {student.StudentId} - Student Name: {student.Name}");
//}

// MS
//var students = studentList.Select(st => new { st.StudentId, st.Name });

//foreach (var student in students)
//{
//    Console.WriteLine($"Student ID: {student.StudentId} - Student Name: {student.Name}");
//}