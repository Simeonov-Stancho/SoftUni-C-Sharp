using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            string input = string.Empty;
            List<string> command = new List<string>();

            while ((input = Console.ReadLine()) != "course start")
            {
                command = input.Split(":", StringSplitOptions.RemoveEmptyEntries)
                               .ToList();

                if (command[0] == "Add")
                {
                    AddLesson(schedule, command);
                }

                else if (command[0] == "Insert")
                {
                    InsertLesson(schedule, command);
                }

                else if (command[0] == "Remove")
                {
                    RemoveLesson(schedule, command);
                }

                else if (command[0] == "Swap")
                {
                    SwapLesson(schedule, command);
                }

                else if (command[0] == "Exercise")
                {
                    AddExercise(schedule, command);
                }
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }

        }

        static List<string> AddLesson(List<string> schedule, List<string> command)
        {
            string lessonTitle = command[1];
            if ((schedule.Contains(lessonTitle)) == false)
            {
                schedule.Add(lessonTitle);
            }

            return schedule;
        }

        static List<string> InsertLesson(List<string> schedule, List<string> command)
        {
            string lessonTitle = command[1];
            int index = int.Parse(command[2]);

            if ((schedule.Contains(lessonTitle)) == false)
            {
                schedule.Insert(index, lessonTitle);
            }

            return schedule;
        }

        static List<string> RemoveLesson(List<string> schedule, List<string> command)
        {
            string lessonTitle = command[1];
            string exerciseTitle = lessonTitle + "-Exercise";

            if (schedule.Contains(lessonTitle))
            {
                if (schedule.Contains(exerciseTitle))
                {
                    schedule.Remove(lessonTitle);
                    schedule.Remove(exerciseTitle);
                }

                else
                {
                    schedule.Remove(lessonTitle);
                }
            }

            return schedule;
        }

        static List<string> SwapLesson(List<string> schedule, List<string> command)
        {
            string lessonTitle1 = command[1];
            string lessonTitle2 = command[2];

            string exerciseTitle1 = lessonTitle1 + "-Exercise";
            string exerciseTitle2 = lessonTitle2 + "-Exercise";

            if (schedule.Contains(lessonTitle1) && schedule.Contains(lessonTitle2))
            {
                if (schedule.Contains(exerciseTitle1)
                    && schedule.Contains(exerciseTitle2))
                {
                    int indexLesson1 = schedule.IndexOf(lessonTitle1);
                    int indexLesson2 = schedule.IndexOf(lessonTitle2);

                    schedule.Remove(lessonTitle1);
                    schedule.Remove(exerciseTitle1);
                    schedule.Remove(lessonTitle2);
                    schedule.Remove(exerciseTitle2);
                    schedule.Insert(indexLesson1, lessonTitle2);
                    schedule.Insert(indexLesson1 + 1, exerciseTitle2);
                    schedule.Insert(indexLesson2, lessonTitle1);
                    schedule.Insert(indexLesson2 + 1, exerciseTitle1);
                }

                else if (schedule.Contains(exerciseTitle1))
                {
                    int indexLesson1 = schedule.IndexOf(lessonTitle1);
                    int indexLesson2 = schedule.IndexOf(lessonTitle2);

                    schedule.Remove(lessonTitle1);
                    schedule.Remove(exerciseTitle1);
                    schedule.Remove(lessonTitle2);
                    schedule.Insert(indexLesson1, lessonTitle2);
                    schedule.Insert(indexLesson2 - 1, lessonTitle1);
                    schedule.Insert(indexLesson2, exerciseTitle1);
                }

                else if (schedule.Contains(exerciseTitle2))
                {
                    int indexLesson1 = schedule.IndexOf(lessonTitle1);
                    int indexLesson2 = schedule.IndexOf(lessonTitle2);

                    schedule.Remove(lessonTitle1);
                    schedule.Remove(lessonTitle2);
                    schedule.Remove(exerciseTitle2);
                    schedule.Insert(indexLesson1, lessonTitle2);
                    schedule.Insert(indexLesson1 + 1, exerciseTitle2);
                    schedule.Insert(indexLesson2 + 1, lessonTitle1);
                }

                else
                {
                    int index1 = schedule.IndexOf(lessonTitle1);
                    int index2 = schedule.IndexOf(lessonTitle2);

                    schedule.Remove(lessonTitle1);                  
                    schedule.Insert(index1, lessonTitle2);
                    schedule.RemoveAt(index2);
                    schedule.Insert(index2, lessonTitle1);
                }
            }

            return schedule;
        }

        static List<string> AddExercise(List<string> schedule, List<string> command)
        {
            string lessonTitle1 = command[1];
            string exerciseTitle = lessonTitle1 + "-Exercise";

            if (schedule.Contains(lessonTitle1) &&
                (schedule.Contains(exerciseTitle) == false))
            {
                int index1 = schedule.IndexOf(lessonTitle1);
                schedule.Insert((index1 + 1), exerciseTitle);
            }


            else if (schedule.Contains(lessonTitle1) == false)
            {
                schedule.Add(lessonTitle1);
                schedule.Add(exerciseTitle);
            }

            return schedule;
        }
    }
}