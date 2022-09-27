namespace Concurrency.Solutions
{
    public class ThreadConcurrencyMutexSolution : ThreadConcurrencyBaseSolution
    {
        private Mutex _mutex = new Mutex();

        public ThreadConcurrencyMutexSolution()
        {
            _nameSolution = "Mutex";
        }

        public override void DoWork(string criticalText)
        {
            Console.WriteLine("{0} is requesting the mutex",
                              Thread.CurrentThread.Name);

            // Wait until it is safe to enter.
            _mutex.WaitOne();
            
            CriticalSection(criticalText);
            
            // Release the Mutex.
            _mutex.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex",
                Thread.CurrentThread.Name);
        }
    }
}
