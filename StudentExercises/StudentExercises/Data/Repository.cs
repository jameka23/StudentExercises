using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using StudentExercises.Models;

namespace StudentExercises.Data
{
    public class Repository
    {
        public SqlConnection Connection
        {
            get
            {
                // S T E P 1. 
                // establish connection w/sql database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }


        // Student.cs Data
        public List<Student> GetAllStudents()
        {

            // S T E P 2.
            using(SqlConnection conn = Connection) // open the connection
            {
                conn.Open();

                // S T E P 3.
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    // run the query 
                    cmd.CommandText = @"SELECT Id,
                                                FirstName,
                                                LastName,
                                                Slack,
                                                CohortId
                                        FROM Student;";
                    SqlDataReader reader = cmd.ExecuteReader();

                    //create a collection to hold all the information
                    // S T E P 4.
                    List<Student> students = new List<Student>();
                    while (reader.Read())
                    {
                        // map throught appropriate models and take results
                        // ID
                        int idColPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColPosition);

                        // FIRSTNAME
                        int firstNameColPosition = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(firstNameColPosition);

                        // LASTNAME
                        int lastNameColPosition = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(lastNameColPosition);

                        // SLACK
                        int slackColPosition = reader.GetOrdinal("Slack");
                        string slackValue = reader.GetString(slackColPosition);

                        // COHORTID
                        int cohortColPosition = reader.GetOrdinal("CohortId");
                        int cohortIdValue = reader.GetInt32(cohortColPosition);


                        // create a student object with the values
                        Student student = new Student
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            Slack = slackValue,
                            CohortId = cohortIdValue
                        };

                        // and then add to the list of students that was created above
                        students.Add(student);
                    }

                    // S T E P 5.
                    reader.Close(); // close the connection 

                    // return the list of students 
                    return students;
                } // end of SqlCommand
            } // end of SqlConnection
        } // end of GetAllStudents()

        // Instructor.cs Data
        public List<Instructor> GetAllInstructors()
        {
            // S T E P  2 open connection
            using(SqlConnection conn = Connection)
            {
                // open the connection 
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    // S T E P  3 Run the query
                    cmd.CommandText = @"SELECT Id,
                                            FirstName,
                                            LastName,
                                            Slack,
                                            CohortId,
                                            Specialty
                                        FROM Instructor;";

                    // create a list that will hold the instructors 
                    List<Instructor> instructors = new List<Instructor>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // S T E P  4 take results from query and map them to appropriate model: instructor
                        // ID
                        int idColPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColPosition);

                        // FIRSTNAME
                        int firstNameColPosition = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(firstNameColPosition);

                        // LASTNAME
                        int lastNameColPosition = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(lastNameColPosition);

                        // SLACK
                        int slackColPosition = reader.GetOrdinal("Slack");
                        string slackValue = reader.GetString(slackColPosition);

                        // COHORTID
                        int cohortColPosition = reader.GetOrdinal("CohortId");
                        int cohortIdValue = reader.GetInt32(cohortColPosition);

                        // SPECIALTY
                        int specialtyColPosition = reader.GetOrdinal("Specialty");
                        string specialtyValue = reader.GetString(specialtyColPosition);

                        // create instructor object 
                        Instructor instuctor = new Instructor
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            Slack = slackValue,
                            CohortId = cohortIdValue,
                            Specialty = specialtyValue
                        };

                        // add the instructor to the list of instructors 
                        instructors.Add(instuctor);

                    }
                    // S T E P  5 close the connection 
                    reader.Close();
                    return instructors;
                } // end of sqlCommand
            } // end of sqlConnection
        } // end of GetAllInstructors

        // Cohort.cs Data
        public List<Cohort> GetAllCohorts()
        {
            // STEP 2
            // open the connection 
            using(SqlConnection conn = Connection)
            {
                conn.Open(); 

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    // STEP 3 run the query
                    cmd.CommandText = @"SELECT Id,
                                            CohortName
                                        FROM Cohort;";

                    SqlDataReader reader = cmd.ExecuteReader();

                    // create a list of Cohorts 
                    List<Cohort> cohorts = new List<Cohort>();

                    while (reader.Read())
                    {
                        // STEP 4 take the results from the query and map to correct model
                        
                        // ID
                        int cohortIdColPosition = reader.GetOrdinal("Id");
                        int cohortIdValue = reader.GetInt32(cohortIdColPosition);

                        // CohortName
                        int cohortNameColPosition = reader.GetOrdinal("CohortName");
                        string cohortNameValue = reader.GetString(cohortIdColPosition);

                        // create a cohort object
                        Cohort cohort = new Cohort
                        {
                            Id = cohortIdValue,
                            CohortName = cohortNameValue
                        };

                        // add to the list of cohorts
                        cohorts.Add(cohort);
                    }
                    // STEP 5 close the connection 
                    reader.Close();
                    return cohorts;
                }
            }
        }

        // Exercise.cs Data
        public List<Exercise> GetAllExercises()
        {
            // STEP 2 
            using(SqlConnection conn = Connection)
            {
                // open the connection 
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    // STEP 3 run the query
                    cmd.CommandText = @"SELECT Id,
                                            ExerciseName,
                                            ExerciseLanguage
                                       FROM Exercise;";

                    SqlDataReader reader = cmd.ExecuteReader();

                    // creat a list of exercises
                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        // STEP 4 take the results from query and map

                        // ID
                        int exerciseIdColPosition = reader.GetOrdinal("Id");
                        int exerciseValue = reader.GetInt32(exerciseIdColPosition);

                        // Exercise Name
                        int exerciseNameColPosition = reader.GetOrdinal("ExerciseName");
                        string exerciseNameValue = reader.GetString(exerciseNameColPosition);

                        // Langauage
                        int languageColPosition = reader.GetOrdinal("ExerciseLanguage");
                        string languageValue = reader.GetString(languageColPosition);

                        // create exercise object
                        Exercise exercise = new Exercise
                        {
                            Id = exerciseValue,
                            ExerciseName = exerciseNameValue,
                            ExerciseLanguage = languageValue
                        };

                        // add to the list of exercises
                        exercises.Add(exercise);
                    }

                    // STEP 5 close the connection 
                    reader.Close();
                    return exercises;
                }// end sqlCommand
            } // end sqlConnection
        }// end GetAllExercises
        
        // StudentExercise.cs Data
        public List<StudentExercise> GetAllStudentExercises()
        {
            // STEP 2 open the connection 
            using(SqlConnection conn = Connection)
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    // STEP 3 run the query
                    cmd.CommandText = @"SELECT Id,
                                            ExerciseId,
                                            StudentId
                                        FROM StudentExercise;";

                    SqlDataReader reader = cmd.ExecuteReader();

                    // create a collection to hold the studentexercises
                    List<StudentExercise> studentExercises = new List<StudentExercise>();
                    while (reader.Read())
                    {
                        // STEP 4 take the results and map them

                        // Id
                        int stExIdColPosition = reader.GetOrdinal("Id");
                        int stExIdValue = reader.GetInt32(stExIdColPosition);

                        // ExerciseId
                        int exIdColPosition = reader.GetOrdinal("ExerciseId");
                        int exIdValue = reader.GetInt32(exIdColPosition);

                        // StudentId
                        int stuIdColPosition = reader.GetOrdinal("StudentId");
                        int stuIdValue = reader.GetInt32(stuIdColPosition);


                        // create an object and instert in the list
                        StudentExercise studentExercise = new StudentExercise
                        {
                            Id = stExIdValue,
                            StudentId = stuIdValue,
                            ExerciseId = exIdValue
                        };

                        studentExercises.Add(studentExercise);
                    }
                    // STEP 5
                    // close the connection 
                    reader.Close();
                    return studentExercises;
                } // end sql command
            } // end of sql connection 
        }
    }
}
