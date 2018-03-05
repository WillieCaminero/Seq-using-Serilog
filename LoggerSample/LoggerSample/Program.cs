using Serilog;
using System;

namespace LoggerSample
{
    public class Program
    {
        public static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            Log.Information("Hello, {Name}!", Environment.UserName);

            // Important to call at exit so that batched events are flushed.
            Log.CloseAndFlush();

            Console.ReadKey(true);
        }
    }
}
