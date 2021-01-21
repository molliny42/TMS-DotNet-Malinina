using System;
using System.Collections.Generic;
using System.Linq;

namespace Malinina.Homework.FitnessTracker
{
    internal class TrainingGenerator
    {
        private static Random random = new Random();

        public static IEnumerable<Training> GetTrainings()
        {
            return Enumerable.Range(0, 100).Select(CreateTraining);
        }

        private static Training CreateTraining(int num)
        {
            var dateTraining = new DateTime(2021, 01, 21).AddDays(num);
            var duration = new TimeSpan(random.Next(0, 2), random.Next(1, 60), random.Next(0, 60));

            var stepsInMinute = random.Next(113, 185);
            var steps = (int)(duration.TotalMinutes * stepsInMinute);

            var lengthStep = (random.NextDouble() * (1.3 - 0.67)) + 0.67;
            var distance = steps * lengthStep;
            var averagePulsePerTraningSession = (int)GetPulses(true).Average();

            var training = new Training(dateTraining, duration, steps, distance, averagePulsePerTraningSession);
            
            return training;
        }

        public static IEnumerable<int> GetPulses(bool hasThird) // true -> [0, 1, 2, 3]
                                                                // 1. Current = 0 -> MoveNext()
                                                                // 2. Current = 1 -> MoveNext()
                                                                // 3. hasThird 
                                                                //		? Current = 2 -> MoveNext()
                                                                //		: Current = 3 -> MoveNext();
        {

            yield return random.Next(90, 150);

            yield return random.Next(90, 150);

            if (hasThird)
                yield return random.Next(90, 150);
            // else
            // 	yield break;

            yield return random.Next(90, 150);

            yield break;
        }
    }
}
