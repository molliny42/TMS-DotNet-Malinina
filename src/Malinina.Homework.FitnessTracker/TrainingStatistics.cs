using System;
using System.Collections.Generic;
using System.Linq;

namespace Malinina.Homework.FitnessTracker
{
    /// <summary>
    /// Class for working with training statistics.
    /// </summary>
    internal class TrainingStatistics
    {
        /// <summary>
        /// Display of training statistics.
        /// </summary>
        public static void ShowTrainingStatistics()
        {
            IEnumerable<Training> trainings = TrainingGenerator.GetTrainings();
            var totalDistance = GetTotalDistance(trainings);
            var maxDistancePerTrainingSession = GetMaxDistancPerTrainingSession(trainings);
            var averageDistance = GetAverageDistance(trainings);
            var averageDuration = GetAverageDuration(trainings);
            var averagePulse = GetAveragePulse(trainings);

            Console.WriteLine($"Total distance: {totalDistance} m");
            Console.WriteLine($"Max distance per training session: {maxDistancePerTrainingSession} m");
            Console.WriteLine($"Average distance: {averageDistance} m");
            Console.WriteLine($"Average duration training: {averageDuration} min");
            Console.WriteLine($"Average pulse: {averagePulse} beats per min");
        }

        /// <summary>
        /// Calculation of the total distance.
        /// </summary>
        /// <param name="trainings"></param>
        /// <returns></returns>
        private static double GetTotalDistance(IEnumerable<Training> trainings)
        {
            return Math.Round(trainings.Sum(element => element.Distance), 2);
        }

        /// <summary>
        /// Calculation of the max distance per training session.
        /// </summary>
        /// <param name="trainings">Trainings.</param>
        /// <returns></returns>
        private static double GetMaxDistancPerTrainingSession(IEnumerable<Training> trainings)
        {
            return Math.Round(trainings.Max(element => element.Distance), 2);
        }

        /// <summary>
        /// Calculation of the average distance.
        /// </summary>
        /// <param name="trainings">Trainings.</param>
        /// <returns></returns>
        private static double GetAverageDistance(IEnumerable<Training> trainings)
        {
            return Math.Round(trainings.Average(element => element.Distance), 2);
        }
        /// <summary>
        /// Calculation of the average duration.
        /// </summary>
        /// <param name="trainings">Trainings.</param>
        /// <returns></returns>
        private static double GetAverageDuration(IEnumerable<Training> trainings)
        {
            return Math.Round(trainings.Average(element => element.Duration.TotalMinutes), 2);
        }

        /// <summary>
        /// Calculation of the average pulse.
        /// </summary>
        /// <param name="trainings">Trainings</param>
        /// <returns></returns>
        private static int GetAveragePulse(IEnumerable<Training> trainings)
        {
            return (int)trainings.Average(element => element.AveragePulsePerTrainingSession);
        }
    }
}
