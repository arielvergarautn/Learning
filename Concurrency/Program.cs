using Concurrency.Constants;
using Concurrency.Solutions;

ThreadConcurrencyBaseSolution solution;

string threadConcurrencyType = GetNextCommand();

while (threadConcurrencyType != ThreadConcurrencyConstants.Exit)
{
    solution = threadConcurrencyType switch
    {
        ThreadConcurrencyConstants.ThreadConcurrencyWithIssue => new ThreadConcurrencyIssue(),
        ThreadConcurrencyConstants.ThreadConcurrencyWithMutex => new ThreadConcurrencyMutexSolution(),
        ThreadConcurrencyConstants.ThreadConcurrencyWithSemaphore => new ThreadConcurrencySemaphoreSolution(),
        ThreadConcurrencyConstants.ThreadConcurrencyWithLock => new ThreadConcurrencyLockSolution(),
        ThreadConcurrencyConstants.ThreadConcurrencyWithMonitor => new ThreadConcurrencyMonitorSolution(),
        _ => new ThreadConcurrencyMutexSolution(),
    };

    Console.WriteLine("Starting the {0} solution...", solution.NameSolution);
    solution.StartThreads();
    AddNewCommandSeparator();

    threadConcurrencyType = GetNextCommand();
}

static string GetNextCommand()
{
    Console.WriteLine("Type of solutions you are able to run: ");
    Console.WriteLine("- {0}", ThreadConcurrencyConstants.ThreadConcurrencyWithIssue);
    Console.WriteLine("- {0}", ThreadConcurrencyConstants.ThreadConcurrencyWithMutex);
    Console.WriteLine("- {0}", ThreadConcurrencyConstants.ThreadConcurrencyWithSemaphore);
    Console.WriteLine("- {0}", ThreadConcurrencyConstants.ThreadConcurrencyWithLock);
    Console.WriteLine("- {0}", ThreadConcurrencyConstants.ThreadConcurrencyWithMonitor);
    Console.WriteLine("- {0}", ThreadConcurrencyConstants.Exit);
    Console.WriteLine("By default will run the Mutex solution");
    Console.WriteLine();
    Console.Write("Please enter a type of solution or exit: ");

    var threadConcurrencyType = Console.ReadLine() ?? "";
    return threadConcurrencyType.ToLower();
}

static void AddNewCommandSeparator()
{
    Console.WriteLine();
    Console.WriteLine("####################################################");
    Console.WriteLine();
}