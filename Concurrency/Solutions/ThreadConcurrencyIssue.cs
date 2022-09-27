namespace Concurrency.Solutions
{
    public class ThreadConcurrencyIssue : ThreadConcurrencyBaseSolution
    {
        public ThreadConcurrencyIssue()
        {
            _nameSolution = "Issue";
        }

        public override void DoWork(string criticalText)
        {
            Console.WriteLine("{0} has entered the critical area",
                              Thread.CurrentThread.Name);

            CriticalSection(criticalText);

            Console.WriteLine("{0} has left the critical area",
                              Thread.CurrentThread.Name);
        }
    }
}
