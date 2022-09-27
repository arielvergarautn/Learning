using System.Diagnostics;

namespace DinningPhilosophersProblem
{
    internal class Philosopher
    {
        private const int Repeat = 2;
        private const int TimeToGetAnotherFork = 2000;
        private const int TimeToWaitForAnotherFork = 5000;
        private const int ThinkTime = 1000;
        private const int EatTime = 2000;
        private const int SleepTime = 2500;
        private readonly string _name;
        private readonly Fork _fork1;
        private readonly Fork _fork2;
        private Random _random = new Random();

        public Philosopher(string philosopherName, Fork forkOne, Fork forkTwo)
        {
            _name = philosopherName;
            _fork1 = forkOne;
            _fork2 = forkTwo;
        }

        internal void Eat()
        {
            
            Console.WriteLine(_name + " is Eating!");
            Thread.Sleep(_random.Next(EatTime));
            Console.WriteLine(_name + " has eaten!");

        }
        
        internal void Think()
        {
            Console.WriteLine(_name + " is thinking!");
            Thread.Sleep(_random.Next(ThinkTime));
            //Console.WriteLine(_name + " already thought!");
        }
        
        internal void Sleep()
        {
            Console.WriteLine(_name + " is Sleeping!");
            Thread.Sleep(_random.Next(SleepTime));
            Console.WriteLine(_name + " has slept!");
        }

        internal void DoWork()
        {
            int i = 0;

            while (i < Repeat) {
                
                Think();

                //Critical
                DoCriticalSection();

                Sleep();
                i++;
            }
        }

        internal void DoCriticalSection()
        {
            bool isfork2Taken = false;
            // lock he first fork
            Monitor.Enter(_fork1);
            Console.WriteLine($"{_name} got fork {_fork1.Name}!");

            Thread.Sleep(TimeToGetAnotherFork);

            // lock the second fork
            Monitor.TryEnter(_fork2, _random.Next(TimeToWaitForAnotherFork), ref isfork2Taken);

            if (!isfork2Taken)
            {
                Monitor.Exit(_fork1);
                Console.WriteLine($"{_name} released fork {_fork1.Name} BECAUSE OF TIME OUT!");
                DoCriticalSection();
                return;
            }
            Thread.Sleep(100);
            Console.WriteLine($"{_name} got fork {_fork2.Name}!");

            try
            {
                Eat();
            }
            finally
            {
                // Release forks!
                Monitor.Exit(_fork1);
                Console.WriteLine($"{_name} released fork {_fork1.Name}!");
                Monitor.Exit(_fork2);
                Console.WriteLine($"{_name} released fork {_fork2.Name}!");
            }
        }
    }
}
