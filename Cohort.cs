using System;
using System.Collections.Generic;

namespace StudentExercises
{
    public class Cohort 
    {
        public Cohort (string name)
        { //, List<Student> studentsList, List<Instructor> instructorsList

            Name = name;
            // StudentsList = studentsList;
            // InstructorsList = instructorsList;
        }

        public int Id { get; set; }
        public string Name { get; }
        public List<Student> StudentsList { get; set; } = new List<Student>();
        public List<Instructor> InstructorsList { get; set; } = new List<Instructor>();
    }
}