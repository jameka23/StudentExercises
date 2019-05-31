using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                1. Create 4, or more, exercises.
                2. Create 3, or more, cohorts.
                3. Create 4, or more, students and assign them to one of the cohorts.
                4. Create 3, or more, instructors and assign them to one of the cohorts.
                5. Have each instructor assign 2 exercises to each of the students.
            */

            // 1. Create 4, or more, exercises.
            Exercise ex1 = new Exercise("daily journal", "javascript");
            Exercise ex2 = new Exercise("urban planner", "c#");
            Exercise ex3 = new Exercise("kennel", "reactjs");
            Exercise ex4 = new Exercise("kandy korner", "reactjs");

            // 2. Create 3, or more, cohorts.            
            Cohort c30 = new Cohort("c30");
            Cohort c31 = new Cohort("c31");
            Cohort c32 = new Cohort("c32");
            Cohort c33 = new Cohort("c33");

            // set the student list to be added here 

            //3. Create 4, or more, students and assign them to one of the cohorts.
            Student Rose = new Student("Rose", "Witzosky", "Rose", c30);
            Student Jonathon = new Student("Jonathon", "Schaffer", "Jon", c30);
            Student Alex = new Student("Alex", "Thacker", "Alex", c31);
            Student Billy = new Student("Billy", "Mathison", "Billy", c31);
            Student Meag = new Student("Meag", "Mueller", "Meag", c32);
            Student Stephen = new Student("Stephen", "Senft", "Stephen", c32);
            Student Chris = new Student("Chris", "Morgan", "Chris", c33);
            Student Sam = new Student("Sam", "Britt", "Sam", c33);

            c30.StudentsList.Add(Rose);
            c30.StudentsList.Add(Jonathon);
            c31.StudentsList.Add(Alex);
            c31.StudentsList.Add(Billy);
            c32.StudentsList.Add(Meag);
            c32.StudentsList.Add(Stephen);
            c33.StudentsList.Add(Chris);
            c33.StudentsList.Add(Sam);

            //4. Create 3, or more, instructors and assign them to one of the cohorts.

            Instructor Jisie = new Instructor("Jisie", "Davis", "Jisie", c30, "dancing");
            Instructor Kristen = new Instructor("Kristen", "Norris", "Kristen", c31, "baking");
            Instructor Andy = new Instructor("Andy", "Collins", "Andy", c31, "dancing");
            Instructor Leah = new Instructor("Leah", "Gwin", "Leah", c30, "programming");
            Instructor Brenda = new Instructor("Brenda", "Long", "Brenda", c32, "designing");
            Instructor Bryan = new Instructor("Bryan", "Nilsen", "Bryan", c32, "basketball");
            Instructor Steve = new Instructor("Steve", "Brownlee", "Steve", c33, "talking");
            Instructor Maddie = new Instructor("Maddie", "Peper", "Madi", c33, "pre-work");

            c30.InstructorsList.Add(Jisie);
            c30.InstructorsList.Add(Leah);
            c31.InstructorsList.Add(Kristen);
            c31.InstructorsList.Add(Andy);
            c32.InstructorsList.Add(Brenda);
            c32.InstructorsList.Add(Bryan);
            c33.InstructorsList.Add(Steve);
            c33.InstructorsList.Add(Maddie);

            //Have each instructor assign 2 exercises to each of the students in their cohort
            // c30
            Jisie.AssignEx(Rose, ex1);
            Jisie.AssignEx(Rose, ex2);
            Jisie.AssignEx(Jonathon, ex3);
            Jisie.AssignEx(Jonathon, ex4);
            Leah.AssignEx(Rose, ex3);
            Leah.AssignEx(Rose, ex4);
            Leah.AssignEx(Jonathon, ex1);
            Leah.AssignEx(Jonathon, ex2);

            //31
            Kristen.AssignEx(Billy, ex3);
            Kristen.AssignEx(Billy, ex4);
            Kristen.AssignEx(Alex, ex3);
            Kristen.AssignEx(Alex, ex4);
            Andy.AssignEx(Alex, ex1);
            Andy.AssignEx(Alex, ex2);
            Andy.AssignEx(Billy, ex1);
            Andy.AssignEx(Billy, ex2);

            //32
            Bryan.AssignEx(Meag, ex1);
            Bryan.AssignEx(Meag, ex2);
            Bryan.AssignEx(Stephen, ex1);
            Bryan.AssignEx(Stephen, ex2);
            Brenda.AssignEx(Meag, ex3);
            Brenda.AssignEx(Meag, ex4);
            Brenda.AssignEx(Stephen, ex3);
            Brenda.AssignEx(Stephen, ex4);


            //33
            Maddie.AssignEx(Sam, ex1);
            Maddie.AssignEx(Sam, ex2);
            Maddie.AssignEx(Chris, ex1);
            Maddie.AssignEx(Chris, ex2);
            Steve.AssignEx(Chris, ex3);
            Steve.AssignEx(Chris, ex4);
            Steve.AssignEx(Sam, ex3);
            Steve.AssignEx(Sam, ex4);

            // C H A L L E N G E
            List<Student> students = new List<Student>
            {
                Rose, Jonathon, Meag, Stephen, Sam, Billy, Chris, Alex
            };

            List<Exercise> exercises = new List<Exercise>
            {
                ex1, ex2, ex3, ex4
            };

            //Generate a report that displays which students are working on which exercises.
            foreach (Student student in students)
            {
                Console.Write($"{student.FirstName} {student.LastName} is working on the following exercises: ");
                foreach (Exercise studentEx in student.StudentExerciseList)
                {
                    Console.Write($"{studentEx.Name}");
                }
                Console.WriteLine("");
            }
        }
    }
}
