﻿using System;
using System.Globalization;
using System.Linq;

namespace ConsoleApp1
{
    public class Number
    {
        protected long integerPart;
        protected ushort fractionalPart;
        protected int firstNumber;
        protected int secondNumber;
        protected int thirdNumber;
        public long IntegerPart { get { return integerPart; } set { integerPart = value; } }
        public ushort FractionalPart { get { return fractionalPart; } set { fractionalPart = value; } }
        public int FirstNumber { get { return firstNumber; } set { firstNumber = value; } }
        public int SecondNumber { get { return secondNumber; } set { secondNumber = value; } }
        public int ThirdNumber { get { return thirdNumber; } set { thirdNumber = value; } }

        public virtual void Info()
        {
            Console.WriteLine("ANASTASIJA MEZALE, 4802BD");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();
        }
    }

    public class Fraction : Number
    {

        public Fraction Add(Fraction num)
        {
            float res = float.Parse(integerPart + "," + fractionalPart) +
                        float.Parse(num.integerPart + "," + num.fractionalPart);
            string[] parts = res.ToString("0.0###").Split(',');
            return new Fraction(int.Parse(parts[0]), ushort.Parse(parts[1]));
        }

        public Fraction Mult(Fraction num)
        {
            float res = float.Parse(integerPart + "," + fractionalPart) *
                        float.Parse(num.integerPart + "," + num.fractionalPart);
            string[] parts = res.ToString("0.0###").Split(',');
            return new Fraction(int.Parse(parts[0]), ushort.Parse(parts[1]));
        }

        public Fraction Sub(Fraction num)
        {
            float res = float.Parse(integerPart + "," + fractionalPart) -
                        float.Parse(num.integerPart + "," + num.fractionalPart);
            string[] parts = res.ToString("0.0###").Split(',');
            return new Fraction(int.Parse(parts[0]), ushort.Parse(parts[1]));
        }

        public Fraction Div(Fraction num)
        {
            float res = float.Parse(integerPart + "," + fractionalPart) /
                        float.Parse(num.integerPart + "," + num.fractionalPart);
            string[] parts = res.ToString("0.0###").Split(',');
            return new Fraction(int.Parse(parts[0]), ushort.Parse(parts[1]));
        }

        public bool Gt(Fraction num)
        {
            return float.Parse(integerPart + "," + fractionalPart) <
                   float.Parse(num.integerPart + "," + num.fractionalPart);
        }

        public bool Lt(Fraction num)
        {
            return float.Parse(integerPart + "," + fractionalPart) >
                   float.Parse(num.integerPart + "," + num.fractionalPart);
        }

        public Fraction(long integerPart, ushort fractionalPart)
        {
            this.integerPart = integerPart;
            this.fractionalPart = fractionalPart;
        }

        public override string ToString()
        {
            return integerPart + "," + fractionalPart;
        }

        public void Info(Fraction num)
        {
            Console.WriteLine();
            Console.WriteLine("1st number: {0},{1}", IntegerPart, FractionalPart);
            Console.WriteLine("2nd number: {0},{1}", num.IntegerPart, num.FractionalPart);
            Console.WriteLine();
            Console.WriteLine("Addition: " + Add(num));
            Console.WriteLine("Subtraction: " + Sub(num));
            Console.WriteLine("Multiplication: " + Mult(num));
            Console.WriteLine("Division: " + Div(num));
            Console.WriteLine();
            Console.WriteLine("Number1 < Number2: " + Gt(num));
            Console.WriteLine("Number1 > Number2: " + Lt(num));
        }
    }

    public class Integer : Number
    {

        public int Add()
        {
            return firstNumber + secondNumber;
        }

        public int Add(Integer num)
        {
            return num.firstNumber + num.secondNumber + num.thirdNumber;
        }

        public int Mult()
        {
            return firstNumber * secondNumber;
        }

        public int Mult(Integer num)
        {
            return num.firstNumber * num.secondNumber * num.thirdNumber;
        }

        public int Sub()
        {
            return firstNumber - secondNumber;
        }

        public int Sub(Integer num)
        {
            return num.firstNumber - num.secondNumber - num.thirdNumber;
        }

        public Integer(int firstNumber, int secondNumber)
        {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
        }

        public Integer(int firstNumber, int secondNumber, int thirdNumber)
        {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
            this.thirdNumber = thirdNumber;
        }

        public override string ToString()
        {
            if (thirdNumber == 0)
                return firstNumber + ", " + secondNumber;
            else return firstNumber + ", " + secondNumber + ", " + thirdNumber;
        }

        public override void Info()
        {
            Console.WriteLine();
            Console.WriteLine("Set: {0}, {1}, ", FirstNumber, SecondNumber);
            Console.WriteLine("Addition: " + Add());
            Console.WriteLine("Subtraction: " + Sub());
            Console.WriteLine("Multiplication: " + Mult());
        }

        public void Info(Integer num)
        {
            Console.WriteLine();
            Console.WriteLine("Set: {0}, {1}, {2}", FirstNumber, SecondNumber, ThirdNumber);
            Console.WriteLine("Addition: " + Add(num));
            Console.WriteLine("Subtraction: " + Sub(num));
            Console.WriteLine("Multiplication: " + Mult(num));
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Number info = new Number();
            info.Info();
            Fraction number1 = new Fraction(12, 5);
            Fraction number2 = new Fraction(15, 25);
            Console.WriteLine("------1------");
            number1.Info(number2);
            Console.WriteLine();
            Integer set1 = new Integer(7, 8);
            Integer set2 = new Integer(15, 4, 6);
            Console.WriteLine("------2------");
            set1.Info();
            set2.Info(set2);
            Console.ReadLine();
        }
    }
}
