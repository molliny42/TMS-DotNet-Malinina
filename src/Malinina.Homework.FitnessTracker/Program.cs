using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Malinina.Homework.FitnessTracker
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting Fitness Tracker...");
			IEnumerable<Training> trainings = TrainingGenerator.GetTrainings();

			Console.WriteLine("Started Fitness Tracker.");
			var averageDistance = GetAverageDistance(trainings);
			var allTimeDistance = GetAllTimeDistance(trainings);
			var maxDistance = GetMaxDistance(trainings);

			// TODO: Output results
			Console.WriteLine($"Average Distance: {averageDistance}");
			Console.WriteLine($"Total Distance: {allTimeDistance}");
			Console.WriteLine($"Max Distance: {maxDistance}");
			Console.WriteLine($"Average Pulse: {trainings.Average(element => element.AveragePulse)}");
			Console.WriteLine($"Average Duration: {trainings.Average(element => element.Duration.TotalMinutes)}");
			Console.ReadLine();
		}

		private static double GetMaxDistance(IEnumerable<Training> trainings)
		{
			//TODO: return max distance for all trainings
			return trainings.Max(element => element.Distance);
		}

		private static double GetAllTimeDistance(IEnumerable<Training> trainings)
		{
			//TODO: return distance for all trainings
			return trainings.Sum(element => element.Distance);
		}

		private static double GetAverageDistance(IEnumerable<Training> trainings)
		{
			//TODO: return avarage distance for all trainings
			return trainings.Average(element => element.Distance);
		}
	}

	internal class TrainingGenerator
	{
		public static IEnumerable<Training> GetTrainings()
		{
			return Enumerable.Range(0, 100).Select(CreateTraining);
		}

		private static Training CreateTraining(int num)
		{
			var rnd = new Random();
			var startDate = new DateTime(2021,01,21).AddDays(num);
			var duration = new TimeSpan(rnd.Next(0, 2), rnd.Next(1, 60), rnd.Next(0, 60));
			var steps = (int)(duration.TotalMinutes * 113); //113 - step in minute
			var distance = steps * 0.7; //0.7 - 70 sm
			var pulse = GetPulses(true);

			var training = new Training();
			training.StartDate = startDate;
			training.Duration = duration;
			training.Steps = steps;
			training.Distance = distance;
			training.AveragePulse = (int)pulse.Average();

			return training;
		}

		public static IEnumerable<int> GetPulses(bool hasThird) // true -> [0, 1, 2, 3]
																// 1. Current = 0 -> MoveNext()
																// 2. Current = 1 -> MoveNext()
																// 3. hasThird 
																//		? Current = 2 -> MoveNext()
																//		: Current = 3 -> MoveNext();
		{
			var rnd = new Random();

			yield return rnd.Next(90,150);

			yield return rnd.Next(90, 150);

			if (hasThird)
				yield return rnd.Next(90, 150);
			// else
			// 	yield break;

			yield return rnd.Next(90, 150);

			yield break;
		}
	}

	internal class Training
	{
		public TimeSpan Duration { get; set; }
		public DateTime StartDate { get; set; }
		public double Distance { get; set; }
		public int Steps { get; set; }
		public int AveragePulse { get; set; }
	}
}
