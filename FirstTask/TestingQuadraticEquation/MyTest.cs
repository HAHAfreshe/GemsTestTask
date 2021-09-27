using System;
using NUnit.Framework;
using System.Windows.Forms;

namespace TestingQuadraticEquation
{
    public class Tests
    {
        //тестирование функции вычисления корня уравнения при нулевом дискриминанте
        //даны числа: первое число = 1, второе = 2, третье = 1
        //ожидаемый результат - -1
        [Test]
        public void Find_root_with_a1b2c3()
        {
            double a = 1, b = 2, c = 1, exp = -1;
            quadratic_equation.CuclQuadEquat culc = new quadratic_equation.CuclQuadEquat(a, b, c);
            culc.FindAnswere();
            Assert.That(culc.Solution.X, Is.EqualTo(exp));
        }

        //тестирование расчета дискриминанта
        //даны числа: первое число = 1, второе = 2, третье = 3
        //ожидаемый результат - -8
        [Test]
        public void Find_disk()
        {
            double a = 1, b = 2, c = 3, exp = -8;
            quadratic_equation.CuclQuadEquat culc = new quadratic_equation.CuclQuadEquat(a, b, c);
            culc.FindAnswere();
            Assert.That(culc.Solution.D, Is.EqualTo(exp));
        }

        //тестирование расчета квадратного уравнения с двумя корнями
        //даны числа: первое число = 1, второе = 3, третье = 1
        //ожидаемый результат: х1 = -0.38, х2 = -2.62
        [Test]
        public void Find_root_if_disk_more_zero()
        {
            double a = 1, b = 3, c = 1, exp1 = -0.38, exp2 = -2.62;
            quadratic_equation.CuclQuadEquat culc = new quadratic_equation.CuclQuadEquat(a, b, c);
            culc.FindAnswere();
            Assert.That(Math.Round(culc.Solution.X1, 2), Is.EqualTo(exp1));
            Assert.That(Math.Round(culc.Solution.X2, 2), Is.EqualTo(exp2));
        }
    }
}