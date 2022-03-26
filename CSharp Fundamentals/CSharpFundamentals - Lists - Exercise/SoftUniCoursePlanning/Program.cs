using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessonsSchedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] elements = input
                    .Split(':')
                    .ToArray();

                string command = elements[0];
                string lessonTitle = elements[1];

                switch (command)
                {
                    case "Add":
                        if (!lessonsSchedule.Contains(lessonTitle))
                        {
                            lessonsSchedule.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(elements[2]);

                        if (!lessonsSchedule.Contains(lessonTitle))
                        {
                            lessonsSchedule.Insert(index, lessonTitle);
                        }
                        break;
                    case "Remove":
                        if (lessonsSchedule.Contains(lessonTitle))
                        {
                            lessonsSchedule.Remove(lessonTitle);
                        }
                        else if (lessonsSchedule.Contains(lessonTitle + "-Exercise"))
                        {
                            lessonsSchedule.Remove(lessonTitle + "-Exercise");
                        }  
                        break;
                    case "Swap":
                        string secondLessonTitle = elements[2];

                        int indexOfFirtsLesson = lessonsSchedule.IndexOf(lessonTitle);
                        int indexOfSecondLesson = lessonsSchedule.IndexOf(secondLessonTitle);

                        if (lessonsSchedule.Contains(lessonTitle) &&
                            lessonsSchedule.Contains(secondLessonTitle))
                        {
                            lessonsSchedule[indexOfFirtsLesson] = secondLessonTitle;
                            lessonsSchedule[indexOfSecondLesson] = lessonTitle;

                            string firstLessonExercise = $"{lessonTitle}-Exercise";
                            int indexOfFirstExercise = indexOfFirtsLesson + 1;

                            if (lessonsSchedule.Contains(lessonsSchedule[indexOfFirtsLesson]) &&
                                lessonsSchedule.Contains(firstLessonExercise))
                            {
                                indexOfFirstExercise = lessonsSchedule.IndexOf(lessonTitle);
                                lessonsSchedule.Remove(firstLessonExercise);
                                lessonsSchedule.Insert(indexOfFirstExercise, firstLessonExercise);
                            }

                            string secondLessonExercise = $"{secondLessonTitle}-Exercise";
                            int indexOfSecondExercise = indexOfSecondLesson + 1;

                            if (lessonsSchedule.Contains(lessonsSchedule[indexOfSecondLesson]) &&
                                lessonsSchedule.Contains(secondLessonExercise))
                            {
                                indexOfSecondLesson = lessonsSchedule.IndexOf(secondLessonTitle);
                                lessonsSchedule.Remove(secondLessonExercise);    
                                lessonsSchedule.Insert(indexOfSecondLesson + 1, secondLessonExercise);
                            }
                        }
                        break;
                    case "Exercise":
                        index = lessonsSchedule.IndexOf(lessonTitle);
                        string exercise = $"{lessonTitle}-Exercise";

                        bool isThereAreLesson = lessonsSchedule.Contains(lessonTitle);
                        bool isThereAreExercise = lessonsSchedule.Contains(exercise);

                        if (isThereAreLesson && !isThereAreExercise)
                        { 
                            lessonsSchedule.Insert(index + 1, exercise);
                        }

                        if (!isThereAreLesson)
                        {
                            lessonsSchedule.Add(lessonTitle);
                            lessonsSchedule.Add(exercise);
                        }
                        break;
                }
            }

            for (int i = 0; i < lessonsSchedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessonsSchedule[i]}");
            }
        }
    }
}
