using System;

namespace Repositories
{
    /// <summary>
    /// Base class to log instance initalization
    /// </summary>
    public abstract class InstanceLogger
    {
        private static int _counter = 0;

        private int _id;

        protected string InstanceName => $"{this.GetType().Name} [#{_id}]";

        protected InstanceLogger()
        {
            _id = ++_counter;

            Console.WriteLine($"* {InstanceName} is created");
        }

    }
}
