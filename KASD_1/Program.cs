using System;
using System.IO;
using System.Linq;
class Program
{
    static double Len(double[] v, double[,]G,int n)
    {
        double[] t=new double[n];
        for(int i=0;i<n;i++)
        {
            t[i] = 0;
            for(int j=0;j<n;j++)
            {
                t[i] += v[j] * G[i,j];
            }
        }
        double result = 0;
        for(int i=0;i<n;i++)
        {
            result += t[i] * v[i];
        }
        return Math.Sqrt(result);
    }
    static void Main()
    {
        string fileReader = @"input.txt";
        using (StreamReader sr = File.OpenText(fileReader))
        {
            int n = int.Parse(sr.ReadLine());
            double[,] G = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] lenght = sr.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    G[i, j] = double.Parse(lenght[j]);
                }
            }
            double[] v = sr.ReadLine().Split(' ').Select(double.Parse).ToArray(); //координаты вектора
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (G[i, j] != G[j, i])
                    {
                        Console.WriteLine("Матрица не симметрична");
                        return;
                    }
                }
            }
            double len = Len(v, G, n);
            Console.WriteLine("Длина:{0}", len);
        }
    }
}


