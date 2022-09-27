namespace Concurrency.Solutions
{
    public abstract class ThreadConcurrencyBaseSolution
    {
        private readonly Thread _threadOne;
        private readonly Thread _threadTwo;
        private readonly Thread _threadThree;
        private string _criticalText = "";
        protected string _nameSolution = "Base";

        protected ThreadConcurrencyBaseSolution()
        {
            _threadOne = new Thread(new ThreadStart(() => DoWork("CRITICAL TEXT ONE")));
            _threadOne.Name = "THREAD 1";
            _threadTwo = new Thread(new ThreadStart(() => DoWork("CRITICAL TEXT TWO")));
            _threadTwo.Name = "THREAD 2";
            _threadThree = new Thread(new ThreadStart(() => DoWork("CRITICAL TEXT THREE")));
            _threadThree.Name = "THREAD 3";
            CriticalText = "CRITICAL TEXT DEFAULT";
        }

        public string CriticalText { get => _criticalText; set => _criticalText = value; }
        public string NameSolution { get => _nameSolution; }

        public void StartThreads()
        {
            _threadOne.Start();
            _threadTwo.Start();
            _threadThree.Start();

            _threadOne.Join();
            _threadTwo.Join();
            _threadThree.Join();
        }

        protected void CriticalSection(string criticalText)
        {
            Console.WriteLine("{0} has entered the critical section",
                              Thread.CurrentThread.Name);
            
            Thread.Sleep(1000);

            CriticalText += " ## " + criticalText;

            Thread.Sleep(1000);

            Console.WriteLine(CriticalText);

            Console.WriteLine("{0} has left the critical section",
                              Thread.CurrentThread.Name);
        }

        public abstract void DoWork(string criticalText);
    }
}
