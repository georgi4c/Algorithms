using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleIntersectionFast
{
    class Program
    {
        public class RectangleIntersection
        {
            public static void Main(string[] args)
            {
                List<Rectangle> allRectangles = new List<Rectangle>();
                List<int> x = new List<int>();

                // parse the rectangles and simultaniously fill the xCoordinates array
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    int minX = parameters[0];
                    int maxX = parameters[1];
                    int minY = parameters[2];
                    int maxY = parameters[3];
                    Rectangle rectangle = new Rectangle(minX, maxX, minY, maxY);
                    allRectangles.Add(rectangle);
                    x.Add(minX);
                    x.Add(maxX);
                }

                // sort the rectangles by their minY, also sort xCoordinates in an ascending order
                allRectangles.Sort();
                x.Sort();

                // rect will hold all rectangles which overlap a given area (ex. rect[i] holds all rectangles which are present in the area from x[i] to x[i+1]);
                // thus the size of rect is xCoordinates.Count - 1;
                List<Rectangle>[] rect = new List<Rectangle>[x.Count - 1];

                // initialize the lists in rect
                for (int i = 0; i < x.Count - 1; i++)
                {
                    rect[i] = new List<Rectangle>();
                }

                // for each rectangle check if it overlaps every area x[i] to x[i+1] and for every area it does add it to rect[i];
                foreach (var rectangle in allRectangles)
                {
                    for (int i = 0; i < x.Count - 1; i++)
                    {
                        if (rectangle.MaxX > x[i] && rectangle.MinX < x[i + 1])
                        {
                            rect[i].Add(rectangle);
                        }
                    }
                }

                long sum = 0;

                for (int j = 0; j < rect.Length; j++)
                {
                    // if in the current area rect[j] there are less than 2 rectangles, skip it, since there can be no overlapping
                    if (rect[j].Count < 2)
                    {
                        continue;
                    }

                    // extract all y coordinates from the rectangles in the current area
                    List<int> y = new List<int>();
                    foreach (var rectangle in rect[j])
                    {
                        y.Add(rectangle.MinY);
                        y.Add(rectangle.MaxY);
                    }

                    y.Sort();

                    // create a overlapCount array to store the number of overlaps between each area y[i] - y[i+1]
                    // for every rectangle, check against every area between yCoordinates[i] and y[i+1] and increase the overlap counter for that area if the rectangle overlaps it
                    int[] overlapCount = new int[y.Count - 1];
                    foreach (var rectangle in rect[j])
                    {
                        for (int i = 0; i < y.Count - 1; i++)
                        {
                            if (rectangle.MaxY > y[i] && rectangle.MinY < y[i + 1])
                            {
                                overlapCount[i]++;
                            }
                        }
                    }

                    // check the overlapCounter for every area, if an area has 2 or more overlaps, calculate its quadrature and add it to the total sum
                    // we know the distanceX because every rect[j] corresponds to the area between x[j] and x[j+1];
                    for (int i = 0; i < overlapCount.Length; i++)
                    {
                        if (overlapCount[i] >= 2)
                        {
                            int distanceX = x[j + 1] - x[j];
                            int distanceY = y[i + 1] - y[i];
                            long quadrature = distanceX * distanceY;
                            sum += quadrature;
                        }
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
    public class Rectangle : IComparable<Rectangle>
    {
        public Rectangle(int minX, int maxX, int minY, int maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
        }

        public int MinX { get; private set; }

        public int MaxX { get; private set; }

        public int MinY { get; private set; }

        public int MaxY { get; private set; }

        public int CompareTo(Rectangle other)
        {
            return this.MinY.CompareTo(other.MinY);
        }
    }
}
