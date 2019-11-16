using System;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class TaskExtensions
    {
        public static Task ContinueWith<T, S>(this Task<T> task, Func<T, Task<S>> func)
        {
            return task.ContinueWith(value => func?.Invoke(value));
        }

        public static Task ContinueWith<T>(this Task<T> task, Func<T, Task> func)
        {
            return task.ContinueWith(value => func?.Invoke(value));
        }
    }
}