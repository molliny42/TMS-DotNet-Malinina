using System;
using System.Collections.Generic;
using System.Linq;

namespace Malinina.Homework.FitnessTracker
{
    /// <summary>
    /// Training work class.
    /// </summary>
    internal class TrainingGenerator
    {
        private static Random random = new Random();

        /// <summary>
        /// Training generation.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Training> GetTrainings()
        {
            return Enumerable.Range(0, Constants.MAX_TRAININGS_COUNTS).Select(CreateTraining);
        }

        /// <summary>
        /// Creation of a training session.
        /// </summary>
        /// <param name="num">Number of training session.</param>
        /// <returns></returns>
        private static Training CreateTraining(int num)
        {
            var dateTraining =  DateTime.Now.AddDays(num);
            var duration = new TimeSpan(random.Next(0, Constants.MAX_TRAINING_HOURS),
                                        random.Next(Constants.MIN_TRAINING_MINUTES, Constants.MAX_TRAINING_MINUTES),
                                        random.Next(0, Constants.MAX_TRAINING_SECONDS));

            int stepsInMinute = random.Next(minValue: Constants.MIN_STEPS_IN_MINUTE,
                                            maxValue: Constants.MAX_STEPS_IN_MINUTE);
            var steps = (int)(duration.TotalMinutes * stepsInMinute);

            var lengthStep = (random.NextDouble() * (Constants.MAX_LENGTH_STEP - Constants.MIN_LENGTH_STEP)) + Constants.MIN_LENGTH_STEP;
            var distance = steps * lengthStep;
            var averagePulsePerTraningSession = (int)GetPulses(true).Average();

            var training = new Training(dateTraining, duration, steps, distance, averagePulsePerTraningSession);
            
            return training;
        }

        /// <summary>
        /// Pulse generation.
        /// </summary>
        /// <param name="hasThird"></param>
        /// <returns></returns>
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

            yield return random.Next(90, 150);

            yield break;
        }
    }
}
