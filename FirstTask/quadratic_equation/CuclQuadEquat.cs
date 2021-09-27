using NUnit.Framework.Constraints;
using System;


namespace quadratic_equation
{
    public class CuclQuadEquat
    {
        //объявление переменных
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public double[,] Nums { get; private set; }//двумерный массив для чисел из файла

        //объявление ссылки на структуру
        public Solution @Solution { get; private set; }
        //объявление класса ReadFromFile
        public ReadFromFile rf { get; private set; }

        public CuclQuadEquat(double a1, double b1, double c1)
        {
            A = a1;
            B = b1;
            C = c1;
            rf = new ReadFromFile();//создание экземпляра класса
        }

        //метод нахождения дискриминанта и корней
        //сначала находится дискриминант, затем, в зависимости от результата
        //передача в структуру корней (если дискриминант равен 0, то одного корня; если больше 0 то двух корней и т.д.)
        public void FindAnswere()
        {
            double d = Math.Pow(B, 2) - (4 * A * C);
            if (d < 0)
                Solution = new Solution(double.NaN, double.NaN, double.NaN, d);
            else if (d == 0)
                Solution = new Solution((-B) / (2 * A), double.NaN, double.NaN, d);
            else if(d > 0)
                Solution = new Solution(double.NaN, ((-B) + Math.Sqrt(d)) / (2 * A), ((-B) - Math.Sqrt(d)) / (2 * A), d);
        }

        //мнетод по нахождению квадратного уравнения по данным из файла
        //в метод передаются номер числа в двумерном массиве
        public void FindAnswereFromFile(int i, int j)
        {
            //если функция используется первый раз, то выполняется условие
            //для выделение памяти для двумерного массива и запись в него данных
            if (j == 0 && i==0)
            {
                Nums = rf.ReadFile();
            }
            //поочередное присваивание переменных из массива
            switch (j)
            {
                case 0:
                    A = Nums[i, j];
                    break;
                case 1:
                    B = Nums[i, j];
                    break;
                case 2:
                    C = Nums[i, j];
                    break;
            }

            //когда все числа будут присвоены, сделать расчет квадратного уравнения
            if(j==2)
                FindAnswere();
                
            
        }
    }

    //структура хранения корней и дискриминанта
    public struct Solution
    {
        public double X { get; private set; }
        public double X1 { get; private set; }
        public double X2 { get; private set; }
        public double D { get; private set; }

        public Solution(double x, double x1, double x2, double disk) : this()
        {
            X = x;
            X1 = x1;
            X2 = x2;
            D = disk;
        }
    }
}
