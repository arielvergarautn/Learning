namespace Concurrency.Solutions
{
    public class ThreadConcurrencySemaphoreSolution : ThreadConcurrencyBaseSolution
    {
        private Semaphore _semaphore = new Semaphore(initialCount: 2, maximumCount: 2, name: "Thread concurrency semaphore solution");
        private int _count { get; set; }
        
        public ThreadConcurrencySemaphoreSolution()
        {
            _nameSolution = "Semaphore";
        }

        public override void DoWork(string criticalText)
        {
            Console.WriteLine("{0} is requesting the Semaphore",
                              Thread.CurrentThread.Name);
            _semaphore.WaitOne();
            CriticalSection(criticalText);
            _count = _semaphore.Release();

            Console.WriteLine("{0} is released the Semaphore. Semaphore count: {1}",
                              Thread.CurrentThread.Name, _count);
        }
    }
}
