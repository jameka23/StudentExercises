using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using StudentExercises.Data;
using StudentExercises.Models;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            // we must make an instance of the repository class
            Repository repository = new Repository();

            // 1. Query the database for all the Exercises.
            List<Exercise> exercises = repository.GetAllExercises();
            Console.WriteLine("List of Exercises");
            exercises.ForEach(ex => Console.WriteLine($"Ex #{ex.Id}: {ex.ExerciseName}, Language: {ex.ExerciseLanguage}"));

            // 2. Find all the exercises in the database where the language is JavaScript.
            List<Exercise> javascript = exercises.Where(ex => ex.ExerciseLanguage == "JavaScript");

        }
    }
}
