using System;

namespace MyTSP
{
    class City
    {

        public double X { get; private set; }
        public double Y { get; private set; }

        public City(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double distanceTo(City c)
        {
            return Math.Sqrt(Math.Pow((c.X - this.X), 2) + Math.Pow((c.Y - this.Y), 2));
        }

        public static City getCity()
        {
            return new City(Program.random.NextDouble(), Program.random.NextDouble());
        }


    }

}
