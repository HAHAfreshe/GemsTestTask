using System;

namespace quadratic_equation
{
    public class MainPorgramm
    {
        //функция для проверки ввода
        static double InputNubm()
        {
            double numb;//проверяемая перменная
            while (true)
            {
                try
                {
                    numb = double.Parse(Console.ReadLine());//ввод переменной
                    break;
                }
                catch(Exception)
                {
                    //сообщение об ошибке
                    Console.Write("Некорректный ввод! Попробуйте еще раз >>> ");
                }
            }
            //вывод верной переменной
            return numb;
        }

        //вывод получившегося квадратного уравнения
        public static string OutEquat(CuclQuadEquat c)
        {
            return string.Format("{0}x^2 {1} {2}x {3} {4} = 0",  c.A, c.B < 0 ? "-" : "+", Math.Abs(c.B), c.C < 0 ? "-" : "+", Math.Abs(c.C));
        }

        //вывод ответа, в зависимости от значения дискриминанта 
        public static string OutRoors(CuclQuadEquat c)
        {
            if (c.Solution.D < 0)
                return string.Format("Корней нет");
            else if (c.Solution.D == 0)
                return string.Format("Корень данного уравнения: {0}", Math.Round(c.Solution.X, 2));
            else
                return string.Format("Корни данного уравнения: {0} и {1}", Math.Round(c.Solution.X1, 2), Math.Round(c.Solution.X2, 2));
        }

        //по причине использования системных диалогов, таких как FileDialog,
        //использование STAThreadAttribute является обязательным
        [STAThread]
        static void Main(string[] args)
        {
            //определение перменных
            //a - первое число
            //b - второе число
            //с - третье число
            //oneMore - переменная для повторного расчета уравнения
            //chooseInput - выбор ввода данных (клавиатура/файл)
            double a = 0, b = 0, c = 0, oneMore, chooseInput;
            CuclQuadEquat cl;
            Console.WriteLine("Решения квадратного уравнения!");


            //цикл решения уравнения
            //выход из цикла происходит в конце при oneMore = 2
            while (true)
            {
                Console.Write("Выберите способ ввода текста (1 - клавиатура/2 - txt-файл) >>> ");
                chooseInput = InputNubm();
                Console.Clear();

                //кейс, где при разных способах ввода информации, выполняются разные действия
                switch (chooseInput)
                {
                    //выбран ввод с клавиатуры
                    case 1:
                        do
                        {
                            Console.Write("Введите первое чило: ");
                            a = InputNubm();
                            //в квадратнм уравнении, первое число не может быть равно нулю!
                            if (a == 0)
                            {
                                Console.WriteLine("Первое число не может быть равно нулю!");
                            }
                            else
                                break;
                        } while (true);//выполняется, пока пользователь не введт число, не равное нулю

                        Console.Write("Введите второе чило: ");
                        b = InputNubm();
                        Console.Write("Введите третье чило: ");
                        c = InputNubm();

                        Console.Clear();

                        cl = new CuclQuadEquat(a, b, c); //создание экземпляра класса
                        cl.FindAnswere();//вычисления
                        
                        Console.WriteLine(OutEquat(cl));//вывод уравнения
                        Console.WriteLine(OutRoors(cl));//вывод корней
                        break;

                    //выбран ввод данных из файла
                    case 2:
                        cl = new CuclQuadEquat(double.NaN, double.NaN, double.NaN);
                        int i = 0, j = 0;//номера чисел в двумерном массиве
                        cl.FindAnswereFromFile(i, j);//первый вызов функции для расчета квадратного уравнения из файла

                        //расчет квадратного уравнения с последующим выводом его на экран
                        //сначала мы выбираем номер строки из двумерного массива
                        //затем проходимся по всем числам в строке массива и приравниваем
                        //как только все три числа были получены, производится расчет и вывод результата
                        //затем переход к следующей строке
                        for (; i < cl.Nums.GetLength(0); i++)
                        {
                            //переменная, для дополнительного условия проверки
                            //первого вызова функции, когда идет переход на вторую и последующую
                            //строку числео в массиве
                            bool chek = true;  
                            for (j = 1; j < cl.Nums.GetLength(1); j++)
                            {
                                //если был переход на вторую строку и был совершен вход во внутренний цикл
                                //приравнять номер числа в строке к 0, чтобы получить первое число из строки чисел
                                //и приравнять проверяющую переменную к false, дабы больше небыл совершен вход в это условие
                                if (chek && i > 0)
                                {
                                    chek = false;
                                    j = 0;
                                }
                                cl.FindAnswereFromFile(i, j);//расчет квадратного уравнения
                            }
                            Console.WriteLine(OutEquat(cl));//вывод уравнения
                            Console.WriteLine(OutRoors(cl));//вывод корней
                        }
                        
                        break;
                }

                //повторное рещение нового уравнения
                Console.Write("Решить еще одно? (1 - да/2 - нет) >>> ");
                oneMore = InputNubm();
                Console.Clear();
                if (oneMore == 2)
                    break;

            }


        }
    }
}
