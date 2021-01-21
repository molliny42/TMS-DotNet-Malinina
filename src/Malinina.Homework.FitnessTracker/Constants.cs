using System;
using System.Collections.Generic;
using System.Text;

namespace Malinina.Homework.FitnessTracker
{
    /// <summary>
    /// Class of constants for creating a training session.
    /// </summary>
    internal static class Constants
    {
        internal const int MAX_TRAININGS_COUNTS = 100;

        internal const int MAX_TRAINING_HOURS = 2;

        internal const int MIN_TRAINING_MINUTES = 1;
        internal const int MAX_TRAINING_MINUTES = 60;
        internal const int MAX_TRAINING_SECONDS = 60;


        internal const int MIN_STEPS_IN_MINUTE = 113;
        internal const int MAX_STEPS_IN_MINUTE = 185;

        internal const double MIN_LENGTH_STEP = 0.67;
        internal const double MAX_LENGTH_STEP = 1.3;
    }
}
