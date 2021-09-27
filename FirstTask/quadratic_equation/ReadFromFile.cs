using System;
using System.IO;
using System.Windows.Forms;

namespace quadratic_equation
{
    public class ReadFromFile
    {
        public string fileName { get; set; }

        //чтение файла с компьютера
        public void GetFileName() {

            //создание нового объекта файлового диалога с последующим открытием
            //и записью в переменную имени выбранного файла
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;//запись имени файла в переменную
            }
        }

        //запись чисел из файла в двумерный массив
        //файл должен был формата .txt
        //числа должы быть записаны в формате:
        //1 2 3
        //4 5 6
        //7 8 9
        public double[,] ReadFile()
        {
            GetFileName();
            string[] lines = File.ReadAllLines(fileName);//массив с линиями чисел из файла

            //создание двумерного массива с размерами:
            //[кол-во линий, кол-во символов в линии разделенных пробелом]
            double[,] num = new double[lines.Length, lines[0].Split(' ').Length];

            //цикл для записи чисел в двумерный массив
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');//запись во временный массив каждой строки чисел
                for (int j = 0; j < temp.Length; j++)
                    num[i, j] = Double.Parse(temp[j]);//запись числа в двумерный массив
            }

            //вывод массива
            return num;
        }

        

    }
}
