using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;

namespace RSACalculate
{
    public class RSACalculations
    {
        private static Random _rnx;

        /// <summary>
        /// Metoda odpowiedzialna za generowanie losowej liczby pierwszej z podanego zakresu
        /// </summary>
        /// <returns></returns>
        public static BigInteger randomInteger()
        {
            BigInteger x = 0;
            do
            {
                x = randomNumber(1000, 10000);
            } while (!checkIfPrime(x));
            return x;
        }

        /// <summary>
        /// Metoda odpowiedzialna za generowanie liczby z podanego zakresu
        /// </summary>
        /// <param name="min">Wartość minimalna zmiennej</param>
        /// <param name="max">Wartośc maksymalna zmiennej</param>
        /// <returns></returns>
        public static BigInteger randomNumber(int min, int max)
        {
            _rnx = new Random();
            return _rnx.Next(min, max);
        }

        /// <summary>
        /// Metoda sprawdzająca czy podana liczba jest pierwsza
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool checkIfPrime(BigInteger n)
        {
            var isPrime = true;
            var sqrt = Math.Sqrt((int)n);
            for (var i = 2; i <= sqrt; i++)
                if ((n % i) == 0) isPrime = false;
            return isPrime;
        }


        /// <summary>
        /// Metoda odpowiedzialna za generowanie liczby n oraz phi według wzoru
        /// </summary>
        /// <param name="type">Typ generowanej liczby</param>
        /// <param name="p">Wartość zmiennej p</param>
        /// <param name="q">Wartość zmiennej q</param>
        /// <returns></returns>
        public static BigInteger nAndPhiGenerator(String type, BigInteger p, BigInteger q)
        {
            if (type == "phi") return (p - 1) * (q - 1);
            else if (type == "n") return p * q;
            else return -1;
        }

        /// <summary>
        /// Metoda odpowiedzialna za generowanie liczby e wedlug wzoru
        /// </summary>
        /// <param name="phi">Wartość liczby phi</param>
        /// <returns></returns>
        public static BigInteger eGenerator(BigInteger phi)
        {
            BigInteger e = 0;
            do
            {
                e = generatePrime(100);
            } while (!isPrime(e) && !(BigInteger.GreatestCommonDivisor(e, phi) == 1));
            return e;
        }


        /// <summary>
        /// Metoda odpowiedzialna za generowanie liczby d według wzoru
        /// </summary>
        /// <param name="e">Wartość zmiennej e</param>
        /// <param name="phi">Wartość zmiennej phi</param>
        /// <returns></returns>
        public static BigInteger dGenerator(BigInteger e, BigInteger phi)
        {
            for(var i=0; i<phi*3; i++)
            {
                if ((e * i - 1) % phi == 0)
                {
                    return i;
                }
            }
            throw new ArithmeticException();
        }

        /// <summary>
        /// Metoda sprawdzająca czy podana liczba jest względnie pierwsza
        /// </summary>
        /// <param name="n">Podana liczba pierwsza</param>
        /// <returns></returns>
        public static bool isPrime(BigInteger n)
        {
            var sqrt = Math.Sqrt((int)n);
            if (n <= 0) throw new IOException();
            if (n == 1 || n == 2) return true;
            if (n % 2 == 0) return false;
            for (var i = 3; i <= sqrt; i++)
            {
                if (BigInteger.GreatestCommonDivisor(i, n) == i)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda generująca liczbę pierwszą o podanej minimalnej wartości
        /// </summary>
        /// <param name="min">Minimalna wartość liczby pierwszej</param>
        /// <returns></returns>
        public static BigInteger generatePrime(BigInteger min)
        {
            BigInteger primeNumber = 0;
            BigInteger temp;

            if (min % 2 == 0)
                temp = min + 1;
            else
                temp = min;
            bool flag = true;
            do
            {
                if (isPrime(temp) == true)
                    primeNumber = temp;
                else
                {
                    temp += 2;
                }
            } while (primeNumber == 0);
            return primeNumber;
        }
    }
}
