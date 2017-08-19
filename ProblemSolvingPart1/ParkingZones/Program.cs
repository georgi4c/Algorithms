using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingZones
{
    class ParkZone
    {
        public ParkZone(string type, int x, int y, int length, int width, double price)
        {
            Type = type;
            X = x;
            Y = y;
            Length = length;
            Width = width;
            PricePerMinute = price;
        }


        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public double PricePerMinute { get; set; }
        public int[] ClosestPoint { get; set; }
        public int ClosestDistance { get; set; } = int.MaxValue;
        public double Price { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var zones = new List<ParkZone>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(':').ToArray();
                var others = input[1].Split(',').Select(x => x.Trim()).ToArray();
                var zone = new ParkZone(input[0], int.Parse(others[0]), int.Parse(others[1]), int.Parse(others[2]), int.Parse(others[3]), double.Parse(others[4]));
                zones.Add(zone);
            }

            var input1 = Console.ReadLine().Split(';').ToArray();
            var points = new List<int[]>();
            for (int j = 0; j < input1.Length; j++)
            {
                var coordinates = input1[j].Split(',').Select(x => int.Parse(x.Trim())).ToArray();
                var arr3 = new int[3] { coordinates[0], coordinates[1], 0 };

                points.Add(arr3);
            }
            var t = Console.ReadLine().Split(',').Select(x => int.Parse(x.Trim())).ToArray();
            int k = int.Parse(Console.ReadLine());
            foreach (var point in points)
            {
                var distance = Math.Abs(point[0] - t[0]) + Math.Abs(point[1] - t[1]) - 1;
                if (point[0] == t[0] || point[1] == t[1])
                {
                    distance++;
                }
                point[2] = distance;
                for (int i = 0; i < zones.Count; i++)
                {
                    var curZ = zones[i];
                    if (curZ.X <= point[0] && point[0] < curZ.X + curZ.Length && curZ.Y <= point[1] && point[1] < curZ.Y + curZ.Width)
                    {
                        if (point[2] < curZ.ClosestDistance)
                        {
                            curZ.ClosestDistance = point[2];
                            curZ.ClosestPoint = new int[2] { point[0], point[1] };
                        }

                    }
                }

            }
            double minPrice = int.MaxValue;
            ParkZone bestZone = zones[0];
            foreach (var zone in zones)
            {
                double price = 0;
                price = zone.ClosestDistance * 2 * k / 60.0;
                price = Math.Ceiling(price) * zone.PricePerMinute;
                zone.Price = price;

                if (price < minPrice)
                {
                    minPrice = price;
                    bestZone = zone;
                }
            }
            Console.WriteLine($"Zone Type: {bestZone.Type}; X: {bestZone.ClosestPoint[0]}; Y: {bestZone.ClosestPoint[1]}; Price: {bestZone.Price:f2}");





        }
    }
}
