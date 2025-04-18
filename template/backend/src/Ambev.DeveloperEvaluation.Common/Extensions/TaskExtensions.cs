using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Extensions
{
    /// <summary>
    /// Extension methods for safely executing fire-and-forget tasks.
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Safely executes an asynchronous task in the background without awaiting it.
        /// Any exceptions thrown inside the task are caught and optionally handled via the onError callback.
        /// </summary>
        /// <param name="task">The asynchronous task to execute.</param>
        /// <param name="onError">
        /// Optional action to handle any exception thrown during task execution.
        /// If not provided, the exception is swallowed.
        /// </param>
        public static void FireAndForgetSafeAsync(this Task task, Action<Exception>? onError = null)
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    await task;
                }
                catch (Exception ex)
                {
                    onError?.Invoke(ex);
                }
            });
        }
    }
}
