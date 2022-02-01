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
                                    "\n3. Se betyg" +
                                    "\n4. Lägga till nya elever" +
                                    "\n5. Lägga till ny personal" +
                                    "\n6. Avsluta");

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
                                    Console.WriteLine($"Namn: {staff.Fname} {staff.Lname} Yrke: {staff.Role}");
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
                                var allTeachers = from VWshowAllTeachers in Context.VWshowAllTeachers
                                                  select VWshowAllTeachers;

                                Console.WriteLine("Skolans Lärare:");
                                Console.WriteLine(new string('-', (20)));
                                foreach (var teachers in allTeachers)
                                {
                                    Console.WriteLine($"Namn: {teachers.Fname} {teachers.Lname} \nÄmne: {teachers.CourseName}");
                                    Console.WriteLine(new string('-', (20)));
                                }
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
                                          "\n7. Klass 3B");
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
                                    foreach (var student in allStudents)
                                    {
                                        Console.WriteLine($"Namn: {student.Fname} {student.Fname} Personnummer: {student.PersonalNumber}");
                                        Console.WriteLine(new string('-', (20)));
                                    }
                                }
                                else if (sortingOrder == "2")
                                {
                                    var allStudents = from Student in Context.Student
                                                      orderby Student.Lname descending
                                                      select Student;

                                    Console.WriteLine("Alla elever på skolan:");
                                    foreach (var student in allStudents)
                                    {
                                        Console.WriteLine($"Namn: {student.Fname} {student.Fname} Personnummer: {student.PersonalNumber}");
                                        Console.WriteLine(new string('-', (20)));
                                    }
                                }
                                else if (sortingOrder == "3")
                                {
                                    var allStudents = from Student in Context.Student
                                                      orderby Student.Lname
                                                      select Student;

                                    Console.WriteLine("Alla elever på skolan:");
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
                                foreach (var student in Class3B)
                                {
                                    Console.WriteLine($"Namn: {student.Fname} {student.Lname} Personnummer: {student.PersonalNumber}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("Visa betyg" +
                                    "\n1. Senaste månadens betyg" +
                                    "\n2. Betyg i Biologi 1" +
                                    "\n3. Betyg i Kemi 1" +
                                    "\n4. Betyg i Engelska 1");

                        string gradeChoice = Console.ReadLine();

                        switch (gradeChoice)
                        {
                            case "1":

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
                                var GradesEnglish2 = from VWgradesEnglish2 in Context.VWgradesEnglish1
                                                     select VWgradesEnglish2;

                                Console.WriteLine("Engelska 1:");
                                foreach (var grade in GradesEnglish2)
                                {
                                    Console.WriteLine($"Medelbetyg: {grade.AverageGrade}");
                                    Console.WriteLine($"Högsta betyg: {grade.HighestGrade}");
                                    Console.WriteLine($"Lägsta betyg: {grade.LowestGrade}");
                                    Console.WriteLine(new string('-', (20)));
                                }
                                break;
                        }
                        break;
                    case "4":
                        break;
                    case "5":
                        Console.WriteLine("Lägg till ny personal. Lägg till ny rektor, lärare eller admin");
                        Console.WriteLine("Förnamn:");
                        string firstNameInput = Console.ReadLine();
                        Console.WriteLine("Efternamn:");
                        string lastNameInput = Console.ReadLine();
                        Console.WriteLine("Yrkesroll:");
                        string role = Console.ReadLine().ToUpper();
                        if (role == "REKTOR")
                        {
                            HeadMaster newHeadmaster = new HeadMaster { Fname = firstNameInput, Lname = lastNameInput, Role = "Headmaster" };
                            Context.HeadMaster.Add(newHeadmaster);
                            Context.SaveChanges();
                        }
                        else if (role == "LÄRARE")
                        {                           
                            Teacher newTeacher = new Teacher { Fname = firstNameInput, Lname = lastNameInput, Role = "Teacher" };
                            Context.Teacher.Add(newTeacher);
                            Context.SaveChanges();
                        }
                        else if (role == "ADMIN")
                        {
                            Admin newAdmin = new Admin { Fname = firstNameInput, Lname = lastNameInput, Role = "Admin" };
                            Context.Admin.Add(newAdmin);
                            Context.SaveChanges();
                        }
                        break;
                    case "6":
                        isRunning = false;
                        break;
                }

            }
            while (isRunning);
        }
           
    }
}
