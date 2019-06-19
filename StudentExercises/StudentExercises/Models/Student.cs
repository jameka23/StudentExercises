using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Slack { get; set; }
        public int CohortId { get; set; }
    }
}
