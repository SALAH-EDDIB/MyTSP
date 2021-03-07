using System;

namespace MyTSP
{
    class Program
    {

        public static Random random { get; set; }

        static void Main(string[] args)
        {

             random = new Random();

            Order best = Order.GetOrder(300);
            Population population = Population.GetPopulation(best , 60);

            while (true)
            {

                double oldFit = population.bestOrder.fitness;

                population = population.NewPopulation(59);
                if (population.bestOrder.fitness > oldFit)
                    Console.WriteLine("Best distance: " + population.bestOrder.distance );

                    


            }



        }
    }

}
