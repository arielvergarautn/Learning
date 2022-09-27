namespace Concurrency.Solutions
{
    public class ThreadConcurrencyLockSolution : ThreadConcurrencyBaseSolution
    {
        static readonly object _object = new object();

        public ThreadConcurrencyLockSolution()
        {
            _nameSolution = "Lock";
        }

        public override void DoWork(string criticalText)
        {
            Console.WriteLine("{0} is requesting the lock",
                              Thread.CurrentThread.Name);
            lock (_object)
            {
                CriticalSection(criticalText);
            }

            Console.WriteLine("{0} is released the lock",
                              Thread.CurrentThread.Name);
        }
    }
}
