using System;
using System.Collections.Generic;
using System.Text;

namespace Malinina.Homework.TaskМanager
{
    /// <summary>
    /// Task description class.
    /// </summary>
    class Task
    {
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Start date.
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Deadline.
        /// </summary>
        public DateTime Deadline { get; private set; }

        /// <summary>
        /// Status.
        /// </summary>
        public TaskStatus Status { get; private set; }

        /// <summary>
        /// Constructor with description, start date, deadline parameters.
        /// </summary>
        /// <param name="description">Description of the task.</param>
        /// <param name="startDate">Start date of the task.</param>
        /// <param name="deadline">Start date of the task.</param>
        public Task(string description, DateTime startDate, DateTime deadline)
        {
            Id = GenerateId();
            Description = description;
            StartDate = startDate;
            Deadline = deadline;
            Status = TaskStatus.ToDo;
        }

        /// <summary>
        /// Changing the task.
        /// </summary>
        /// <param name="description">Description of the task.</param>
        /// <param name="startDate">Start date of the task.</param>
        /// <param name="deadline">Start date of the task.</param>
        /// <param name="status">Task status.</param>
        public void EditData(string description, DateTime startDate, DateTime deadline, TaskStatus status)
        {
            Description = description;
            StartDate = startDate;
            Deadline = deadline;
            Status = status;
        }

        /// <summary>
        /// Generating a unique id.
        /// </summary>
        /// <returns>Four unique symbols.</returns>
        private string GenerateId()
        {
            return Guid.NewGuid().ToString().Substring(0, 4);
        }
    }
}
