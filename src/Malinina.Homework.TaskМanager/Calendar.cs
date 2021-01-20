using System;
using System.Collections.Generic;

namespace Malinina.Homework.TaskМanager
{
    /// <summary>
    /// Task work class.
    /// </summary>
    class Calendar
    {
        private List<Task> m_tasks = new List<Task>();

        /// <summary>
        /// Adding a task.
        /// </summary>
        public void AddTask()
        {
            Console.WriteLine("Enter description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter start date: ");
            DateTime startDate = GetDate();

            Console.WriteLine("Enter deadline: ");
            DateTime deadline = GetDeadlineDate(startDate);

            Task task = new Task(description, startDate, deadline);

            m_tasks.Add(task);
        }

        /// <summary>
        /// Changing the task.
        /// </summary>
        public void EditTask()
        {
            if (GetTask(out Task task))
            {
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine("Enter new description: ");
                string description = Console.ReadLine();

                Console.WriteLine("Enter new start date: ");
                DateTime startDate = GetDate();

                Console.WriteLine("Enter deadline: ");
                DateTime deadline = GetDeadlineDate(startDate);

                Console.WriteLine("Enter new status:");
                TaskStatus status = GetStatus();


                task.EditData(description, startDate, deadline, status);
            }
        }

        /// <summary>
        /// Deleting a task.
        /// </summary>
        public void DeleteTask()
        {
            if (GetTask(out Task task))
            {
                m_tasks.Remove(task);
            }
        }

        /// <summary>
        /// Display of all tasks.
        /// </summary>
        public void ShowAllTasks()
        {
            if (m_tasks.Count == 0)
            {
                Console.WriteLine("Calendar is empty");
                return;
            }
            for (int i = 0; i < m_tasks.Count; i++)
            {
                Console.WriteLine($"ID: {m_tasks[i].Id}");
                Console.WriteLine($"Description: {m_tasks[i].Description}");
                Console.WriteLine($"Start date: {m_tasks[i].StartDate}");
                Console.WriteLine($"Deadline: {m_tasks[i].Deadline}");
                Console.WriteLine($"Status: {m_tasks[i].Status}");
                Console.WriteLine("--------------------------------------------");
            }
        }

        /// <summary>
        /// Checking the existence of a task.
        /// </summary>
        /// <param name="task">Task.</param>
        /// <returns>true or false.</returns>
        private bool GetTask(out Task task)
        {
            task = null;

            if (m_tasks.Count == 0)
            {
                Console.WriteLine("Calendar is empty");
                return false;
            }

            Console.WriteLine("Enter task ID: ");
            string inputeId = Console.ReadLine();

            for (int i = 0; i < m_tasks.Count; i++)
            {
                if (m_tasks[i].Id == inputeId)
                {
                    task = m_tasks[i];
                    return true;
                }
            }

            Console.WriteLine("The task ID does not exist!");
            return false;
        }

        /// <summary>
        /// Processing the entered deadline.
        /// </summary>
        /// <param name="startTime">The entered date.</param>
        /// <returns>Daedline is longer than the start date.</returns>
        private DateTime GetDeadlineDate(DateTime startTime)
        {
            DateTime deadline = GetDate();

            if(!CompareDates(startTime, deadline))
            {
                Console.WriteLine("Deadline can't be less then start date. Enter date again:");             
                return GetDeadlineDate(startTime);
            }

            return deadline;
        }

        /// <summary>
        /// Checking the format of the entered date.
        /// </summary>
        /// <returns>Correct date.</returns>
        private DateTime GetDate()
        {
            string inputValue = Console.ReadLine();

            if (DateTime.TryParse(inputValue, out DateTime date))
            {
                return date;
            }
            else
            {
                Console.WriteLine("Incorrect date! Enter again: ");
                return GetDate();
            }
        }

        /// <summary>
        /// Start date and deadline comparison.
        /// </summary>
        /// <param name="startDate">Start date of the task.</param>
        /// <param name="deadline">Start date of the task.</param>
        /// <returns>true or false.</returns>
        private bool CompareDates(DateTime startDate, DateTime deadline)
        {
            return startDate.CompareTo(deadline) <= 0;
        }

        /// <summary>
        /// Change task status.
        /// </summary>
        /// <returns>Task status.</returns>
        private TaskStatus GetStatus()
        {
            Console.WriteLine("Enter status:");
            Console.WriteLine("1 To Do: ");
            Console.WriteLine("2. In Progress: ");
            Console.WriteLine("3. Done: ");

            string inputValue = Console.ReadLine();

            if (TaskStatus.TryParse(inputValue, out TaskStatus status))
            {
                return status;
            }
            else
            {
                Console.WriteLine("Incorrect status! Enter again: ");
                return GetStatus();
            }
        }
    }
}
