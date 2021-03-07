using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTSP
{
    class Population
    {

        public List<Order> population { get;  set; }
        public Order bestOrder { get;  set; }


        public Population(List<Order> pop)
        {
            population = pop;
            bestOrder = this.findBest();
        }


        public static Population GetPopulation(Order order, int n)
        {
            List<Order> pop = new List<Order>();

            for (int i = 0; i < n; ++i)
                pop.Add(order.swap());

            return new Population(pop);
        }

        public Population NewPopulation(int n )
        {
            List<Order> p = new List<Order>();

            p.Add(bestOrder);

            for (int i = 0; i < n; ++i)
            {

                var o = bestOrder.mutate();

                p.Add(o);
                

               
            }

            return new Population(p);


        }

        public Order findBest()
        {
            var bestFit = this.population.Max(t => t.fitness);

            foreach (Order o in this.population)
            {
                if (o.fitness == bestFit)
                    return o;
            }

           
            return null;
        }

    }
}
