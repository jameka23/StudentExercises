using System;
using System.Collections.Generic;

namespace StudentExercises
{
    public class Instructor{
        public Instructor(string first, string last, string slack, Cohort cohort, string specialty){
            FirstName = first;
            LastName = last;
            Slack = slack;
            InstructorCohort = cohort;
            Specialty = specialty;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Slack { get; set; }
        public Cohort InstructorCohort { get; set; }
        public string Specialty { get; set; }

        public void AssignEx(Student student, Exercise ex){
            student.StudentExerciseList.Add(ex);
            ex.Students.Add(student);
        }
    }
}