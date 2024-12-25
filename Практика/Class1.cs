using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика
{
    public class ArrayAnalyzer
    {
        public double[] Numbers { get; private set; }
        public ArrayAnalyzer()
        {
            Numbers = new double[100]; // Пример с 100 значениями
        }
        public void FillRandomData()
        {
            Random rand = new Random();
            Numbers[0] = rand.Next(0, 101);// Заполнение случайными значениями от 0 до 100
            for (int i = 1; i < Numbers.Length; i++)
            {
                if(rand.NextDouble()<0.33)
                {
                    Numbers[i] = Numbers[i-1];
                }
                else
                {
                    double newValue;
                    do
                    {
                        newValue = rand.Next(0, 101);
                    } while(newValue == Numbers[i-1]);
                    Numbers[i] = newValue;
                }
            }
        }
        public double[] GetEqualToPreviousValues()
        {
            List<double> equalValues = new List<double>();
            for (int i = 1; i < Numbers.Length; i++)
            {
                if (Numbers[i] == Numbers[i - 1])
                {
                    equalValues.Add(Numbers[i]);
                }
            }
            return equalValues.ToArray();
        }
        public int CountEqualToPrevious()
        {
            int count = 0;
            for (int i = 1; i < Numbers.Length; i++)
            {
                if (Numbers[i] == Numbers[i - 1])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
