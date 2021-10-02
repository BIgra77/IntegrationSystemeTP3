using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TP3
{
    internal class Program
    {
        
        //Exercise 1 :
        
        public static void AllMovies()
                {
                    //Count all movies
                    var collection = new MovieCollection().Movies;
                    Console.WriteLine(collection.Count);
                }
        public static void Lettere()
        {
            //Count all movie with the letter "e"
            var collection = new MovieCollection().Movies;
            
            Console.WriteLine(collection.Count(x=>x.Title.Contains("e")));
        }
        
        
        public static void Letterf()
        {
            //Count how many time the letter f is in all the titles
            var collection = new MovieCollection().Movies;
            var CounterF = 0;

            foreach (var itemF in collection)
            {
                CounterF+= itemF.Title.Count(y=> y == 'f');
            }
            Console.WriteLine(CounterF);  
        }
        public static void HigherBudget()
        {
            var collection = new MovieCollection().Movies;
            var higherbudget = collection.Max(s => s.Budget);
            var higher = collection.Where(c => c.Budget==higherbudget).Select(s => s.Title).FirstOrDefault();
            Console.WriteLine(higher);
        }

        public static void LowestBO()
        {
            // Display the title of the movie with the lowest box office
            var collection = new MovieCollection().Movies;
            var lowerBO = collection.Min(s => s.BoxOffice);
            var lower = collection.Where(c => c.BoxOffice==lowerBO).Select(s => s.Title).FirstOrDefault();
            Console.WriteLine(lower);
        }

        public static void Reversed()
        {
            //Order the movies by reversed alphabetical order and print the first 11 of the list.
            
            var collection = new MovieCollection().Movies;

            var reverse = collection.OrderByDescending(x => x.Title)
                .Take(11)
                .Select(g => g).ToList();
            foreach (var item in reverse)
            { 
                Console.WriteLine($"{item.Title}");
            }
          
        }
        
        public static void Before()
        {
            //Count all the movies made before 1980.
            var collection = new MovieCollection().Movies;
            Console.WriteLine(collection.Count(x=>x.ReleaseDate.Year<1980));
        }
        
        public static void Average()
        {
            //Display the average running time of movies having a vowel as the first letter
            
            var collection = new MovieCollection().Movies;

            double averageRunningTime = 0;
            int initialCount = 0;
            foreach (var item in collection.Where(x => x.Title[0] =='A' || x.Title[0] == 'E' || x.Title[0] == 'I' || x.Title[0] == 'O' || x.Title[0] == 'U' || x.Title[0] == 'Y'))
            {
                averageRunningTime += item.RunningTime;
                initialCount++;
            }
            Console.WriteLine($"average of {averageRunningTime / initialCount} hours");
        }
        
        public static void Letter()
        {
            //Print all movies with the letter H or W in the title, but not the letter I or T
            var collection = new MovieCollection().Movies;

            var MoviesWithHOrW = collection.Where(x => (x.Title.Contains('h') || x.Title.Contains('H') || x.Title.Contains('W') || x.Title.Contains('w')) && !x.Title.Contains('t') && !x.Title.Contains('T') && !x.Title.Contains('i') && !x.Title.Contains('I'))
                .Select(g => g).ToList();
            foreach (var item in MoviesWithHOrW)
            { 
                Console.WriteLine(item.Title); 
            }
        }
        
        public static void Mean()
        {
            // Calculate the mean of all Budget / Box Office of every movie ever
            var collection = new MovieCollection().Movies;
            var meanOfAllBudget = collection.GroupBy(x => x.Budget)
                .Distinct();
            var meanOfAllBoxOffice = collection.GroupBy(x => x.BoxOffice)
                .Distinct();
            Console.WriteLine($"Mean Budget: {meanOfAllBudget.Average(x => x.Key)}\nMean Box Office: {meanOfAllBoxOffice.Average(x => x.Key)}");
        }
        
        
        //Exercise 2 : 
        
            static Mutex mut = new Mutex();
            
            public static void job(char caractere, int time, int beat)
            {
                var sw = new Stopwatch();
                sw.Start();
                do
                {
                    mut.WaitOne();
                    Console.Write(caractere);
                    mut.ReleaseMutex();
                    Thread.Sleep(beat);
                } while (sw.ElapsedMilliseconds < time);
                sw.Stop();
            }
            public static void Fred(Object obj)
            {
                var th = Thread.CurrentThread;
                if (th.Name == "fred1")
                    job('_', 1000, 50);
                else if (th.Name == "fred2")
                    job('*', 11000, 40);
                else if (th.Name == "fred3")
                    job('°', 9000, 20);
            
            }

            public static void fred()
            {
                Console.WriteLine("Threads starting...");
            
                Thread t1 = new Thread(Fred);
                Thread t2 = new Thread(Fred);
                Thread t3 = new Thread(Fred);
                
                t1.Name = "fred1";
                t2.Name = "fred2";
                t3.Name = "fred3";
            
                t1.Start();
                t2.Start();
                t3.Start();
            }
            
            public static void Main(string[] args)
            {
                //Put the function you want to check here. ex : 
                //fred(); 
                Before();
            } 
    } 
}
