using System;
using System.Collections.Generic;
using System.Linq;

namespace Malinina.Homework.FitnessTracker
{
    internal class TrainingStatistics
    {
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

        private static double GetTotalDistance(IEnumerable<Training> trainings)
        {
            return Math.Round(trainings.Sum(element => element.Distance), 2);
        }

        private static double GetMaxDistancPerTrainingSession(IEnumerable<Training> trainings)
        {
            return Math.Round(trainings.Max(element => element.Distance), 2);
        }

        private static double GetAverageDistance(IEnumerable<Training> trainings)
        {
            return Math.Round(trainings.Average(element => element.Distance), 2);
        }
        private static double GetAverageDuration(IEnumerable<Training> trainings)
        {
            return Math.Round(trainings.Average(element => element.Duration.TotalMinutes), 2);
        }

        private static int GetAveragePulse(IEnumerable<Training> trainings)
        {
            return (int)trainings.Average(element => element.AveragePulsePerTrainingSession);
        }
    }
}
