
using DinningPhilosophersProblem;

var fork1 = new Fork("Fork 1");
var fork2 = new Fork("Fork 2");
var fork3 = new Fork("Fork 3");
var fork4 = new Fork("Fork 4");
var fork5 = new Fork("Fork 5");


var philosopher1 = new Philosopher("Philosopher 1", fork1, fork2);
var philosopher2 = new Philosopher("Philosopher 2", fork2, fork3);
var philosopher3 = new Philosopher("Philosopher 3", fork3, fork4);
var philosopher4 = new Philosopher("Philosopher 4", fork4, fork5);
var philosopher5 = new Philosopher("Philosopher 5", fork5, fork1);


var thread1 = new Thread(new ThreadStart(() => philosopher1.DoWork()));
var thread2 = new Thread(new ThreadStart(() => philosopher2.DoWork()));
var thread3 = new Thread(new ThreadStart(() => philosopher3.DoWork()));
var thread4 = new Thread(new ThreadStart(() => philosopher4.DoWork()));
var thread5 = new Thread(new ThreadStart(() => philosopher5.DoWork()));

thread1.Start();
thread2.Start();
thread3.Start();
thread4.Start();
thread5.Start();

thread1.Join();
thread2.Join();
thread3.Join();
thread4.Join();
thread5.Join();

Console.WriteLine("All the Philosopher have finished!");