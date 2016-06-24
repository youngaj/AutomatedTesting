using System;

namespace SampleProject
{
    public interface ILogger
    {
        void info(string msg);
    }

    public class Logger : ILogger
    {
        public void info(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}