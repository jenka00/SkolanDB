using SkolanDB.Models;
using System;
using System.Linq;

namespace SkolaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            do
            {
                using SchoolDbContext Context = new SchoolDbContext();

                Console.WriteLine("Välkommen till Gymnasieskolan.");
                Console.WriteLine("Välj vad du vill göra." +
                                    "\n1. Se skolans personal" +
                                    "\n2. Se skolans elever" +
                                    "\n3. Se aktiva kurser" +
                                    "\n4. Se betyg" +
                                    "\n5. Lägga till nya elever" +
                                    "\n6. Lägga till ny personal" +
                                    "\n7. Avsluta");

                string menuChoice = Console.ReadLine();

                Console.Clear();

                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("Vilken personal vill du se?");
                        Console.WriteLine("1. All personal" +
                                          "\n2. Rektorer " +
                                          "\n3. Lärare " +
                                          "\n4. Administrativ personal");
                        string staffChoice = Console.ReadLine();
                        Console.Clear();
                        switch (staffChoice)
                        {
                            case "1":
                                var allStaff = from VWshowAllStaff in Context.VWshowAllStaff
                                               select VWshowAllStaff;

                                Console.WriteLine("Skolans personal:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var staff in allStaff)
                                {
                                    Console.WriteLine($"Namn: {staff.Fname} {staff.Lname} Yrke: {staff.RoleName}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "2":
                                var allHM = from VWshowAllHeadMasters in Context.VWshowAllHeadMasters
                                            select VWshowAllHeadMasters;

                                Console.WriteLine("Skolans Rektorer:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var headMasters in allHM)
                                {
                                    Console.WriteLine($"Namn: {headMasters.Fname} {headMasters.Lname}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "3":
                                var allTeachers = (from VWshowAllTeachers in Context.VWshowAllTeachers
                                                  select VWshowAllTeachers).Distinct();

                                var teachersInDep1 = Context.EmployeeDepartment.Count(p => p.FkdepartmentId == 1).ToString();
                                var teachersInDep2 = Context.EmployeeDepartment.Count(p => p.FkdepartmentId == 2).ToString();
                                var teachersInDep3 = Context.EmployeeDepartment.Count(p => p.FkdepartmentId == 3).ToString();
                                                                                                                 
                                Console.WriteLine("Skolans Lärare:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var teachers in allTeachers)
                                {
                                    Console.WriteLine($"Namn: {teachers.Fname} {teachers.Lname}");
                                    Console.WriteLine(new string('-', (20)));
                                }

                                Console.WriteLine($"Antal lärare i Naturvetenskaplig avdelning: {teachersInDep1}");
                                Console.WriteLine(new string('-', (20)));
                                Console.WriteLine($"Antal lärare i Samhällsvetenskaplig avdelning: {teachersInDep2}");
                                Console.WriteLine(new string('-', (20)));
                                Console.WriteLine($"Antal lärare i Språklig avdelning: {teachersInDep3}");                              
                                break;
                            case "4":
                                var allAdmin = from VWshowAllAdmin in Context.VWshowAllAdmin
                                               select VWshowAllAdmin;

                                Console.WriteLine("Skolans Administrativa Personal:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var admin in allAdmin)
                                {
                                    Console.WriteLine($"Namn: {admin.Fname} {admin.Lname}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("Visa elever" +
                                          "\n1. Alla elever" +
                                          "\n2. Klass 1A" +
                                          "\n3. Klass 1B" +
                                          "\n4. Klass 2A" +
                                          "\n5. Klass 2B" +
                                          "\n6. Klass 3A" +
                                          "\n7. Klass 3B" +
                                          "\n8. Sök elev genom elevnummer");
                        string studentChoice = Console.ReadLine();
                        Console.Clear();
                        switch (studentChoice)
                        {
                            case "1":
                                Console.WriteLine("Välj hur listan ska sorteras" +
                                "\n1. I bokstavsordning efter förnamn - stigande sortering" +
                                "\n2. I bokstavsordning efter förnamn - fallande sortering" +
                                "\n3. I bokstavsordning efter efternamn - stigande sortering" +
                                "\n4. I bokstavsordning efter efternamn - fallande sortering");

                                string sortingOrder = Console.ReadLine();
                                if (sortingOrder == "1")
                                {
                                    var allStudents = from Student in Context.Student
                                                      orderby Student.Fname
                                                      select Student;

                                    Console.WriteLine("Alla elever på skolan:");
                                    Console.WriteLine(new string('-', (20)));
                                    foreach (var student in allStudents)
                                    {
                                        Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                        Console.WriteLine(new string('-', (20)));
                                    }
                                }
                                else if (sortingOrder == "2")
                                {
                                    var allStudents = from Student in Context.Student
                                                      orderby Student.Lname descending
                                                      select Student;

                                    Console.WriteLine("Alla elever på skolan:");
                                    Console.WriteLine(new string('-', (20)));
                                    foreach (var student in allStudents)
                                    {
                                        Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                        Console.WriteLine(new string('-', (20)));
                                    }
                                }
                                else if (sortingOrder == "3")
                                {
                                    var allStudents = from Student in Context.Student
                                                      orderby Student.Lname
                                                      select Student;

                                    Console.WriteLine("Alla elever på skolan:");
                                    Console.WriteLine(new string('-', (20)));
                                    foreach (var student in allStudents)
                                    {
                                        Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                        Console.WriteLine(new string('-', (20)));
                                    }
                                }
                                else if (sortingOrder == "4")
                                {
                                    var allStudents = from Student in Context.Student
                                                      orderby Student.Lname descending
                                                      select Student;

                                    Console.WriteLine("Alla elever på skolan:");
                                    Console.WriteLine(new string('-', (20)));
                                    foreach (var student in allStudents)
                                    {
                                        Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                        Console.WriteLine(new string('-', (20)));
                                    }
                                }
                                break;

                            case "2":
                                var Class1A = from Student in Context.Student
                                              where Student.FkclassId == 1
                                              orderby Student.Lname
                                              select Student;

                                Console.WriteLine("Klass 1A:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var student in Class1A)
                                {
                                    Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "3":
                                var Class1B = from Student in Context.Student
                                              where Student.FkclassId == 2
                                              orderby Student.Lname
                                              select Student;

                                Console.WriteLine("Klass 1B:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var student in Class1B)
                                {
                                    Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "4":
                                var Class2A = from Student in Context.Student
                                              where Student.FkclassId == 3
                                              orderby Student.Lname
                                              select Student;

                                Console.WriteLine("Klass 2A:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var student in Class2A)
                                {
                                    Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "5":
                                var Class2B = from Student in Context.Student
                                              where Student.FkclassId == 4
                                              orderby Student.Lname
                                              select Student;

                                Console.WriteLine("Klass 2B:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var student in Class2B)
                                {
                                    Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "6":
                                var Class3A = from Student in Context.Student
                                              where Student.FkclassId == 5
                                              orderby Student.Lname
                                              select Student;

                                Console.WriteLine("Klass 3A:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var student in Class3A)
                                {
                                    Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "7":
                                var Class3B = from Student in Context.Student
                                              where Student.FkclassId == 6
                                              orderby Student.Lname
                                              select Student;

                                Console.WriteLine("Klass 3B:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var student in Class3B)
                                {
                                    Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;

                            case "8":

                                Console.WriteLine("Ange elevnummer");
                                int studentNr = Convert.ToInt32(Console.ReadLine());
                              
                                var getStudentName = from Student in Context.Student
                                                     join Class in Context.Class on Student.FkclassId equals Class.ClassId
                                                     where Student.StudentId == studentNr
                                                     select new
                                                     {
                                                         StudentFName = Student.Fname,
                                                         StudentLName = Student.Lname,
                                                         ClassName = Class.ClassName
                                                     };

                                var chosenStudent = from Student in Context.Student
                                                    join StudentCourse in Context.StudentCourse on Student.StudentId equals StudentCourse.FkstudentId
                                                    join Course in Context.Course on StudentCourse.FkcourseId equals Course.CourseId
                                                    where Student.StudentId == studentNr
                                                    select new
                                                    {
                                                        Course = Course.CourseName,
                                                        Grade = StudentCourse.Grade,
                                                        StartDate = StudentCourse.StartDate,
                                                        EndDate = StudentCourse.EndDate
                                                    };
                                
                                Console.WriteLine("\n1. Visa information om vald elev" +
                                                "\n2. Ändra uppgifter hos vald elev" +
                                                "\n3. Ta bort elev");

                                string userChoice = Console.ReadLine();

                                if (userChoice == "1")
                                {
                                    foreach (var studentName in getStudentName)
                                    {
                                        Console.WriteLine($"Namn: {studentName.StudentFName} {studentName.StudentLName} \nKlass: {studentName.ClassName}");
                                    }
                                    foreach (var studentAndClass in chosenStudent)
                                    {
                                        if (DateTime.Today > studentAndClass.StartDate && DateTime.Today < studentAndClass.EndDate)
                                        {
                                            Console.WriteLine($"Status: Pågående \t\tKurs: {studentAndClass.Course}");
                                        }
                                        else if (DateTime.Today > studentAndClass.EndDate)
                                        {
                                            Console.WriteLine($"Status: Avslutad \tKurs: {studentAndClass.Course} \t\tBetyg: {studentAndClass.Grade}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Status: Kommande \t\tKurs: {studentAndClass.Course}");
                                            break;
                                        }
                                    }
                                    break;
                                }
                                else if (userChoice == "2")
                                {
                                    Console.WriteLine("\n1: Ändra förnamn" +
                                                      "\n2: Ändra efternamn");

                                    string uChoice = Console.ReadLine();

                                    if (uChoice == "1")
                                    {
                                        Console.WriteLine("Ange nytt förnamn");
                                        string newFName = Console.ReadLine();

                                        var thisStud = Context.Student.Where(c => c.StudentId == studentNr).FirstOrDefault();

                                        if (thisStud is Student)
                                        {
                                            thisStud.Fname = newFName;
                                            Context.SaveChanges();
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (uChoice == "2")
                                    {
                                        Console.WriteLine("Ange nytt efternamn");
                                        string newLName = Console.ReadLine();

                                        var thisStud = Context.Student.Where(c => c.StudentId == studentNr).FirstOrDefault();

                                        if (thisStud is Student)
                                        {
                                            thisStud.Lname = newLName;
                                            Context.SaveChanges();
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Felaktigt val");
                                        break;
                                    }
                                }
                                else if (userChoice == "3")
                                {
                                    var thisStud = Context.Student.Where(c => c.StudentId == studentNr).FirstOrDefault();

                                    if (thisStud is Student)
                                    {
                                        Context.Remove(thisStud);
                                        Context.SaveChanges();
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                
                                else
                                {
                                    break;
                                }                        
                        }
                        break;
                    
                    case "3":
                        Console.WriteLine("Aktiva kurser: ");
                        //Using view VWshowActiveCourses
                        //Console.WriteLine(new string('-', (20)));

                        //var activeCourse = from VWshowActiveCourses in Context.VWshowActiveCourses
                        //                   select VWshowActiveCourses;

                        //foreach (var course in activeCourse)
                        //{
                        //    Console.WriteLine($"{course.ActiveCourses}");
                        //    Console.WriteLine(new string('-', (20)));
                        //}
                    
                        var activeCourses = (from StudentCourse in Context.StudentCourse
                                            join Course in Context.Course on StudentCourse.FkcourseId equals Course.CourseId
                                            where DateTime.Today > StudentCourse.StartDate && DateTime.Today < StudentCourse.EndDate                                        
                                            select new
                                            {
                                                CourseName = Course.CourseName,
                                                StartDate = StudentCourse.StartDate,
                                                EndDate = StudentCourse.EndDate,
                                                CourseID = Course.CourseId
                                            }).Distinct();

                        foreach (var course in activeCourses)
                        {
                            Console.WriteLine($"Kursnamn: {course.CourseName} \nStartdatum: {course.StartDate.ToString("d")}  \nSlutdatum: {course.EndDate.ToString("d")}");
                            Console.WriteLine(new string('-', (20)));
                        }
                        break;

                    case "4":
                        Console.WriteLine("Visa betyg" +
                                    "\n1. Senaste månadens betyg" +
                                    "\n2. Betyg i Biologi 1" +
                                    "\n3. Betyg i Kemi 1" +
                                    "\n4. Betyg i Engelska 1" +
                                    "\n5. Betyg i Engelska 2" +
                                    "\n6. Betyg i Engelska 3" +
                                    "\n7. Betyg i Historia 1" +
                                    "\n8. Betyg i Historia 2" +
                                    "\n9. Betyg i Matematik 1");

                        string gradeChoice = Console.ReadLine();

                        switch (gradeChoice)
                        {
                            case "1":
                                Console.Clear();

                                var lastMonthsGrades = from VWgradesOneMonth in Context.VWgradesOneMonth
                                                       select VWgradesOneMonth;
                                Console.WriteLine("Betyg som satts senaste månaden:");
                                foreach (var grade in lastMonthsGrades)
                                {
                                    Console.WriteLine($"Namn: {grade.Fname} {grade.Lname}");
                                    Console.WriteLine($"Kurs: {grade.CourseName}");
                                    Console.WriteLine($"Betyg: {grade.Grade}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "2":

                                Console.Clear();

                                var BiologyGrades = from VWgradesBiology1 in Context.VWgradesBiology1
                                                    select VWgradesBiology1;

                                Console.WriteLine("Biologi 1:");
                                foreach (var grade in BiologyGrades)
                                {
                                    Console.WriteLine($"Medelbetyg: {grade.AverageGrade}");
                                    Console.WriteLine($"Högsta betyg: {grade.HighestGrade}");
                                    Console.WriteLine($"Lägsta betyg: {grade.LowestGrade}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "3":

                                Console.Clear();
                                var Chemistry1Grades = from VWgradesChemistry1 in Context.VWgradesChemistry1
                                                       select VWgradesChemistry1;

                                Console.WriteLine("Kemi 1:");
                                foreach (var grade in Chemistry1Grades)
                                {
                                    Console.WriteLine($"Medelbetyg: {grade.AverageGrade}");
                                    Console.WriteLine($"Högsta betyg: {grade.HighestGrade}");
                                    Console.WriteLine($"Lägsta betyg: {grade.LowestGrade}");
                                    Console.WriteLine(new string('-', (20)));
                                }

                                break;
                            case "4":

                                Console.Clear();
                                var GradesEnglish1 = from VWgradesEnglish1 in Context.VWgradesEnglish1
                                                     select VWgradesEnglish1;

                                Console.WriteLine("Engelska 1:");
                                foreach (var grade in GradesEnglish1)
                                {
                                    Console.WriteLine($"Medelbetyg: {grade.AverageGrade}");
                                    Console.WriteLine($"Högsta betyg: {grade.HighestGrade}");
                                    Console.WriteLine($"Lägsta betyg: {grade.LowestGrade}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "5":

                                Console.Clear();
                                var GradesEnglish2 = from VWgradesEnglish2 in Context.VWgradesEnglish2
                                                     select VWgradesEnglish2;

                                Console.WriteLine("Engelska 2:");
                                foreach (var grade in GradesEnglish2)
                                {
                                    Console.WriteLine($"Medelbetyg: {grade.AverageGrade}");
                                    Console.WriteLine($"Högsta betyg: {grade.HighestGrade}");
                                    Console.WriteLine($"Lägsta betyg: {grade.LowestGrade}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;

                            case "6":
                                Console.Clear();
                                var GradesEnglish3 = from VWgradesEnglish3 in Context.VWgradesEnglish3
                                                     select VWgradesEnglish3;
                                Console.WriteLine("Engelska 3:");
                                foreach (var grade in GradesEnglish3)
                                {
                                    Console.WriteLine($"Medelbetyg: {grade.AverageGrade}");
                                    Console.WriteLine($"Högsta betyg: {grade.HighestGrade}");
                                    Console.WriteLine($"Lägsta betyg: {grade.LowestGrade}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "7":
                                Console.Clear();
                                var GradesHistory1 = from VWgradesHistory1 in Context.VWgradesHistory1
                                                     select VWgradesHistory1;
                                Console.WriteLine("Historia 1:");
                                foreach (var grade in GradesHistory1)
                                {
                                    Console.WriteLine($"Medelbetyg: {grade.AverageGrade}");
                                    Console.WriteLine($"Högsta betyg: {grade.HighestGrade}");
                                    Console.WriteLine($"Lägsta betyg: {grade.LowestGrade}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "8":
                                Console.Clear();
                                var GradesHistory2 = from VWgradesHistory2 in Context.VWgradesHistory2
                                                     select VWgradesHistory2;
                                Console.WriteLine("Historia 2:");
                                foreach (var grade in GradesHistory2)
                                {
                                    Console.WriteLine($"Medelbetyg: {grade.AverageGrade}");
                                    Console.WriteLine($"Högsta betyg: {grade.HighestGrade}");
                                    Console.WriteLine($"Lägsta betyg: {grade.LowestGrade}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                            case "9":
                                Console.Clear();
                                var Mathematics1 = from VWgradesMathematics1 in Context.VWgradesMathematics1
                                                   select VWgradesMathematics1;
                                Console.WriteLine("Matematik 1:");
                                foreach (var grade in Mathematics1)
                                {
                                    Console.WriteLine($"Medelbetyg: {grade.AverageGrade}");
                                    Console.WriteLine($"Högsta betyg: {grade.HighestGrade}");
                                    Console.WriteLine($"Lägsta betyg: {grade.LowestGrade}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                        }
                        break;
                    case "5":
                        Console.WriteLine("Lägg till ny elev.");
                        Console.WriteLine("Förnamn:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Efternamn:");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Personnummer: ");
                        string personalNr = Console.ReadLine();                        
                        Console.WriteLine("KlassID: ");
                        int schoolClass = Convert.ToInt32(Console.ReadLine());                       

                        Student newStudent = new Student
                        {
                            Fname = firstName,
                            Lname = lastName,
                            PersonalNumber = personalNr,
                            Role = "Student",                            
                            FkclassId = schoolClass 
                        };

                        Console.WriteLine($"Skapat ny student. Namn: {firstName} {lastName} " +
                               $"\nPersonnummer: {personalNr} " +
                               $"\nKlassID: {schoolClass}");

                        Context.Student.Add(newStudent);
                        Context.SaveChanges();
                        Console.Clear();

                        break;
                    case "6":
                        Console.WriteLine("Lägg till ny personal. \nDu kan välja mellan att lägga till:" +
                            "\n1. Rektor " +
                            "\n2. Lärare " +
                            "\n3. Administratör");
                        int role = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Förnamn:");
                        string firstNameInput = Console.ReadLine();
                        Console.WriteLine("Efternamn:");
                        string lastNameInput = Console.ReadLine();
                        Console.WriteLine("Anställningsdatum: ");
                        DateTime employmentDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Lön: ");
                        decimal salary = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Avdelning: ");
                        int department = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (role == 1)
                        {
                            Console.WriteLine($"Skapat ny rektor. Namn: {firstNameInput} {lastNameInput} " +
                                $"\nAnställningsdatum: {employmentDate} " +
                                $"\nLön: ");

                            Employee newEmployee = new Employee
                            {
                                Fname = firstNameInput,
                                Lname = lastNameInput,
                                FkroleId = role,
                                StartDate = employmentDate,
                            };

                            Context.Employee.Add(newEmployee);
                            Context.SaveChanges();
                        }
                        else if (role == 2)
                        {
                            Console.WriteLine($"Skapat ny lärare. Namn: {firstNameInput} {lastNameInput} " +
                                $"\nAnställningsdatum: {employmentDate} " +
                                $"\nLön: ");
                            Employee newEmployee = new Employee
                            {
                                Fname = firstNameInput,
                                Lname = lastNameInput,
                                FkroleId = role,
                                Salary = salary,
                                StartDate = employmentDate
                            };
                            Context.Employee.Add(newEmployee);
                            Context.SaveChanges();
                        }
                        else if (role == 3)
                        {
                            Console.WriteLine($"Skapat ny administratör.Namn: {firstNameInput} {lastNameInput} " +
                                $"\nAnställningsdatum: {employmentDate} " +
                                $"\nLön: ");
                            Employee newEmployee = new Employee
                            {
                                Fname = firstNameInput,
                                Lname = lastNameInput,
                                FkroleId = role,
                                Salary = salary,
                                StartDate = employmentDate
                            };
                            Context.Employee.Add(newEmployee);
                            Context.SaveChanges();
                        }
                        break;
                    case "7":
                        isRunning = false;
                        break;
                }
                Console.WriteLine("\nTryck på valfri tangent för att komma vidare.");
                Console.ReadKey();
                Console.Clear();
            }
            while (isRunning);
        }           
    }
}
