using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris_Clasification
{
    internal class KNN
    {
        List<(double, double, double, double, string)> KNNData = new List<(double, double, double, double, string)>();
        public double Train(List<(double, double, double, double, string)> data)
        {
            Random r = new Random();
            List<(double, double, double, double, string)> testData = new List<(double, double, double, double, string)>();
            for(int i = 0; i < 20; i++)
            {    
                (double, double, double, double, string) x = data[r.Next(data.Count)];
                data.Remove(x);
                testData.Add(x);
            }
            KNNData = testData;
            int guesses = 0;
            int correct = 0;
            foreach(var d in testData)
            {
                if(Predict((d.Item1, d.Item2, d.Item3, d.Item4), 5) == d.Item5)
                {
                    correct++; 
                }
                guesses++;
                testData.Add(d);
            }
            return correct / guesses;
        }

        public string Predict((double, double, double, double) values,int k)
        {
            List<(double, double, double, double, string)> neigbors = KNNData.OrderBy(x => EuclidianDistance(x, values)).Take(k).ToList();
            return neigbors.Select(x => x.Item5).GroupBy(x => x).OrderByDescending(grp => grp.Count()).Select(g => g.Key).First();
        }

        public double EuclidianDistance((double, double, double, double, string) object1, (double, double, double, double) object2)
        {
            return Math.Sqrt(Math.Pow((object1.Item1 - object2.Item1), 2) + Math.Pow((object1.Item2 - object2.Item2), 2) + Math.Pow((object1.Item3 - object2.Item3), 2) + Math.Pow((object1.Item4 - object2.Item4), 2));
        }
    }
}
