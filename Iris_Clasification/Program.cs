using System;

namespace Iris_Clasification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using StreamReader r = new StreamReader("testData.txt");
            {
                string input = r.ReadLine();
                List<(double, double, double, double, string)> data = new List<(double, double, double, double, string)>();
                while(input != null)
                {
                    string[] inputAr = input.Split(',');
                    var x = (double.Parse(inputAr[0]), double.Parse(inputAr[1]), double.Parse(inputAr[2]), double.Parse(inputAr[3]), inputAr[4]);
                    data.Add(x);
                    input = r.ReadLine();
                }
                KNN kNN = new KNN();

                Console.WriteLine(kNN.Train(data));
            }
        }
    }
}