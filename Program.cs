using System;
using System.IO;

namespace tires
{
    class Program
    {
        static void Main(string[] args)
        {
            string len = "";
            using (System.IO.TextReader reader = new StreamReader(@"C:\\Users\\Konstantin\\OneDrive\\Desktop\\.net\\2\\tires\\tires\\input.txt"))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    len = str;
                    break;
                }
            }
            string[] forSplit = len.Split(' ');
            string[] arr = new string[Convert.ToInt32(forSplit[1] + 1)];

            int counter = 0;
            using (System.IO.TextReader reader = new StreamReader(@"C:\\Users\\Konstantin\\OneDrive\\Desktop\\.net\\2\\tires\\tires\\input.txt"))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    arr[counter] = str;
                    counter++;
                }
            }

            int M = Convert.ToInt32(forSplit[1]), N = Convert.ToInt32(forSplit[0]);
            int[] arrCopy = new int[N];
            for (int i = 0; i < N; i++)
            {
                arrCopy[i] = Convert.ToInt32(arr[i + 1]);
            }

            double km = 0;
            int counterTires = M - N;
            while (counterTires > 0)
            {
                for (int i = 0; i < N; i++)
                {
                    if (arrCopy[i] <= 0)
                    {
                        arrCopy[i] += Convert.ToInt32(arr[i + 1]);
                        counterTires--;
                        arrCopy[i]--;
                        km++;
                    }
                    else
                    {
                        arrCopy[i]--;
                        km++;
                    }
                }
            }

            double min = 3000;
            for (int i = 0; i < N; i++)
            {
                if (min > arrCopy[i])
                {
                    min = arrCopy[i];
                }
            }

            km /= N;
            km += min;

            using (StreamWriter sw = new StreamWriter(@"C:\\Users\\Konstantin\\OneDrive\\Desktop\\.net\\2\\tires\\tires\\output.txt"))
            {
                sw.WriteLine(Math.Round(km, 3));
            }
        }
    }
}
