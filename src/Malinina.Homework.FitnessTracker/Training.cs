using System;

namespace Malinina.Homework.FitnessTracker
{
    internal class Training
    {
        public DateTime DateTraining { get; private set; }
        public TimeSpan Duration { get; private set; }
        public int Steps { get; private set; }
        public double Distance { get; private set; }
        public int AveragePulsePerTrainingSession { get; private set; }

        public Training(DateTime dateTraining, TimeSpan duration, int steps, double distance, int averagePulsePerTraningSession)
        {
            DateTraining = dateTraining;
            Duration = duration;
            Steps = steps;
            Distance = distance;
            AveragePulsePerTrainingSession = averagePulsePerTraningSession;
        }
    }
}
