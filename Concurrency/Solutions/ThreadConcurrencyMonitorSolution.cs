namespace Concurrency.Solutions
{
    public class ThreadConcurrencyMonitorSolution : ThreadConcurrencyBaseSolution
    {
        static readonly object _object = new object();

        public override void DoWork(string criticalText)
        {
            Console.WriteLine("{0} is requesting the Monitor",
                              Thread.CurrentThread.Name);
            Monitor.Enter(_object);
            try
            {
                CriticalSection(criticalText);
            }
            finally
            {
                Monitor.Exit(_object);
                Console.WriteLine("{0} is releasing the Semaphore",
                              Thread.CurrentThread.Name);
            }
        }
    }
}
