using System.Collections.Generic;

namespace MyTSP
{
    class Order
    {
        public List<City> order { get;  set; }
        public double distance { get;  set; }
        public double fitness { get;  set; }

        public  Order(List<City> order)
        {
            this.order = order;
            this.distance = this.calcDistance();
            this.fitness = this.calcFitness();
        }

        public static Order GetOrder(int cityNumber)
        {
            List<City> order = new List<City>();

            for (int i = 0; i < cityNumber; ++i)
                order.Add(City.getCity());

            return new Order(order);
        }

        public Order mutate()
        {
            List<City> tmp = new List<City>(this.order);

                int i = Program.random.Next(0, this.order.Count);
                int j = Program.random.Next(0, this.order.Count);
                City v = tmp[i];
                tmp[i] = tmp[j];
                tmp[j] = v;

            return new Order(tmp);
        }


        private double calcDistance()
        {
            double total = 0;
            
            for (int i = 0; i < this.order.Count; ++i)
            {
                total += this.order[i].distanceTo(this.order[(i + 1) % this.order.Count]);

            }

            return total;

        }

        public Order swap()
        {
            List<City> newOder = new List<City>(this.order);
            int count = newOder.Count;

            while (count > 1)
            {
                count--;
                int k = Program.random.Next(count + 1);
                City c = newOder[k];
                newOder[k] = newOder[count];
                newOder[count] = c;
                
            }

            return new Order(newOder);
        }

        private double calcFitness()
        {
            return 1 / this.distance;
        }


    }

}
