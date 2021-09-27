using System;
using NUnit.Framework;
using System.Windows.Forms;

namespace TestingQuadraticEquation
{
    public class Tests
    {
        //������������ ������� ���������� ����� ��������� ��� ������� �������������
        //���� �����: ������ ����� = 1, ������ = 2, ������ = 1
        //��������� ��������� - -1
        [Test]
        public void Find_root_with_a1b2c3()
        {
            double a = 1, b = 2, c = 1, exp = -1;
            quadratic_equation.CuclQuadEquat culc = new quadratic_equation.CuclQuadEquat(a, b, c);
            culc.FindAnswere();
            Assert.That(culc.Solution.X, Is.EqualTo(exp));
        }

        //������������ ������� �������������
        //���� �����: ������ ����� = 1, ������ = 2, ������ = 3
        //��������� ��������� - -8
        [Test]
        public void Find_disk()
        {
            double a = 1, b = 2, c = 3, exp = -8;
            quadratic_equation.CuclQuadEquat culc = new quadratic_equation.CuclQuadEquat(a, b, c);
            culc.FindAnswere();
            Assert.That(culc.Solution.D, Is.EqualTo(exp));
        }

        //������������ ������� ����������� ��������� � ����� �������
        //���� �����: ������ ����� = 1, ������ = 3, ������ = 1
        //��������� ���������: �1 = -0.38, �2 = -2.62
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